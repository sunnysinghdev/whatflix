using System;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
namespace WhatFlix.Domain.Model
{
    public class Movie
    {
        [Name("id")]
        public int Id {get; set;}
        [Name("title")]
        public string Title { get; set; }
        // public string Director { get; set; }
        // public string Actor { get; set; }
        // public string Language { get; set; }
    }
}