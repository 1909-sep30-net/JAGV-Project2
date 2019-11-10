using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.Api.Models
{
    public class AddressModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }


        public string ZipCode { get; set; }
    }
}
