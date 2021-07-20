using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url1 = "https://codeavecjonathan.com/res/dummy.txt";
            string url2 = "https://codeavecjonathan.com/res/pizzas1.json";

            Console.WriteLine("Téléchargement...");
            var displayTask = DispplayProgress();
            var downloadTask1 = DownloadData(url1);
            var downloadTask2 = DownloadData(url2);

            //await downloadTask1;
            //await downloadTask2;
            await Task.WhenAll(downloadTask1, downloadTask2);


            Console.WriteLine("FIN DU PROGRAMM");
            
        }
        
        static async Task DownloadData(string url)
        {
            var httpClient = new HttpClient();

            

            var result = await httpClient.GetStringAsync(url);
            

            Console.WriteLine("OK -> " + url);

            //Console.WriteLine(result);
        }

        static async Task DispplayProgress()
        {
            while (true)
            {
                await Task.Delay(500);
                Console.Write(".");
            }
        }
    }
}
