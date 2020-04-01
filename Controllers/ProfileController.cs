using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Memcomb.Models;

namespace Memcomb.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
           
            return View();
        }
        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file) {
                if (file != null && file.ContentLength > 0) {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    file.SaveAs(path);
                }
            return RedirectToAction("Index");
        }

        // GET: Followings/Email_ID
        public ActionResult Index(String id)
        {
            using (memcombdbEntities db = new memcombdbEntities())
            {
                if (HttpContext.Request.Cookies["userIDCookie"] != null)
                {
                    HttpCookie cookie = HttpContext.Request.Cookies.Get("userIDCookie");
                    var v = db.Users.Where(a => a.Email_ID == cookie.Value).FirstOrDefault();
                    //id = v.Email_ID;

                    var data = db.Followings.Include(f => f.User).Where(f => f.User.Email_ID == id);

                    var followed_user = db.Followings.Where(a => a.User_Followed == v.User_ID).FirstOrDefault();

                    var get_UserID = db.Followings.Where(a => a.User_Followed == v.User_ID).FirstOrDefault();


                    var first_name = "default f_name";

                    var last_name = "default l_name";

                    var new_following = new Following()
                    {
                        User_Following = get_UserID.User_Following,
                        User_Followed = get_UserID.User_Followed,
                        User_Followed_First_Name = first_name,
                        User_Followed_Last_Name = last_name
                    };

                    var user_following_join = db.Users.Join(db.Followings,
                        x => x.User_ID,
                        y => y.User_Followed,
                        (x, y) => new {
                            User_First_Name = x.First_Name,
                            User_Last_Name = x.Last_Name
                        });

                    return View(data);
                }
                else
                {
                    var followings = db.Followings.Include(f => f.User);

                    return View(followings);
                }
            }
            
            //return View();
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
