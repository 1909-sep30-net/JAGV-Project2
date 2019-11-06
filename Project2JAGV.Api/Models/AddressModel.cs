using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2JAGV.Api.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
