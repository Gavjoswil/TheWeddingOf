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
        [Key]
        public int RsvpId { get; set; }
        [Display(Name ="Name")]
        public string Names { get; set; }



        public override string ToString() => Names;
    }
}
