using Microsoft.EntityFrameworkCore;
using Product_API.Models;
using Product_API.Data;

namespace Product_API.Services
{
    public interface IBrandService
    {
        public Task<IEnumerable<Brand>> GetAllBrands();
        public Task<Brand> GetBrand(int id);
        public Task<Brand> AddBrand(Brand brand);
        public Task UpdateBrand(Brand brand);
        public Task DeleteBrand(int id);
    }
    public class BrandService : IBrandService
    {
        private readonly DatabaseContext _context;
        public BrandService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            var brands = await _context.Brands.ToListAsync();
            foreach (var b in brands)
            {
                b.Products = (from p in _context.Products where p.BrandId == b.Id select p).ToList();
            }
            brands.ForEach(b =>
            {
                foreach (var p in b.Products)
                {
                    p.Inventory = _context.Inventories.First(i => i.ProductId == p.Id);
                }
            });
            return brands;

        }
        public async Task<Brand> GetBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            brand.Products = _context.Products.Where(p => p.BrandId == brand.Id).ToList();
            foreach (var p in brand.Products)
            {
                p.Inventory = _context.Inventories.First(i => i.ProductId == p.Id);
            }
            if (brand != null)
            {
                return brand;
            }
            return null;
        }

        public async Task<Brand> AddBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }
        public async Task UpdateBrand(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
            }

        }

    }
}