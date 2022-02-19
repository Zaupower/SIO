using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickPC_Backend.Models;

namespace ClickPC_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly Context _context;

        public SuppliersController(Context context)
        {
            _context = context;
        }

     //Obter fornecedores
        [HttpGet]
        [Route("GetSuppliers")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            return await _context.Supplier.ToListAsync();
        }

        ///Obter fornecedor por id
        [HttpGet]
        [Route("GetSupplier")]
        public async Task<ActionResult<Supplier>> GetSupplier(string id)
        {
            var supplier = await _context.Supplier.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        /// Editar fornecedor
        [HttpPut]
        [Route("PutSupplier")]
        public async Task<IActionResult> PutSupplier(string id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            _context.Entry(supplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return NotFound();
                }
            }
            return NoContent();
        }

        /// Adicionar fornecedor
        [HttpPost]
        [Route("PostSupplier")]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            _context.Supplier.Add(supplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplier", new { id = supplier.Id }, supplier);
        }

        /// Eliminar fornecedor
        [HttpDelete]
        [Route("DeleteSupplier")]
        public async Task<ActionResult<Supplier>> DeleteSupplier(string id)
        {
            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.Supplier.Remove(supplier);
            await _context.SaveChangesAsync();

            return supplier;
        }

        private bool SupplierExists(string id)
        {
            return _context.Supplier.Any(e => e.Id == id);
        }
    }
}
