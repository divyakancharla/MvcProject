using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOnMvc.Models;
namespace ProjectOnMvc.Controllers
{
    public class BuyerController : Controller
    {
        public readonly BuyerContext Context;
        public BuyerController(BuyerContext buy)
        {
            this.Context = buy;
        }
        public ActionResult RegisterBuyer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterBuyer(Buyer bu)
        {
            try
            {
                Context.Add(bu);
                Context.SaveChanges();
                ViewBag.meassage = bu.Bname + " " + "Registration Success";
                
            }
            catch(Exception e)
            {
                ViewBag.message = bu.Bname + " " + "Registration Failed";
            }
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Buyer bo)
        {
            var st = Context.buyer.Where(e => e.Bname == bo.Bname && e.Pass == bo.Pass).ToList();
            if (st.Count != 0)
            {
                return View("Dashboard");
            }
            else
            {
                return View();
            }

  
        }
        // GET: Buyer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Buyer/Details/5
        public ActionResult Details(Buyer bu)
        {
            return View(bu);
        }

        // GET: Buyer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buyer/Create
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

        // GET: Buyer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Buyer/Edit/5
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

        // GET: Buyer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Buyer/Delete/5
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
        [AcceptVerbs("get","post")]
        public ActionResult IsExists(string email)
        {
            var se = Context.buyer.Where(e => e.Email == email).ToList();
            return (se.Count==0)?Json(true):Json("Already Exists");
        }
    }
}