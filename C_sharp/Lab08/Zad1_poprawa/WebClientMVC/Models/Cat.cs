using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebClientMVC.Models
{
    public class Cat
    {
        public Cat() { }
        public Cat(int id, string name, string breed, int age, char sex)
        {
            Id = id;
            Name = name;
            Breed = breed;
            Age = age;
            Sex = sex;
        }

        [JsonProperty("Id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("Breed")]
        public string Breed { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter positive number")]
        [JsonProperty("Age")]
        public int Age { get; set; }

        [Required]
        [JsonProperty("Sex")]
        public char Sex { get; set; }
    }
}
