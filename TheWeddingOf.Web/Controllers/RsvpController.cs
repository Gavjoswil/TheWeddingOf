using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWeddingOf.Models;
using TheWeddingOf.Services;

namespace TheWeddingOf.Web.Controllers
{
    public class RsvpController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RsvpService(userId);
            var model = service.GetRsvps();
            
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RsvpCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RsvpService(userId);
            service.CreateRsvp(model);

            return RedirectToAction("Index");
        }
    }
}