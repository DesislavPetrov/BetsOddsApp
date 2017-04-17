using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication10.Services;

namespace WebApplication10.Data
{
    public class BettingOddsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BettingOddsContext>
    {
        protected override void Seed(BettingOddsContext context)
        {
            XMLReader reader = new XMLReader();
            List<Match> matches = reader.GetMatchesList();
            foreach (var item in matches)
            {
                context.Matches.Add(item);
            }
            context.SaveChanges();            
        }
    }
}