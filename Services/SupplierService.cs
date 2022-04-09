using Microsoft.EntityFrameworkCore;
using Product_API.Models;
using Product_API.Data;

namespace Product_API.Services
{
    public interface ISupplierService
    {
        public Task<IEnumerable<Supplier>> GetAllSuppliers();
        public Task<Supplier> GetSupplier(int id);
        public Task<Supplier> AddSupplier(Supplier supplier);
        public Task UpdateSupplier(Supplier supplier);
        public Task DeleteSupplier(int id);
       
    }
    public class SupplierService : ISupplierService
    {
        private readonly DatabaseContext _context;
        public SupplierService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            foreach (var s in suppliers)
            {
                s.Products = (from p in _context.Products where p.SupplierId == s.Id select p).ToList();
            }
            suppliers.ForEach(s =>
            {
                foreach (var p in s.Products)
                {
                    p.Inventory = _context.Inventories.First(i => i.ProductId == p.Id);
                }
            });
            return suppliers;

        }
        public async Task<Supplier> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            supplier.Products = _context.Products.Where(p => p.SupplierId == supplier.Id).ToList();
            foreach (var p in supplier.Products)
            {
                p.Inventory = _context.Inventories.First(i => i.ProductId == p.Id);
            }
            if (supplier != null)
            {
                return supplier;
            }
            return null;
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSupplier(int id)
        {
            var supplier = await _context.Products.FindAsync(id);
            if (supplier != null)
            {
                _context.Products.Remove(supplier);
                await _context.SaveChangesAsync();
            }

        }

    }
}