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
            Class1 API = new RAWGAPI.Class1();
            APIResponse apiResponse = API.GetAPIResponse();
            Console.WriteLine(API.APICall());
        }
    }
}