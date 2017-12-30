using portfio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace portfio.Controllers.Admin
{
    public class WorksController : Controller
    {
        AdoModel db = new AdoModel();
        // GET: Works
        public ActionResult Index()
        {
            return View(db.PortfolioWorks.ToList());
        }


        public ActionResult Create()
        {
            Works work = new Works { Title = "", Info = "", Link = "http://placehold.it/800x600" };
            List<SelectListItem> items = LoadItems();
            ViewBag.Topics = items;
            return View(work);
        }

        private List<SelectListItem> LoadItems()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (Topics top in db.PortfolioTopics.ToList())
                items.Add(new SelectListItem { Text = top.Name, Value = top.Id.ToString() });
            return items;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( [Bind(Include = "Id, Title, Info, Link, Topics_Id")] Works works)
        {
            if (ModelState.IsValid)
            {
                db.PortfolioWorks.Add(works);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> items = LoadItems();
            ViewBag.Topics = items;
            return View();
        }

        public ActionResult Edit( int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<SelectListItem> items = LoadItems();
            ViewBag.Topics = items;

            Works work = db.PortfolioWorks.Find(id);
            return View(work);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id,Title,Info,Link,Topics_Id")]Works work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Works");
            }
            List<SelectListItem> items = LoadItems();
            ViewBag.Topics = items;
            return View(work);

        }

        public ActionResult Details(int? id)
        {
            if (id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Works work = db.PortfolioWorks.Find(id);

            return View(work);
        }

        public ActionResult Upload(HttpPostedFileBase upload, int id, string submitButton)
        {
            Works work = db.PortfolioWorks.Find(id);
            if (submitButton != null)
            {
                string[] submitButtons = submitButton.Split('_');
                switch (submitButtons[0])
                {
                    case "MainPhoto":
                        MainPhoto(work, submitButtons);
                        break;
                    case "DeletePhoto":
                        DeletePhoto(submitButtons);
                        break;
                }
            }

            else if (upload != null)
            {
                UploadPhoto(upload, id);

            }
            return View("Details",work);
        }

        private void UploadPhoto(HttpPostedFileBase upload, int id)
        {
            Photos photo = new Photos()
            {
                Works_Id = id,
                Link = "http://",
                Info = ""
            };

            db.PortfolioPhotos.Add(photo);
            db.SaveChanges();

            string fileName = System.IO.Path.GetFileName(upload.FileName); // путь к файлу лок диск
            string ex = System.IO.Path.GetExtension(upload.FileName); //расширение файла

            string link_photo = "~/Images/" + photo.Id + ex;
            upload.SaveAs(Server.MapPath(link_photo));
            photo.Link = Url.Content(link_photo);

            db.Entry(photo).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        private void MainPhoto(Works work, string[] submitButtons)
        {
            Photos photo_search = db.PortfolioPhotos.Find(Int32.Parse(submitButtons[1]));
            work.Link = photo_search.Link;
            db.Entry(work).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        private void DeletePhoto(string[] submitButtons)
        {
            Photos photo_search = db.PortfolioPhotos.Find(Int32.Parse(submitButtons[1]));
            if(System.IO.File.Exists(Server.MapPath(photo_search.Link)))
                System.IO.File.Delete(Server.MapPath(photo_search.Link));
            db.PortfolioPhotos.Remove(photo_search);
            db.SaveChanges();
        }

        [ChildActionOnly]
        public ActionResult ViewPhoto(int id)
        {
            var allPhotos = db.PortfolioPhotos.Where(p => p.Works_Id == id);
            return PartialView("Photos", allPhotos);
        }

        [ChildActionOnly]
        public ActionResult Social()
        {
            return PartialView("_FooterSocial", db.PortfolioSocialLinks.ToList());
        }
    }
}