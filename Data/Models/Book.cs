using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Desc { get; set; }
        public bool IsFavorite { get; set; }
        public uint Quantity { get; set; }
        public string Img { get; set; }
        public Genre Genre { get; set; }
    }
}
