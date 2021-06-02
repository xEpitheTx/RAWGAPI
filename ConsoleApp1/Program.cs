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
            APIGames API = new APIGames();
            APIResponse apiResponse = API.GetAPIResponse();
            Console.WriteLine(API.APICall());
        }
    }
}