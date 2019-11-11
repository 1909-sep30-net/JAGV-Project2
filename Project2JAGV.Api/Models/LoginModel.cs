using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.Api.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserPassword { get; set; }
    }
}
