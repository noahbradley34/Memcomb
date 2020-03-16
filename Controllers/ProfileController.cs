﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        /* ActionResult Upload(HttpPostedFileBase file) {
                if (file != null && file.ContentLength > 0) {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    file.SaveAs(path);
                }
            return RedirectToAction("Index");
        }*/
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
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ProfilePageModel model)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
               
                    HttpPostedFileBase imgFile = Request.Files["profileImage"];
                var binary = new BinaryReader(imgFile.InputStream);
                        imageData = binary.ReadBytes(imgFile.ContentLength);
                var user = new User { User_ID = model.user.User_ID, First_Name = model.user.First_Name, Last_Name = model.user.Last_Name };
                user.Profile_Picture = imgFile;
            }
            return View(model);
        }
        public FileContentResult ProfilePhotos()
        {
             string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");
             byte[] imageData = null;
             FileInfo fileInfo = new FileInfo(fileName);
             long imageFileLength = fileInfo.Length;
             FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
             BinaryReader br = new BinaryReader(fs);
             imageData = br.ReadBytes((int)imageFileLength);
             return File(imageData, "image/png");
        }
    }
}
