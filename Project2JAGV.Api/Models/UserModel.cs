using System.ComponentModel.DataAnnotations;


namespace Project2JAGV.Api.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public UserTypeModel UserType { get; set; }
        public AddressModel Address { get; set; }
    }
}
