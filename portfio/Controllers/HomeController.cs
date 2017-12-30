using portfio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portfio.Controllers
{
    public class HomeController : Controller
    {
        AdoModel db = new AdoModel();
        
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<Works> works = db.PortfolioWorks.OrderByDescending(w=>w.Id).Take(6);
            return View(works);
        }
        public ActionResult Works(int? id)
        {
            IEnumerable<Topics> topics = db.PortfolioTopics.ToList();
            if (id == null)
                ViewBag.TopicId = 1;
            else
                ViewBag.TopicId = id;
            return View(topics);
        }

        public ActionResult Price()
        {
            return View(db.PortfolioPrices.ToList());
        }

        public ActionResult Contacts()
        {
            return View(db.PortfolioContacts.ToList());
        }


        public ActionResult ViewWork(int? id)
        {
            Works work;
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            work = db.PortfolioWorks.Find(id);

            return View(work);
        }


		public ActionResult ViewPicture(int id)
		{
			Photos ph = db.PortfolioPhotos.FirstOrDefault(photo => photo.Id == id);
			if (ph != null)
				return PartialView("ViewPictureResult", ph);
			return HttpNotFound();
		}

        [ChildActionOnly]
        public ActionResult ViewWorks(int? id)
        {
            IEnumerable<Works> works;
            if (id == null)
                works = db.PortfolioWorks.Where(work => work.Topics_Id == 1);
            else
                works = db.PortfolioWorks.Where(work => work.Topics_Id == id);

            return PartialView(works);
        }

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(Users user)
		{
			if (ModelState.IsValid)
			{
				if (db.PortfolioUsers.Any(u => u.Login == user.Login && u.Password == user.Password))
					ViewBag.login = "Вы вошли как " + user.Login;
				else
					ViewBag.login = "Неверное имя пользователя или пароль";

				return View();
			}
			else
				return View(user);

		}


        [ChildActionOnly]
        public ActionResult Social()
        {
            return PartialView("_FooterSocial", db.PortfolioSocialLinks.ToList());
        }
    }
}