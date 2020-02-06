using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOnMvc.Models;
namespace ProjectOnMvc.Controllers
{
    public class SellerController : Controller
    {
        public readonly SellerContext Context;
        public readonly IWebHostEnvironment hostingEnvir;
        public SellerController(SellerContext se,IWebHostEnvironment hostingEnvir)
        {
            this.Context = se;
            this.hostingEnvir = hostingEnvir;
        }
        public ActionResult RegisterSeller()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterSeller(SellerCreatePath bu)
        {

            string uniqueFileName = null;
            if (ModelState.IsValid)
            {
               

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (bu.photopath != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvir.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + bu.photopath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    bu.photopath.CopyTo(new FileStream(filePath, FileMode.Create));
                }

            }
                Seller newEmployee = new Seller
                {
                    Sid = bu.Sid,
                    Sname = bu.Sname,
                    Pass = bu.Pass,
                    Email = bu.Email,
                    Phone = bu.Phone,
                    Date = bu.Date,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    photopath = uniqueFileName
                };

                Context.Add(newEmployee);
                Context.SaveChanges();
                return RedirectToAction("Details", new { id = newEmployee.Sid });
            return View();


        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Seller bo)
        {
            var st = Context.seller.Where(e => e.Sname == bo.Sname && e.Pass == bo.Pass).ToList();
            if (st.Count != 0)
            {
                return View("Dashboard");
            }
            else
            {
                return View();
            }


        }
        // GET: Seller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Seller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Seller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Seller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Seller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Seller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Seller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [AcceptVerbs("get", "post")]
        public ActionResult IsExists(string email)
        {
            var se = Context.seller.Where(e => e.Email == email).ToList();
            return (se.Count == 0) ? Json(true) : Json("Already Exists");
        }
    }
}