namespace BikeLoan.WebApi.Response
{
    public class OrderDetailsResponse
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string BikeName  { get; set; }
        public int BikeId { get; set; }
    }
}
