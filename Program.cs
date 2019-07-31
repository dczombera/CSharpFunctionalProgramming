using System;
using System.Net;

namespace functional_programming
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            Func<string, string> download = url => client.DownloadString(url);
            Func<string, Func<string>> downloadCurry = download.Curry();

            var data = download.Partial("https://microsoft.com").WithRetry();
            var data2 = downloadCurry("https://microsoft.com").WithRetry();

            System.Console.WriteLine(data);
            System.Console.WriteLine(data2);
        }
    }
}
