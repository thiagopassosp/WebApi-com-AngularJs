using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GDI.Models;

namespace GDI.Controllers
{
    public class PedidoItensController : ApiController
    {
        private BancoDadosEntities db = new BancoDadosEntities();

        // GET: api/PedidoItens
        public IQueryable<pedido_itens> Getpedido_itens()
        {
            return db.pedido_itens;
        }

        // GET: api/PedidoItens/5
        [ResponseType(typeof(pedido_itens))]
        public async Task<IHttpActionResult> Getpedido_itens(int id)
        {
            pedido_itens pedido_itens = await db.pedido_itens.FindAsync(id);
            if (pedido_itens == null)
            {
                return NotFound();
            }

            return Ok(pedido_itens);
        }

        // PUT: api/PedidoItens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpedido_itens(int id, pedido_itens pedido_itens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido_itens.idpedido_itens)
            {
                return BadRequest();
            }

            db.Entry(pedido_itens).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pedido_itensExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PedidoItens
        [ResponseType(typeof(pedido_itens))]
        public async Task<IHttpActionResult> Postpedido_itens(pedido_itens pedido_itens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pedido_itens.Add(pedido_itens);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pedido_itens.idpedido_itens }, pedido_itens);
        }

        // DELETE: api/PedidoItens/5
        [ResponseType(typeof(pedido_itens))]
        public async Task<IHttpActionResult> Deletepedido_itens(int id)
        {
            pedido_itens pedido_itens = await db.pedido_itens.FindAsync(id);
            if (pedido_itens == null)
            {
                return NotFound();
            }

            db.pedido_itens.Remove(pedido_itens);
            await db.SaveChangesAsync();

            return Ok(pedido_itens);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pedido_itensExists(int id)
        {
            return db.pedido_itens.Count(e => e.idpedido_itens == id) > 0;
        }
    }
}