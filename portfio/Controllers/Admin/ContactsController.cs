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
    public class ContactsController : Controller
    {
        private AdoModel db = new AdoModel();

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            return View(await db.PortfolioContacts.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = await db.PortfolioContacts.FindAsync(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Param,Value")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.PortfolioContacts.Add(contacts);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contacts);
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = await db.PortfolioContacts.FindAsync(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contacts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Param,Value")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacts).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contacts);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = await db.PortfolioContacts.FindAsync(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contacts contacts = await db.PortfolioContacts.FindAsync(id);
            db.PortfolioContacts.Remove(contacts);
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
