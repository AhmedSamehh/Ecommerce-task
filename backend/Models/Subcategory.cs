#nullable disable
namespace ecommerce_task.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
    }
}
