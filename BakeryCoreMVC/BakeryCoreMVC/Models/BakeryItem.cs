namespace BakeryCoreMVC.Models
{
    public class BakeryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
