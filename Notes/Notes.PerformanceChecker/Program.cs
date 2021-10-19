using System;
using System.Net.Http;

namespace Notes.PerformanceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Performance check");
            Console.WriteLine($"-----------------");

            CheckedNotesPerformance();

            Console.ReadLine();
        }

        static void CheckedNotesPerformance()
        {
            HttpClient _client = new HttpClient();
            string url = "";

            int limit = 100;

            HttpResponseMessage resposne = _client.GetAsync(url).Result;

            string responseBody = resposne.Content.ReadAsStringAsync().Result;

            Console.ForegroundColor = ConsoleColor.Green;
            if (int.Parse(responseBody) > limit)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"Performance: {responseBody} | Limit: {limit}");
            }

        }
    }
}
