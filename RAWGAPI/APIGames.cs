﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Parameter = System.Tuple<string, string>;

namespace RAWGAPI
{
    public abstract class BaseAPI
    {
        protected abstract string RequestPage { get; }

        private string APIKey;
        public BaseAPI(string apiKey)
        {
            APIKey = apiKey;
        }

        private const string uRL = "https://api.rawg.io/api/";
        private WebClient client = new WebClient();

        public string APICall(params Parameter[] additionalParameters)
        {
            string requestURL = $"{uRL}{RequestPage}";

            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("key", APIKey)
            };
            parameters.AddRange(additionalParameters);
            requestURL += $"?{string.Join("&", parameters.Select(a => $"{a.Item1}={a.Item2}"))}";

            //string response = client.DownloadString(requestURL);
            //System.IO.File.WriteAllText("games.txt", response);
            return System.IO.File.ReadAllText("games.txt");
        }
    }

    public class APIGames : BaseAPI
    {
        public APIGames(string apiKey) : base(apiKey) { }

        protected override string RequestPage => "games";

        //Work this into base, APIGameResult should be a parameter
        public APIResponse<APIGameResult> GetAPIResponse(params Parameter[] parameters)
        {
            return JsonConvert.DeserializeObject<APIResponse<APIGameResult>>(APICall(parameters));
        }
    }

    public class APIResponse<T>
    {
        public long Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        [JsonProperty("Results")]
        public List<T> GameResults { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public class APIGameResult
    {
        public long ID { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Released { get; set; }
        public bool Tba { get; set; }
        public string Background_Image { get; set; }
        public decimal Rating { get; set; }
        public int Rating_Top { get; set; }
        [JsonProperty("Ratings")]
        public List<APIGameRating> GameRatings { get; set; }
        public long Ratings_Count { get; set; }
        public int Reviews_Text_Count { get; set; }
        public long Added { get; set; }
        public APIGameAddedByStatus Added_By_Status { get; set; }
        public int? Metacritic { get; set; }
        public int PlayTime { get; set; }
        public int Suggestions_Count { get; set; }
        public string Updated { get; set; }
        public string User_Game { get; set; }
        public long Reviews_Count { get; set; }
        public string Saturated_Color { get; set; }
        public string Dominant_Color { get; set; }
        public List<APIGamePlatform> Platforms { get; set; }
        public List<APIGameGenre> Genres { get; set; }
        public List<APIGameStore> Stores { get; set; }
        public string Clip { get; set; }
        public List<APIGameTag> Tags { get; set; }
        public APIGameESRBRating Esrb_Rating { get; set; }
        public List<APIGameShortScreenShot> Short_Screenshots { get; set; }

    }

    [DebuggerDisplay("{Percent}")]
    public class APIGameRating
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public long Count { get; set; }
        public decimal Percent { get; set; }
    }

    public class APIGameAddedByStatus
    {
        public APIGameAddedByStatus Added_By_Status { get; set; }
        public long Yet { get; set; }
        public long Owned { get; set; }
        public long Beaten { get; set; }
        public long ToPlay { get; set; }
        public long Dropped { get; set; }
        public long Playing { get; set; }
    }

    public class APIGamePlatform
    {
        public ApiGamePlatform Platform { get; set; }
        public string Released_At { get; set; }
        //public string Requirements_En { get; set; }
        //public string Requirements_Ru { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public class ApiGamePlatform
    {
        public ApiGamePlatform Platform { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Year_End { get; set; }
        public string Year_Start { get; set; }
        public long Games_Count { get; set; }
        public string Image_Background { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public class APIGameGenre
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public long Games_Count { get; set; }
        public string Image_Background { get; set; }
    }

    public class APIGameStore
    {
        public long ID { get; set; }
        public StoreDetail Store { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public class StoreDetail
    {
        public StoreDetail Store { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Domain { get; set; }
        public long Games_Count { get; set; }
        public string Image_Background { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public class APIGameTag
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public long Games_Count { get; set; }
        public string Image_Background { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public class APIGameESRBRating
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }

    public class APIGameShortScreenShot
    {
        public long ID { get; set; }
        public string Image { get; set; }
    }
}
