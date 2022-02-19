using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickPC_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClickPC_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinesInvoicesController : ControllerBase
    {
        private readonly Context _context;

        public LinesInvoicesController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetLineInvoice")]
        public async Task<ActionResult<IEnumerable<LineInvoice>>> GetInvoiceLines()
        {
            return await _context.LineInvoice.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetLinesInvoice")]
        public async Task<ActionResult<LineInvoice>> GetInvoiceLine(string id)
        {
            var invoiceLine = await _context.LineInvoice.FindAsync(id);

            if (invoiceLine == null)
            {
                return NotFound();
            }

            return invoiceLine;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="invoiceLine"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("PutLinesInvoice")]
        public async Task<IActionResult> PutInvoiceLine(string id, LineInvoice lineInvoice)
        {
            if (id != lineInvoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(lineInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceLineExists(id))
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
        /// 
        /// </summary>
        /// <param name="invoiceLine"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostLinesInvoice")]
        public async Task<ActionResult<LineInvoice>> PostInvoiceLine(LineInvoice invoiceLine)
        {
            _context.LineInvoice.Add(invoiceLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceLine", new { id = invoiceLine.Id }, invoiceLine);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteInvoiceLine")]
        public async Task<ActionResult<LineInvoice>> DeleteInvoiceLine(string id)
        {
            var lineInvoice = await _context.LineInvoice.FindAsync(id);
            if (lineInvoice == null)
            {
                return NotFound();
            }

            _context.LineInvoice.Remove(lineInvoice);
            await _context.SaveChangesAsync();

            return lineInvoice;
        }

        private bool InvoiceLineExists(string id)
        {
            return _context.LineInvoice.Any(e => e.Id == id);
        }
    }
}
