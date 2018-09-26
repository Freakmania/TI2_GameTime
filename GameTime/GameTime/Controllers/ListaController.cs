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
using Microsoft.AspNet.Identity;

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
            //Lista lista = db.Lista.Find(UtilizadorFK, JogoFK);
            //if (lista == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "UtilizadorFK", "Utilizador", lista.UtilizadorFK);
            //ViewBag.UtilizadorFK = new SelectList(db.Jogo, "JogoFK", "Jogo", lista.Jogo);
            //return View(lista);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = await db.Jogo.FindAsync(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Lista/Create
        public ActionResult Create()
        {
            ViewBag.EstadoJogadorFK = new SelectList(db.EstadoJogador, "Id", "Nome");
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

            // perguntar à BD qual o ID do jogador autenticado
            // User.Identity.Name devolve o userName da pessoa autenticada

            ViewBag.UtilizadorFK = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                //if (User.IsInRole("Admin"))
                //{
                    db.Lista.Add(lista);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                //}
                //else
                //{
                //    db.Lista.Add(lista);
                //    //ViewBag.UtilizadorFK = User.Identity.GetUserId();
                //    //ViewBag.JogoFK=
                //    await db.SaveChangesAsync();
                //    return RedirectToAction("Index");
                //}
                
            }

            ViewBag.EstadoJogadorFK = new SelectList(db.EstadoJogador, "Id", "Nome", lista.EstadoJogadorFK);
            ViewBag.JogoFK = new SelectList(db.Jogo, "Id", "Nome", lista.JogoFK);
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "Id", "NomeUtilizador", lista.UtilizadorFK);
            return View(lista);
        }

        // GET: Lista/Edit/5
        public ActionResult Edit(int UtilizadorFK, int JogoFK)
        {
            Lista lista = db.Lista.Find(UtilizadorFK, JogoFK);
            if (lista == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "UtilizadorFK", "Utilizador", lista.UtilizadorFK);
            ViewBag.UtilizadorFK = new SelectList(db.Jogo, "JogoFK", "Jogo", lista.Jogo);
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
                int OUtilizadorFK = Convert.ToInt32(Request["UtilizadorFK"]);
                int OJogoFK = Convert.ToInt32(Request["JogoFK"]);

                var services = db.Lista.Where(a => a.UtilizadorFK == OUtilizadorFK).Where(a => a.JogoFK == OJogoFK);

                foreach (var s in services)
                {
                    db.Lista.Remove(s);
                }

                db.Lista.Add(lista);
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("Index");
                }
                db.Entry(lista).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoJogadorFK = new SelectList(db.EstadoJogador, "Id", "Nome", lista.EstadoJogadorFK);
            ViewBag.JogoFK = new SelectList(db.Jogo, "Id", "Nome", lista.JogoFK);
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "Id", "NomeUtilizador", lista.UtilizadorFK);
            return View(lista);
        }

        // GET: Lista/Delete/5
        public ActionResult Delete(int UtilizadorFK, int JogoFK)
        {
            Lista lista = db.Lista.Find(UtilizadorFK, JogoFK);
            if (lista == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "UtilizadorFK", "Utilizador", lista.UtilizadorFK);
            ViewBag.UtilizadorFK = new SelectList(db.Jogo, "JogoFK", "Jogo", lista.Jogo);
            return View(lista);
        }

        // POST: Lista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int UtilizadorFK, int JogoFK)
        {
            Lista lista = await db.Lista.FindAsync(UtilizadorFK, JogoFK);
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
