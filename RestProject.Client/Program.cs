// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;

namespace RestProject.Client
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Starting client");

            var client = new HttpClient();
            var endpoint = "http://localhost:8080/RestProject/webapi/comparator";

            client.BaseAddress = new Uri(endpoint);

            Console.WriteLine("Choose a method: GET, POST, PUT, DELETE");
            var httpMethod = Console.ReadLine();

            var httpRequester = new HttpRequester(client);
            do
            {
                string httpResult = httpMethod switch
                {
                    "get" => await httpRequester.GetAsync(GetContent("endpoint")),
                    "post" => await httpRequester.GetAsync(GetContent("endpoint")),
                    "put" => await httpRequester.PutAsync(GetContent("endpoint"),
                                                          GetContent("content")),
                    _ => "No method specified",
                };
                Console.WriteLine(httpResult);

                Console.WriteLine("Choose a method: GET, POST, PUT, DELETE");
                httpMethod = Console.ReadLine();
            } while (httpMethod is not null && httpMethod != "");

        }

        private static string GetContent(string typeOfContent)
        {
            Console.WriteLine($"Enter {typeOfContent}");
            string? inputContent;
            do
            {
                inputContent = Console.ReadLine();
            } while (inputContent is null);
            return inputContent;
        }
    }
}