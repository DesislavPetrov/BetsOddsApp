using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication10.Controllers
{
    public class MatchesListController : Controller
    {
        // GET: ProductsList
        public ActionResult AllMatches()
        {
            XMLReader xmlReader = new XMLReader();
            var data = xmlReader.GetMatchesList();
            return View(data.ToList());
        }

        public ActionResult MatchesNext24Hours()
        {

            XMLReader xmlReader = new XMLReader();
            var data = xmlReader.GetMatchesList();
            List<Match> matchesListNextDay = new List<Match>();
            foreach (var item in data)
            {
                DateTime currentDateTime = DateTime.Now;
                TimeSpan diff = item.ParsedDateAndTime - currentDateTime;
                double hours = diff.TotalHours;
                if (hours < 24 && hours >= 0)
                {
                    matchesListNextDay.Add(item);
                }
            }
            return View(matchesListNextDay.ToList());
        }
    }
}