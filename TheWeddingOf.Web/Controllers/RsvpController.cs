using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWeddingOf.Models;

namespace TheWeddingOf.Web.Controllers
{
    [Authorize]
    public class RsvpController : Controller
    {
        // GET: Rsvp
        public ActionResult Index()
        {
            var model = new RsvpListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}