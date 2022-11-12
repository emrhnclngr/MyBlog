using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BlogÖdev.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
