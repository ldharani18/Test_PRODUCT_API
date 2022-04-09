using Product_API.Models;

namespace Product_API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {

            if (!context.Categories.Any())
            {
                List<Category> categoryList = new List<Category> {
                new Category()
                {
                   category_name="Mobile"
                },
                new Category()
                {
                   category_name="Laptop"
                },
                new Category()
                {
                   category_name="Television"
                },
                new Category()
                {
                   category_name="Refrigerator"
                }
            };
                context.Categories.AddRange(categoryList);
                context.SaveChanges();
            }

            if (!context.Brands.Any())
            {
                List<Brand> brandList = new List<Brand> {
                new Brand()
                {
                    brand_name="Redmi"
                },
                new Brand()
                {
                    brand_name="Dell"
                },
                new Brand()
                {
                    brand_name="Samsung"
                },
                new Brand()
                {
                    brand_name="Whirlpool"
                }
            };
                context.Brands.AddRange(brandList);
                context.SaveChanges();
            }
            if (!context.Suppliers.Any())
            {
                List<Supplier> supplierList = new List<Supplier>
            {
                new Supplier()
                {
                    supplier_name="Albert",
                    supplier_bulstat="10234324234",
                    supplier_address="Mumbai",
                    supplier_email="albert@gmail.com",
                    supplier_phone="1242423"
                },
                new Supplier()
                {
                    supplier_name="Bill",
                    supplier_bulstat="10234324687",
                    supplier_address="Chennai",
                    supplier_email="bill@gmail.com",
                    supplier_phone="3524131"
                }
            };
                context.Suppliers.AddRange(supplierList);
                context.SaveChanges();
            }
            /*if (!context.Inventories.Any())
            {
                List<Inventory> inventoryList = new List<Inventory>
                {
                    new Inventory()
                    {
                        stock_product_quantity=15
                    }
                };
                context.Inventories.AddRange(inventoryList);
                context.SaveChanges();
            }*/
            /*if (!context.Products.Any())
            {
                List<Product> productList = new List<Product>
                    {
                    new Product()
                    {
                        product_name="Redmi Note 4",
                        product_price=20000.00,
                        BrandId=1,
                        CategoryId=1,
                        SupplierId=1
                    }
                    };
                context.Products.AddRange(productList);
                context.SaveChanges();
            }*/


        }
    }
}
