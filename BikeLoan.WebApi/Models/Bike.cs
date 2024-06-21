namespace BikeLoan.WebApi.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BikeLoan")]
    public class Bike
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public byte[] BikeImage { get; set; }
        public Users Users { get; set; }
        public ICollection<Orders> Orders { get; set; } = new List<Orders>();

    }
}
