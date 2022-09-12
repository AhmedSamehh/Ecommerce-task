#nullable disable
namespace ecommerce_task.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}
