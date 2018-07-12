using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameTime.Models;

namespace GameTime.Controllers
{
    public class ListaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lista
        public async Task<ActionResult> Index()
        {
            var lista = db.Lista.Include(l => l.EstadoJogador).Include(l => l.Jogo).Include(l => l.Utilizador);
            return View(await lista.ToListAsync());
        }

        // GET: Lista/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = await db.Lista.FindAsync(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            return View(lista);
        }

        // GET: Lista/Create
        public ActionResult Create()
        {
            ViewBag.EstadoJogadorFK = new SelectList(db.EstadoJogo, "Id", "Nome");
            ViewBag.JogoFK = new SelectList(db.Jogo, "Id", "Nome");
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "Id", "NomeUtilizador");
            return View();
        }

        // POST: Lista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UtilizadorFK,JogoFK,EstadoJogadorFK")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                db.Lista.Add(lista);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoJogadorFK = new SelectList(db.EstadoJogo, "Id", "Nome", lista.EstadoJogadorFK);
            ViewBag.JogoFK = new SelectList(db.Jogo, "Id", "Nome", lista.JogoFK);
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "Id", "NomeUtilizador", lista.UtilizadorFK);
            return View(lista);
        }

        // GET: Lista/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = await db.Lista.FindAsync(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoJogadorFK = new SelectList(db.EstadoJogo, "Id", "Nome", lista.EstadoJogadorFK);
            ViewBag.JogoFK = new SelectList(db.Jogo, "Id", "Nome", lista.JogoFK);
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "Id", "NomeUtilizador", lista.UtilizadorFK);
            return View(lista);
        }

        // POST: Lista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UtilizadorFK,JogoFK,EstadoJogadorFK")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoJogadorFK = new SelectList(db.EstadoJogo, "Id", "Nome", lista.EstadoJogadorFK);
            ViewBag.JogoFK = new SelectList(db.Jogo, "Id", "Nome", lista.JogoFK);
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "Id", "NomeUtilizador", lista.UtilizadorFK);
            return View(lista);
        }

        // GET: Lista/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = await db.Lista.FindAsync(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            return View(lista);
        }

        // POST: Lista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lista lista = await db.Lista.FindAsync(id);
            db.Lista.Remove(lista);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
