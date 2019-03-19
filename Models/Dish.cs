using System;
using System.ComponentModel.DataAnnotations;

namespace chefsNdishes.Models
{
    public class Dish 
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]

        [Required]
        [Display(Name="Chef")]
        public int DishId {get;set;}

        [Required(ErrorMessage="Dish name required")]
        [Display(Name="Dish Name")]
        public string DishName {get;set;}

        [Required(ErrorMessage="Calories required")]
        [Display(Name="# of Calories")]
        [Range(1, 5000)]
        public int? Calories {get;set;}

        [Required(ErrorMessage="Enter a short description about the dish")]
        [Display(Name="Description")]
        public string Description {get;set;}

        [Display(Name="Tastiness")]
        public int Tastiness {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public int ChefId {get;set;}


        // One to many  relationship: navigation property
        public Chef Creator {get;set;}
        
       
    }


}