using System;
using System.Collections.Generic;
using System.Net;
using RAWGAPI;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            APIGames API = new APIGames("1d28751350144a4e835b8e6a355f9113");
            APIResponse<APIGameResult> apiResponse = API.GetAPIResponse();
            Console.WriteLine(API.APICall());
        }
    }
}