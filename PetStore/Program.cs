using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;


namespace PetStore
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var pets = await GetPets();
            var sortedPets = sortPets(pets);

            WritePets(sortedPets);
        }

        // Makes api call and returns list of available pets.
        public static async Task<List<Pet>> GetPets()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var streamTask = client.GetStreamAsync("https://petstore.swagger.io/v2/pet/findByStatus?status=available");
            var pets = await JsonSerializer.DeserializeAsync<List<Pet>>(await streamTask);

            return pets;
        }

        // Sorts Pets by category and reverse order by name. 
        public static List<Pet> sortPets(List<Pet> pets)
        {
            var sortedPets = pets.OrderBy(p => p.Category?.Name)
                 .ThenByDescending(p => p.Name).ToList();
            return sortedPets;
        }

        // Writes pets to output.
        public static void WritePets(List<Pet> pets)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine("Name: " + pet.Name);
                Console.WriteLine("Category Id: " + (pet.Category?.Id));
                Console.WriteLine("Category Name: " + (pet.Category?.Name));

                Console.WriteLine("Photo Urls: ");
                foreach (var urls in pet.PhotoUrl ?? Enumerable.Empty<string>())
                {
                    Console.WriteLine("\t" + urls);
                }

                Console.WriteLine("Tags: ");
                foreach (var tag in pet.Tags ?? Enumerable.Empty<Tags>())
                {
                    Console.WriteLine("\t Id: " + tag.Id);
                    Console.WriteLine("\t Name: " + tag.Name);
                }

                Console.WriteLine("Status: " + pet.Status);

                Console.WriteLine();
            }
        }

    }
}
