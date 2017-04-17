using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using WebApplication10.Data;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class MatchesController : Controller
    {
        private BettingOddsContext db = new BettingOddsContext();

        // GET: Matches
        public ActionResult Index()
        {
             return View(db.Matches.ToList());
        }

        public ActionResult IndexView()
        {
            //return View(db.Matches.ToList());
            return View();
        }

        public ActionResult GetMatches()
        {
            MatchesRepository matchService = new MatchesRepository();
            return PartialView("_MatchesList", matchService.GetAllMatches());
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
