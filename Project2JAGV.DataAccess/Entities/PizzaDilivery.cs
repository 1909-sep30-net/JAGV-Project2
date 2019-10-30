using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class PizzaDelivery
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Drivers Driver { get; set; }
    }
}
