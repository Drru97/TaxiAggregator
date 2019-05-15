using System;
using System.Net.Http;
using TaxiAggregator.Uber;
using TaxiAggregator.Uber.Models.Requests;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new UberHttpClient(new HttpClient(), "G2BVdH1STnzYM75I3OVsp5XdYMSQipE0RNcvHxcV");

            var request = new TimeEstimateRequest
            {
                StartLatitude = 49.871448,
                StartLongitude = 24.053115
            };

            var response = client.EstimateTimeAsync(request).GetAwaiter().GetResult();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}