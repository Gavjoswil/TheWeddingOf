using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeddingOf.Data
{
    public class Rsvp
    {
        [Key]
        public int RsvpId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]
        public int FoodTwo { get; set; }
        [Required]
        public int FoodOne { get; set; }
    }
}
