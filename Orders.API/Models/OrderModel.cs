namespace Orders.API.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public float Total { get; set; }
    }
}
