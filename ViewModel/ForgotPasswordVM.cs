using System.ComponentModel.DataAnnotations;

namespace BTickets.ViewModel
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
