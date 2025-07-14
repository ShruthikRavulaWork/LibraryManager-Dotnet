 //See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LibraryApiConsumer.Models;

namespace LibraryApiConsumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7153/"); // Replace with your actual API URL

            try
            {
                // GET all items
                var items = await client.GetFromJsonAsync<List<LibraryItem>>("api/Library");
                Console.WriteLine("Library Items:");
                items?.ForEach(item =>
                    Console.WriteLine($"{item.Id}: {item.Title} by {item.Author} ({item.YearPublished})"));

                // POST a new item
                var newItem = new LibraryItemDto
                {
                    Title = "New Book",
                    Author = "Author Name",
                    YearPublished = 2020
                };

                var postResponse = await client.PostAsJsonAsync("api/Library", newItem);
                Console.WriteLine($"POST Status: {postResponse.StatusCode}");

                // GET by ID
                var itemById = await client.GetFromJsonAsync<LibraryItem>("api/Library/2");
                Console.WriteLine($"Item 1: {itemById?.Title}");

                // PUT (update)
                newItem.Title = "Updated Book Title";
                var putResponse = await client.PutAsJsonAsync("api/Library/3", newItem);
                Console.WriteLine($"PUT Status: {putResponse.StatusCode}");

                // DELETE
                //var deleteResponse = await client.DeleteAsync("api/Library/1");
                //Console.WriteLine($"DELETE Status: {deleteResponse.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
