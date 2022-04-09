using System.ComponentModel.DataAnnotations;

namespace Product_API.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string category_name { get; set;}
        public virtual ICollection<Product> Products { get; set; }
    }
}
