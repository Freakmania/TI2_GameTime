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
using System.IO;

namespace GameTime.Controllers
{
    public class JogoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jogo
        public async Task<ActionResult> Index()
        {
            var jogo = db.Jogo.Include(j => j.EstadoJogo).Include(j => j.Genero);
            return View(await jogo.ToListAsync());
        }

        // GET: Jogo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
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

        // GET: Jogo/Create
        public ActionResult Create()
        {
            ViewBag.EstadoJogoFK = new SelectList(db.EstadoJogo, "Id", "Nome");
            ViewBag.GeneroJogo = new SelectList(db.Genero, "Id", "Nome");
            return View();
        }

        // POST: Jogo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Descricao,Capa,Editora,EstadoJogoFK,GeneroJogo")] Jogo jogo, HttpPostedFileBase uploadImagem)
        {
            if (ModelState.IsValid)
            {
                if (uploadImagem != null)
                {
                    uploadImagem.SaveAs(HttpContext.Server.MapPath("~/Imagens/") + uploadImagem.FileName);
                    jogo.Capa = uploadImagem.FileName;
                }
                db.Jogo.Add(jogo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoJogoFK = new SelectList(db.EstadoJogo, "Id", "Nome", jogo.EstadoJogoFK);
            ViewBag.GeneroJogo = new SelectList(db.Genero, "Id", "Nome", jogo.GeneroJogo);
            return View(jogo);
        }

        // GET: Jogo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = await db.Jogo.FindAsync(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoJogoFK = new SelectList(db.EstadoJogo, "Id", "Nome", jogo.EstadoJogoFK);
            ViewBag.GeneroJogo = new SelectList(db.Genero, "Id", "Nome", jogo.GeneroJogo);
            return View(jogo);
        }

        // POST: Jogo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Descricao,Capa,Editora,EstadoJogoFK,GeneroJogo")] Jogo jogo, HttpPostedFileBase uploadImagem)
        {
            if (ModelState.IsValid)
            {
                if (uploadImagem != null)
                {
                    uploadImagem.SaveAs(HttpContext.Server.MapPath("~/Images/") + uploadImagem.FileName);
                    jogo.Capa = uploadImagem.FileName;
                }
                db.Entry(jogo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoJogoFK = new SelectList(db.EstadoJogo, "Id", "Nome", jogo.EstadoJogoFK);
            ViewBag.GeneroJogo = new SelectList(db.Genero, "Id", "Nome", jogo.GeneroJogo);
            return View(jogo);
        }

        // GET: Jogo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
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

        // POST: Jogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Jogo jogo = await db.Jogo.FindAsync(id);
            db.Jogo.Remove(jogo);
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
