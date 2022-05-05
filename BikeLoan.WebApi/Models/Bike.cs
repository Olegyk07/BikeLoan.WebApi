namespace BikeLoan.WebApi.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BikeLoan")]
    public class Bike 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BikeID { get; set; }

        public string BikeName { get; set; }

        public string BikeColor { get; set; }

        public double BikePrice { get; set; }
    }
}
