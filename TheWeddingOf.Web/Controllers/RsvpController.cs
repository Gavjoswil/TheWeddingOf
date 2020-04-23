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

        public ActionResult Edit(int id)
        {
            var service = CreateRsvpService();
            var detail = service.GetRsvpById(id);
            var model =
                new RsvpEdit
                {
                    Names = detail.Names,
                    RsvpId = detail.RsvpId,
                    FoodOne = detail.FoodOne,
                    FoodTwo = detail.FoodTwo,
                    YayOrNay = detail.YayOrNay,
                    Comments = detail.Comments
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, RsvpEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.RsvpId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRsvpService();

            if (service.UpdateRsvp(model))
            {
                TempData["SaveResult"] = "Your RSVP was sent";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your RSVP Could not be sent.");
            return View();
        }

        private RsvpService CreateRsvpService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RsvpService(userId);
            return service;
        }
    }
}