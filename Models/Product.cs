using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? product_name { get; set; }

        [Display(Name = "product_brand")]
        public int BrandId { get; set; }

        //public Brand Brand { get; set; }

        [Display(Name = "product_supplier")]
        public int SupplierId { get; set; }
       //public Supplier Supplier { get; set; }

        [Display(Name = "product_category")]
        public int CategoryId { get; set; }
        //public Category Category { get; set; }
        [DataType(DataType.Currency)]
        public double product_price { get; set; }

        public virtual Inventory Inventory { get; set; }

    }
}
