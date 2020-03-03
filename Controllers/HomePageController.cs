using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using Memcomb.Models;
using System.Web.Security;


namespace Memcomb.Controllers
{
    public class HomePageController : Controller
    {

        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }

        //Registration POST action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(/*[Bind(Exclude = "IsEmailVerified,ActivationCode")]*/ Fragment fragment)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation
            if (ModelState.IsValid)
            {

                // var userID = User.Identity.GetUserId();

                //User getUserID = User.Identity.Name;

                #region Save to database
                using (memcombdbEntities dc = new memcombdbEntities())
                {
                   // var user = User.FindById(User.Identity.GetUserId());

                    //User userid = dc.Users.Find(User_ID);



                    Memory newMemory = new Memory()
                    {
                        //User_ID = userID,
                        Memory_ID = fragment.Fragment_ID,
                        Memory_Title = "Title",
                        Memory_Description = "Desc"
                    };

                    dc.Memories.Add(newMemory);
                    dc.Fragments.Add(fragment);
                    dc.SaveChanges();
                    Status = true;
                    //Directory.CreateDirectory(Server.MapPath("~/Memories/User_ID" + user.User_ID + "/Memory_ID" + memory.Memory_ID));
                }
                #endregion

            }
            else
            {
                message = "Invalid request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(fragment);

        }

        public ActionResult CreateMemory()
        {
            return View();
        }
    }
}