namespace amazen_server.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string CreatorId { get; set; }
    }
}