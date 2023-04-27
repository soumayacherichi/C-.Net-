using System.ComponentModel.DataAnnotations;

using System;



namespace CRUDelicious.Models

{

    public class Dish

    {

        [Key]

        public int DishId {get;set;}

        [Display(Name="Name of Dish")]

        [Required]

        public string Name {get;set;}

        [Display(Name="Chef's Name")]

        [Required]

        public string Chef {get;set;}

        [Required]

        [Range(1,5)]

        public int Tastiness {get;set;}

        [Range(1,Int32.MaxValue,ErrorMessage="Calories must be 1 or larger")]

        public int Calories {get;set;}

        public string Description {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }

}