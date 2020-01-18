using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeddingOf.Models
{
    public class RsvpCreate
    {
        [Required]
        public string Names { get; set; }
        public int FoodTwo { get; set; }
        public int FoodOne { get; set; }
        public bool YayOrNay { get; set; }
        public string Comments { get; set; }
        public override string ToString() => Names;
    }
}
