using System.ComponentModel.DataAnnotations;

namespace BTickets.ViewModel
{
    public class LoginVM
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        
       public bool RememberMe { get; set; }
    }
}
