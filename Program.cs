using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace JSON_Practice
{
    public class PublishingHouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        
        
        public PublishingHouse(int id, string name, string adress)
        {
            Id = id;
            Name = name;
            Adress = adress;
        }
        
    }

    public class Book
    {
        [JsonIgnore]
        public int PublishingHouseId { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "Name")]
        public string Title { get;}
        public PublishingHouse PublishingHouse { get; set; }

    
        public Book(int publishingHouseId, string title, PublishingHouse publishingHouse)
        {
            PublishingHouseId = publishingHouseId;
            Title = title;
            PublishingHouse = publishingHouse;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            
            string path = @"C:\Users\USER\RiderProjects\JSON\JSON\input.json";
            ///// Synchronous way
            // string text = File.ReadAllText(path);
            // var books = JsonSerializer.Deserialize<List<Book>>(text);
            
            ///// Asynchronous way
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);
                foreach (var book in books)
                {
                    Console.WriteLine(JsonSerializer.Serialize(book));    
                }

            }
        }
    }
}