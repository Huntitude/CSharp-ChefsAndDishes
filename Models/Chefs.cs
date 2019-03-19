using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace chefsNdishes.Models
{
    public class Chef 
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int ChefId {get;set;}

        [Required(ErrorMessage = "First name required")]
        [Display(Name="First Name")]
        public string FirstName {get;set;}

        [Required(ErrorMessage = "First name required")]
        [Display(Name="Last Name")]
        public string LastName {get;set;}

        [Required(ErrorMessage="Date of Birth required")]
        [Display(Name="Date of Birth")]
        [Column(TypeName="date")]
        [DataType(DataType.Date)]
        public DateTime Dob {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // Navigation property for related Dish objects
        public List<Dish> CreatedDish {get;set;}


    }


}