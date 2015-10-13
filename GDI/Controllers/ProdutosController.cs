using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GDI.Models;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace GDI.Controllers {
    public class ProdutosController : ApiController {
        private BancoDadosEntities db = new BancoDadosEntities();

        // GET: api/Produtos
        public IQueryable<produto> Getproduto() {
            return db.produto;
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(produto))]
        public async Task<IHttpActionResult> Getproduto(int id) {
            produto produto = await db.produto.FindAsync(id);
            if (produto == null) {
                return NotFound();
            }
            return Ok(produto);
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putproduto(int id, produto produto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != produto.idproduto) {
                return BadRequest();
            }

            db.Entry(produto).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!produtoExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produtos
        [ResponseType(typeof(produto))]
        public async Task<IHttpActionResult> Postproduto(produto produto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.produto.Add(produto);
            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = produto.idproduto }, produto);
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(produto))]
        public async Task<IHttpActionResult> Deleteproduto(int id) {
            produto produto = await db.produto.FindAsync(id);
            if (produto == null) {
                return NotFound();
            }

            db.produto.Remove(produto);
            await db.SaveChangesAsync();
            return Ok(produto);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool produtoExists(int id) {
            return db.produto.Count(e => e.idproduto == id) > 0;
        }
    }
}