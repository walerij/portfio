using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using portfio.Models;

namespace portfio.Controllers.Admin
{
    public class TopicsController : Controller
    {
        private AdoModel db = new AdoModel();

        // GET: Topics
        public async Task<ActionResult> Index()
        {
            return View(await db.PortfolioTopics.ToListAsync());
        }

        // GET: Topics/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topics topics = await db.PortfolioTopics.FindAsync(id);
            if (topics == null)
            {
                return HttpNotFound();
            }
            return View(topics);
        }

        // GET: Topics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Info")] Topics topics)
        {
            if (ModelState.IsValid)
            {
                db.PortfolioTopics.Add(topics);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(topics);
        }

        // GET: Topics/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topics topics = await db.PortfolioTopics.FindAsync(id);
            if (topics == null)
            {
                return HttpNotFound();
            }
            return View(topics);
        }

        // POST: Topics/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Info")] Topics topics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topics).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(topics);
        }

        // GET: Topics/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topics topics = await db.PortfolioTopics.FindAsync(id);
            if (topics == null)
            {
                return HttpNotFound();
            }
            return View(topics);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Topics topics = await db.PortfolioTopics.FindAsync(id);
            db.PortfolioTopics.Remove(topics);
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

        [ChildActionOnly]
        public ActionResult Social()
        {
            return PartialView("_FooterSocial", db.PortfolioSocialLinks.ToList());
        }
    }
}
