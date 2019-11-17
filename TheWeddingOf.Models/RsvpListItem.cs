using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeddingOf.Models
{
    public class RsvpListItem
    {
        public string Names { get; set; }
        [Display(Name="Spaghetti")]
        public int FoodTwo { get; set; }
        [Display(Name="Ravioli")]
        public int FoodOne { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
