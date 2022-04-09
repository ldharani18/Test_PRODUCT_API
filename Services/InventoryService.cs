using Microsoft.EntityFrameworkCore;
using Product_API.Models;
using Product_API.Data;

namespace Product_API.Services
{
    public interface IInventoryService
    {
        public Task<IEnumerable<Inventory>> GetAllInventories();
        public Task<Inventory> GetInventory(int id);
        public Task<Inventory> AddInventory(Inventory inventory);
        public Task UpdateInventory(Inventory inventory);
        public Task DeleteInventory(int id);

    }
    public class InventoryService : IInventoryService
    {
        private readonly DatabaseContext _context;
        public InventoryService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Inventory>> GetAllInventories()
        {
            return await _context.Inventories.ToListAsync();

        }
        public async Task<Inventory> GetInventory(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory != null)
            {
                return inventory;
            }
            return null;
        }

        public async Task<Inventory> AddInventory(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task UpdateInventory(Inventory inventory)
        {
            _context.Entry(inventory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteInventory(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
                await _context.SaveChangesAsync();
            }

        }

    }
}