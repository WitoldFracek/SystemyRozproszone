using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientMVC.Models
{
    public class Book
    {
       public Book() { }
       public Book(int id, string title, string author, double price)
        {
            Id = id;
            Title = title;
            Author = author;
            Price = price;
        }

        [JsonProperty("Id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("Title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("Author")]
        public string Author { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter positive number")]
        [JsonProperty("Price")]
        public double Price { get; set; }
    }
}
