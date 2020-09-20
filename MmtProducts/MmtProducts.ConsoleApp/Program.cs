using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MmtProducts.ConsoleApp
{
    public class Program
    {
        private const string ApiUrl = "https://localhost:44359";

        static async Task Main(string[] args)
        {
            using var httpClient = new HttpClient();

            var result = await httpClient.GetAsync($"{ApiUrl}/products?category=home");
            var content = await result.Content.ReadAsStringAsync();
            Console.WriteLine("Products with category of Home:");
            Console.WriteLine(content);
            Console.WriteLine();

            result = await httpClient.GetAsync($"{ApiUrl}/products/featured");
            content = await result.Content.ReadAsStringAsync();
            Console.WriteLine("Featured Products:");
            Console.WriteLine(content);
            Console.WriteLine();

            result = await httpClient.GetAsync($"{ApiUrl}/categories");
            content = await result.Content.ReadAsStringAsync();
            Console.WriteLine("Categories:");
            Console.WriteLine(content);
            Console.WriteLine();
        }
    }
}
