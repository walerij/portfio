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
    public class SocialLinksController : Controller
    {
        private AdoModel db = new AdoModel();

        // GET: SocialLinks
        public async Task<ActionResult> Index()
        {
            return View(await db.PortfolioSocialLinks.ToListAsync());
        }

        // GET: SocialLinks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialLinks socialLinks = await db.PortfolioSocialLinks.FindAsync(id);
            if (socialLinks == null)
            {
                return HttpNotFound();
            }
            return View(socialLinks);
        }

        // GET: SocialLinks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialLinks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Img_name,Link,Title")] SocialLinks socialLinks)
        {
            if (ModelState.IsValid)
            {
                db.PortfolioSocialLinks.Add(socialLinks);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(socialLinks);
        }

        // GET: SocialLinks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialLinks socialLinks = await db.PortfolioSocialLinks.FindAsync(id);
            if (socialLinks == null)
            {
                return HttpNotFound();
            }
            return View(socialLinks);
        }

        // POST: SocialLinks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Img_name,Link,Title")] SocialLinks socialLinks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialLinks).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(socialLinks);
        }

        // GET: SocialLinks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialLinks socialLinks = await db.PortfolioSocialLinks.FindAsync(id);
            if (socialLinks == null)
            {
                return HttpNotFound();
            }
            return View(socialLinks);
        }

        // POST: SocialLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SocialLinks socialLinks = await db.PortfolioSocialLinks.FindAsync(id);
            db.PortfolioSocialLinks.Remove(socialLinks);
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
