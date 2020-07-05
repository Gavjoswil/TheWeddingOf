using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeddingOf.Models
{
    public class RsvpEdit
    {
        public string Names { get; set; }
        [Key]
        public int RsvpId { get; set; }
        public int FoodTwo { get; set; }
        [Display(Name = "Food Options")]
        public int FoodOne { get; set; }
        [Display(Name ="RSVP")]
        public bool YayOrNay { get; set; }
        public string Comments { get; set; }
        public override string ToString() => Comments;
    }
}
