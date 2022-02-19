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
    public class InvoicesController : ControllerBase
    {
        private readonly Context _context;

        public InvoicesController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Rota para buscar todas as faturas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInvoices")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            return await _context.Invoice.ToListAsync();
        }

        /// <summary>
        /// Rota para buscar uma fatura através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInvoice")]
        public async Task<ActionResult<Invoice>> GetInvoice(string id)
        {
            var invoice = await _context.Invoice.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        /// <summary>
        /// Rota para atualizar uma fatura (apesar de nao fazer muito sentido)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="invoice"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("PutInvoice")]
        public async Task<IActionResult> PutInvoice(string id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
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

        /// <summary>
        /// Rota para adicionar uma fatura
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostInvoice")]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            _context.Invoice.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = invoice.Id }, invoice);
        }

        /// <summary>
        /// Rota para eliminar uma fatura (apesar de nao fazer muito sentido)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteInvoice")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(string id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }

        private bool InvoiceExists(string id)
        {
            return _context.Invoice.Any(e => e.Id == id);
        }
    }
}
