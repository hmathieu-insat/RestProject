// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;
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

            //await FirstPartOfProtject(client);

            var newPerson = new Person
            {
                Name = "Jan",
                Surname = "Kowalski",
                Function = "Programmer"
            };
            var juan = new Person
            {
                Name = "Juan",
                Surname = "Perez",
                Function = "Programmer"
            };
            var newTask = new Tasks
            {
                Title = "New task",
                Handler = newPerson
            };
            var newTask2 = new Tasks
            {
                Title = "New task 2",
                Handler = juan
            };
            var response = await client.PostAsJsonAsync("http://localhost:8080/RestProject/webapi/tasks", newTask);
            Console.WriteLine(response);
            response.EnsureSuccessStatusCode();
            
            response = await client.PostAsJsonAsync("http://localhost:8080/RestProject/webapi/tasks", newTask2);
            Console.WriteLine(response);

            var allItems = await client.GetStringAsync("http://localhost:8080/RestProject/webapi/tasks");
            var item = await client.GetStringAsync("http://localhost:8080/RestProject/webapi/tasks/1");

        }

        private static async Task FirstPartOfProtject(HttpClient client)
        {
            Console.WriteLine("Choose a method: GET, POST, PUT, DELETE");
            var httpMethod = Console.ReadLine();

            var httpRequester = new HttpRequester(client);
            do
            {
                string httpResult = httpMethod switch
                {
                    "get" => await httpRequester.GetAsync(GetContent("endpoint")),
                    "post" => await httpRequester.PostAsync(GetContent("endpoint"), GetContent("content")),
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