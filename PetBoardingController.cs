using PetBoarding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetBoarding.Controllers
{
    public class PetBoardingController : Controller
    {
        // GET: PetBoarding
        public ActionResult Index()
            //This code is responsible for reading and storing data to database and showing it on a index page that is stored in it.
        {
            var db = new PetBoardingDataContext();
            var f_message = db.PetBoarding.ToArray();

            return View(f_message);
        }
        public ActionResult PetBoarding(long id)
        //This code is responsible for finding data from database and showing it on petboarding page that is stored in it.
        {
            var db = new PetBoardingDataContext();
            var f_message = db.PetBoarding.Find(id);

            return View(f_message);
        }
        [HttpGet]
        //This code is responsible forcgenerating a method for editing data to database and storing it on it.
        [Authorize(Users = "TDeadcoldT@mail.ru")]
        public ActionResult Edit(long id)
        {
            var db = new PetBoardingDataContext();
            var f_message = db.PetBoarding.Find(id);

            return View(f_message);
        }

        [HttpPost]
        [Authorize(Users = "TDeadcoldT@mail.ru")]
        public ActionResult Edit([Bind]Models.PetBoarding FMsg)
        {
            if (ModelState.IsValid)
            {
                var db = new PetBoardingDataContext();
                db.Entry(FMsg).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return Edit(FMsg.id);
        }

        [HttpGet]
        //This code allows to generate two different functions for HttpGet and HttpPost.
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind]Models.PetBoarding FMsg)
        {
            if (ModelState.IsValid)
            {
                //Save to database
                FMsg.Date = DateTime.Now;
                FMsg.Approved = false;
                var db = new PetBoardingDataContext();
                db.PetBoarding.Add(FMsg);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return Create();
        }

        [Authorize(Users = "TDeadcoldT@mail.ru")]
        //This code allows to create and save your data into database.
        public ActionResult Admin()
        {
            var db = new PetBoardingDataContext();
            var f_message = db.PetBoarding.ToArray();

            return View();
        }
        [HttpGet]
        //This code allows to read data from database that is stored in it.
        [Authorize(Users = "TDeadcoldT@mail.ru")]
        public ActionResult Details(long id)
        {
            var db = new PetBoardingDataContext();
            var f_message = db.PetBoarding.Find(id);

            return View(f_message);
        }

        [HttpPost]
        [Authorize(Users = "TDeadcoldT@mail.ru")]
        public ActionResult Details([Bind]Models.PetBoarding FMsg)
        {
            if (ModelState.IsValid)
            {
                var db = new PetBoardingDataContext();
                db.Entry(FMsg).State = System.Data.Entity.EntityState.Unchanged;
                db.SaveChanges();

                return RedirectToAction("Index");

                
            }
            return View();
        }

        
        [HttpGet]
        //This code will allow to delete the code from the database.
        [Authorize(Users = "TDeadcoldT@mail.ru")]
        public ActionResult Delete(long id)
        {
            var db = new PetBoardingDataContext();
            var f_message = db.PetBoarding.Find(id);

            return View(f_message);
        }

        [HttpPost]
        [Authorize(Users = "TDeadcoldT@mail.ru")]
        public ActionResult Delete([Bind]Models.PetBoarding FMsg)
        {
           
                var db = new PetBoardingDataContext();
                db.Entry(FMsg).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

                return RedirectToAction("Index");

               
            
        }

    }

}