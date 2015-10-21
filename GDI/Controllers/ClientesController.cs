using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GDI.Models;

namespace GDI.Controllers {
    public class ClientesController : ApiController {

        private BancoDadosEntities db = new BancoDadosEntities();

        // GET: api/Clientes
        public IQueryable<cliente> Get() {
            return db.cliente;
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(cliente))]
        public async Task<IHttpActionResult> Getcliente(int id) {
            cliente cliente = await db.cliente.FindAsync(id);
            if (cliente == null) {
                return NotFound();
            }
            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcliente(int id, cliente cliente) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != cliente.idcliente) {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!clienteExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clientes
        [ResponseType(typeof(cliente))]
        public async Task<IHttpActionResult> Postcliente(cliente cliente) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.cliente.Add(cliente);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cliente.idcliente }, cliente);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(cliente))]
        public async Task<IHttpActionResult> Deletecliente(int id) {
            cliente cliente = await db.cliente.FindAsync(id);
            if (cliente == null) {
                return NotFound();
            }

            db.cliente.Remove(cliente);
            await db.SaveChangesAsync();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clienteExists(int id) {
            return db.cliente.Count(e => e.idcliente == id) > 0;
        }
    }
}