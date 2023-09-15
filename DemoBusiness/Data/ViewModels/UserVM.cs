using System.ComponentModel.DataAnnotations;

namespace DemoBusiness.Data.ViewModels
{
    
    public class UserVM
    {
        
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Special character should not be entered")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Maximum 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }
        
    }
}
