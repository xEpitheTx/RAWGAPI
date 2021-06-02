using System;
using System.Collections.Generic;
using System.Net;

namespace ConsoleApp1
{
    class Program
    {
        private const string aPIKey = "?key=1d28751350144a4e835b8e6a355f9113";
        private const string uRL = "https://api.rawg.io/api/";
        static void Main(string[] args)
        {
            var client = new WebClient();
            //string response = client.DownloadString($"{uRL}games{aPIKey}");
            //System.IO.File.WriteAllText("games.txt", response);
            string response = System.IO.File.ReadAllText("games.txt");
        }
    }
}