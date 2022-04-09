#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_API.Data;
using Product_API.Models;
using Product_API.Services;

namespace Product_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _services;
        public BrandsController(IBrandService services)
        {
            _services = services;
        }


        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Brand>> GetBrand()
        {
            return await _services.GetAllBrands();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            return await _services.GetBrand(id);
        }

        //// PUT: api/Questions/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, Brand brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }
            await _services.UpdateBrand(brand);
            return NoContent();
        }

        //// POST: api/Questions
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostBrand(Brand brand)
        {
            var newBrand = await _services.AddBrand(brand);
            return CreatedAtAction(nameof(GetBrand), new { id = newBrand.Id }, newBrand);

        }

        //// DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _services.GetBrand(id);
            if (brand == null)
            {
                return NotFound();
            }
            await _services.DeleteBrand(id);
            return NoContent();
        }
        /* private readonly DatabaseContext _context;

         public BrandsController(DatabaseContext context)
         {
             _context = context;
         }

         // GET: api/Brands
         [HttpGet]
         public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
         {
             return await _context.Brands.ToListAsync();
         }

         // GET: api/Brands/5
         [HttpGet("{id}")]
         public async Task<ActionResult<Brand>> GetBrand(int id)
         {
             var brand = await _context.Brands.FindAsync(id);

             if (brand == null)
             {
                 return NotFound();
             }

             return brand;
         }

         // PUT: api/Brands/5
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPut("{id}")]
         public async Task<IActionResult> PutBrand(int id, Brand brand)
         {
             if (id != brand.Id)
             {
                 return BadRequest();
             }

             _context.Entry(brand).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!BrandExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
         }

         // POST: api/Brands
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
         public async Task<ActionResult<Brand>> PostBrand(Brand brand)
         {
             _context.Brands.Add(brand);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
         }

         // DELETE: api/Brands/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteBrand(int id)
         {
             var brand = await _context.Brands.FindAsync(id);
             if (brand == null)
             {
                 return NotFound();
             }

             _context.Brands.Remove(brand);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool BrandExists(int id)
         {
             return _context.Brands.Any(e => e.Id == id);
         }*/
    }
}
