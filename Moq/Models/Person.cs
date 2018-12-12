using System.ComponentModel.DataAnnotations;

namespace MoqSample.Models
{
    public class Person
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "first name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "last name is required")]
        public string LastName { get; set; }

        [Display(Name = "Type")]        
        public bool Manager { get; set; }
    }
}