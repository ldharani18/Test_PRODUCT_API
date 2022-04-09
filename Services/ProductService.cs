using Microsoft.EntityFrameworkCore;
using Product_API.Models;
using Product_API.Data;

namespace Product_API.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProduct(int id);
        public Task<Product> AddProduct(Product product);
        public Task UpdateProduct(Product product);
        public Task DeleteProduct(int id);

    }
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;
        public ProductService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var productList= await _context.Products.ToListAsync();
            productList.ForEach(async product => product.Inventory = _context.Inventories.First(i => i.ProductId == product.Id));
            return productList;

        }
        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            product.Inventory = _context.Inventories.First(i => i.ProductId == product.Id);
            if (product != null)
            {
                return product;
            }
            return null;
        }
        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

        }

    }
}