﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebClientMVC.Models
{
    public class Movie
    {
        public Movie() { }
        public Movie(int id, string title, int length, string director)
        {
            Id = id;
            Title = title;
            Length = length;
            Director = director;
        }

        [JsonProperty("Id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("Title")]
        public string Title { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter positive number")]
        [JsonProperty("Length")]
        public int Length { get; set; }

        [Required]
        [JsonProperty("Director")]
        public string Director { get; set; }
    }
}
