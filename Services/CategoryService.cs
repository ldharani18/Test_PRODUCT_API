using Microsoft.EntityFrameworkCore;
using Product_API.Data;
using Product_API.Models;

namespace Product_API.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task<Category> GetCategory(int id);
        public Task<Category> AddCategory(Category category);
        public Task DeleteCategory(int id);
        public Task UpdateCategory(Category category);

    }
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _context;
        public CategoryService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            foreach (var c in categories)
            {
                c.Products = (from p in _context.Products where p.CategoryId == c.Id select p).ToList();
            }
            categories.ForEach(c =>
            {
                foreach (var p in c.Products)
                {
                    p.Inventory = _context.Inventories.First(i => i.ProductId == p.Id);
                }
            });
            return categories;

        }
        public async Task<Category> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            category.Products = _context.Products.Where(p => p.CategoryId == category.Id).ToList();
            foreach (var p in category.Products)
            {
                p.Inventory = _context.Inventories.First(i => i.ProductId == p.Id);
            }
            if (category != null)
            {
                return category;
            }
            return null;
        }

        public async Task<Category> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }

        }

    }
}