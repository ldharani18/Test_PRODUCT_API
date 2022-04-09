using System.ComponentModel.DataAnnotations;

namespace Product_API.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string? supplier_name { get; set; }
        public string? supplier_bulstat { get; set; }
        public string? supplier_address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? supplier_email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? supplier_phone { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
