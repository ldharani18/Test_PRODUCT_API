using System.ComponentModel.DataAnnotations;

namespace Product_API.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string brand_name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
