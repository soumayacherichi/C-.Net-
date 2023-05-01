using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        [Key]
        public int WeddingId { get; set; }

        [Required]
        [Display(Name="Wedder One")]
        [MinLength(3,ErrorMessage ="You must specify the name")] 
        public string WedderOne { get; set; }
        
        [Required]
        [Display(Name="Wedder Two")]
        [MinLength(3,ErrorMessage ="You must specify the name")] 
        public string WedderTwo { get; set; }

        [Required]
        [Display(Name="Date")]
        public DateTime WeddingDate { get; set; }

        [Required]
        [Display(Name="Wedding Address")]
        [MinLength(3,ErrorMessage ="You must specify the Date")] 
        public string WeddingAddress { get; set; }
        public int? CreatorId { get; set; }

        public List<WeddingMap> Guests { get; set; }

        public Wedding()
        {
            Guests = new List<WeddingMap>();
        }
    }
}
