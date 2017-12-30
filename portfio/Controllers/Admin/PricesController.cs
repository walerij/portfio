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
    public class PricesController : Controller
    {
        private AdoModel db = new AdoModel();

        // GET: Prices
        public async Task<ActionResult> Index()
        {
            return View(await db.PortfolioPrices.ToListAsync());
        }

        // GET: Prices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prices prices = await db.PortfolioPrices.FindAsync(id);
            if (prices == null)
            {
                return HttpNotFound();
            }
            return View(prices);
        }

        // GET: Prices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prices/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Unit,Price")] Prices prices)
        {
            if (ModelState.IsValid)
            {
                db.PortfolioPrices.Add(prices);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(prices);
        }

        // GET: Prices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prices prices = await db.PortfolioPrices.FindAsync(id);
            if (prices == null)
            {
                return HttpNotFound();
            }
            return View(prices);
        }

        // POST: Prices/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Unit,Price")] Prices prices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prices).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(prices);
        }

        // GET: Prices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prices prices = await db.PortfolioPrices.FindAsync(id);
            if (prices == null)
            {
                return HttpNotFound();
            }
            return View(prices);
        }

        // POST: Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Prices prices = await db.PortfolioPrices.FindAsync(id);
            db.PortfolioPrices.Remove(prices);
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
