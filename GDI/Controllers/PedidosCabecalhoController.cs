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
    public class PedidosCabecalhoController : ApiController {
        private BancoDadosEntities db = new BancoDadosEntities();

        // GET: api/PedidoCabecalho
        public IQueryable<pedido_cabecalho> Getpedido_cabecalho() {
            return db.pedido_cabecalho;
        }

        // GET: api/PedidoCabecalho/5
        [ResponseType(typeof(pedido_cabecalho))]
        public async Task<IHttpActionResult> Getpedido_cabecalho(int id) {
            pedido_cabecalho pedido_cabecalho = await db.pedido_cabecalho.FindAsync(id);
            if (pedido_cabecalho == null) {
                return NotFound();
            }

            return Ok(pedido_cabecalho);
        }

        // PUT: api/PedidoCabecalho/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpedido_cabecalho(int id, pedido_cabecalho pedido_cabecalho) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != pedido_cabecalho.idpedido_cabecalho) {
                return BadRequest();
            }

            db.Entry(pedido_cabecalho).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!pedido_cabecalhoExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PedidoCabecalho
        [ResponseType(typeof(pedido_cabecalho))]
        public async Task<IHttpActionResult> Postpedido_cabecalho(pedido_cabecalho pedido_cabecalho) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.pedido_cabecalho.Add(pedido_cabecalho);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pedido_cabecalho.idpedido_cabecalho }, pedido_cabecalho);
        }

        // DELETE: api/PedidoCabecalho/5
        [ResponseType(typeof(pedido_cabecalho))]
        public async Task<IHttpActionResult> Deletepedido_cabecalho(int id) {
            pedido_cabecalho pedido_cabecalho = await db.pedido_cabecalho.FindAsync(id);
            if (pedido_cabecalho == null) {
                return NotFound();
            }

            db.pedido_cabecalho.Remove(pedido_cabecalho);
            await db.SaveChangesAsync();

            return Ok(pedido_cabecalho);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pedido_cabecalhoExists(int id) {
            return db.pedido_cabecalho.Count(e => e.idpedido_cabecalho == id) > 0;
        }
    }
}