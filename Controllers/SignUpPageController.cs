using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Memcomb.Models;
using System.Net;
using System.Web.Security;

namespace Memcomb.Controllers
{
    public class SignUpPageController : Controller
    {
        // GET: SignUpPage
        public ActionResult Index()
        {
            return View();
        }

        //Registration POST action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(/*[Bind(Exclude = "IsEmailVerified,ActivationCode")]*/ User user)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation
            if (ModelState.IsValid)
            {
                

                // Email already registered
                #region
                var isRegistered = IsEmailRegistered(user.Email_ID);
                if (isRegistered)
                {
                    ModelState.AddModelError("EmailRegistered", "Email already registered");
                    return View(user);
                }
                #endregion

                /*
                #region Generate Activation Code
                user.ActivationCode = Guid.NewGuid();
                #endregion
                */


                #region Password Hashing
                //user.Password = Encrypt.Hash(user.Password);
                //user.ConfirmPassword = Encrypt.Hash(user.ConfirmPassword);
                #endregion

               // user.IsEmailVerified = false;

                
                #region Save to database
                using (memcombdbEntities dc = new memcombdbEntities())
                {
                    dc.Users.Add(user);
                    dc.SaveChanges();

                    //Send confirmation email to user
                    //SendVerificationLinkEmail(user.Email_ID, user.User_ID.ToString());
                    message = "Registration was successful. Check your email for verification link " +
                        "at your email: " + user.Email_ID;
                    Status = true;
                    return View("~/Views/HomePage/Index.cshtml");
                }
                #endregion
            
            }
            else
            {
                message = "Invalid request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);

        }


        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [NonAction]
        public bool IsEmailRegistered(string emailID)
        {
            using (memcombdbEntities dc = new memcombdbEntities())
            {
                var v = dc.Users.Where(a => a.Email_ID == emailID).FirstOrDefault();
                return v != null;
            }
        }

        //Forgot password

        public ActionResult ForgotPassword()
        {
            return View();
        }


    }
}
