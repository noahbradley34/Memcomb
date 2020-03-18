using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Memcomb.Models;

namespace Memcomb.Controllers
{
    public class FollowingsController : Controller
    {
        private memcombdbEntities db = new memcombdbEntities();

       /* public ActionResult Index()
        {
            var followings = db.Followings.Include(f => f.User);
            return View(followings.ToList());
        }
        */

        // GET: Followings/Email_ID
        public ActionResult Index(String id)
        {
            if (HttpContext.Request.Cookies["userIDCookie"] != null)
            {
                HttpCookie cookie = HttpContext.Request.Cookies.Get("userIDCookie");
                var v = db.Users.Where(a => a.Email_ID == cookie.Value).FirstOrDefault();
                //id = v.Email_ID;

                var data = db.Followings.Include(f => f.User).Where(f => f.User.Email_ID == id); 


                return View(data);
            }
            else
            {
                var followings = db.Followings.Include(f => f.User);
                return View(followings.ToList());
            }
            //return View();
        }
        
        // GET: Followings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Following following = db.Followings.Find(id);
            if (following == null)
            {
                return HttpNotFound();
            }
            return View(following);
        }

        // GET: Followings/Create
        public ActionResult Create()
        {
            ViewBag.User_Following = new SelectList(db.Users, "User_ID", "First_Name");
            ViewBag.User_Followed = new SelectList(db.Users, "User_ID", "First_Name");
            return View();
        }

        // POST: Followings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_Following,User_Followed")] Following following)
        {
            if (ModelState.IsValid)
            {
                db.Followings.Add(following);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_Following = new SelectList(db.Users, "User_ID", "First_Name", following.User_Following);
            ViewBag.User_Followed = new SelectList(db.Users, "User_ID", "First_Name", following.User_Followed);
            return View(following);
        }

        // GET: Followings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Following following = db.Followings.Find(id);
            if (following == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_Following = new SelectList(db.Users, "User_ID", "First_Name", following.User_Following);
            return View(following);
        }

        // POST: Followings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_Following,User_Followed")] Following following)
        {
            if (ModelState.IsValid)
            {
                db.Entry(following).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_Following = new SelectList(db.Users, "User_ID", "First_Name", following.User_Following);
            return View(following);
        }

        // GET: Followings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Following following = db.Followings.Find(id);
            if (following == null)
            {
                return HttpNotFound();
            }
            return View(following);
        }

        // POST: Followings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Following following = db.Followings.Find(id);
            db.Followings.Remove(following);
            db.SaveChanges();
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
