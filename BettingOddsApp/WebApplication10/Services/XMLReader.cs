using System.Collections.Generic;
using System.Web;
using System.Xml;
using System;

namespace Models
{
    public class XMLReader
    {
        List<Sport> sports = new List<Sport>();
        List<Event> events = new List<Event>();
        List<Match> matches = new List<Match>();
        List<Bet> bets = new List<Bet>();
        List<Odd> odds = new List<Odd>();

        public List<Match> GetMatchesList()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/XMLFile4.xml");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlData);
            
            // Sport
            foreach (XmlElement sp in xmlDocument.SelectNodes("xmlsports/sport"))
            {
                string sportName = sp.GetAttribute("name");
                string sportId = sp.GetAttribute("id");

                int sportChildNodesCount = sp.ChildNodes.Count;

                Sport sport = new Sport(sportName, sportId);
                sport.NumberOfChildNodes = sportChildNodesCount;
                sports.Add(sport);
            }

            // Events
            int eventsCounter = 0;
            int currentSportCounter = 0;
            foreach (XmlElement le in xmlDocument.SelectNodes("xmlsports/sport/event"))
            {              

                string eventName = le.GetAttribute("name");
                string eventId = le.GetAttribute("id");
                string isLiveString = le.GetAttribute("islive");
                string categoryId = le.GetAttribute("categoryid");
                string sportName = sports[currentSportCounter].Name;

                Sport currentSport = sports[currentSportCounter];

                bool isLive = false; 
                if (isLiveString == "true")
                {
                    isLive = true;
                }

                int childNodesCount = le.ChildNodes.Count;                

                Event ev = new Event(eventName, eventId, isLive, categoryId, currentSport);
                ev.NumberOfChildNodes = childNodesCount;
                events.Add(ev);

                sports[currentSportCounter].AddEventToEventsList(ev);
                eventsCounter++;
                if (eventsCounter >= sports[currentSportCounter].NumberOfChildNodes)
                {
                    currentSportCounter++;
                    eventsCounter = 0;
                }
            }
            
            // Matches
            int matchesCounter = 0;
            int currentEventCounter = 0;
            foreach (XmlElement xe in xmlDocument.SelectNodes("xmlsports/sport/event/match"))
            {
                string matchName = xe.GetAttribute("name");
                string matchId = xe.GetAttribute("id");
                string matchStartDate = xe.GetAttribute("startdate");
                string matchTypeString = xe.GetAttribute("matchtype");
                MatchType matchType = (MatchType)Enum.Parse(typeof(MatchType), matchTypeString);
                string eventName = events[currentEventCounter].Name;

                Event currentEvent = events[currentEventCounter];
                int childNodesCount = xe.ChildNodes.Count;
                Match mh = new Match(matchName, matchId, matchStartDate, matchType, currentEvent);                
                mh.NumberOfChildNodes = childNodesCount;

                matches.Add(mh);
                events[currentEventCounter].AddMatchToMatchesList(mh);
                matchesCounter++;
                if (matchesCounter >= events[currentEventCounter].NumberOfChildNodes)
                {
                    currentEventCounter++;
                    matchesCounter = 0;
                }
            }

            // Bets
            int betsCounter = 0;
            int currentMatchCounter = 0;
            foreach (XmlElement xe in xmlDocument.SelectNodes("xmlsports/sport/event/match/bet"))
            {
                string betName = xe.GetAttribute("name");
                string betId = xe.GetAttribute("id");
                string isLiveString = xe.GetAttribute("islive");
                
                string matchName = matches[currentMatchCounter].Name;

                Match currentMatch = matches[currentMatchCounter];
                if (currentMatch.NumberOfChildNodes <= 0)
                {
                    while (matches[currentMatchCounter].NumberOfChildNodes <= 0 && currentMatchCounter < (matches.Count - 1))
                    {
                        currentMatchCounter++;
                    }
                    currentMatch = matches[currentMatchCounter];
                }                


                bool isLive = false;
                if (isLiveString == "true")
                {
                    isLive = true;
                }

                int childNodesCount = xe.ChildNodes.Count;

                Bet be = new Bet(betName, betId, isLive, currentMatch);
                be.NumberOfChildNodes = childNodesCount;
                bets.Add(be);
                matches[currentMatchCounter].AddBetToBetsList(be);
                betsCounter++;
                if (betsCounter >= matches[currentMatchCounter].NumberOfChildNodes)
                {
                    currentMatchCounter++;
                    betsCounter = 0;
                }
            }

            // Odds
            int oddsCounter = 0;
            int currentBetCounter = 0;
            foreach (XmlElement xe in xmlDocument.SelectNodes("xmlsports/sport/event/match/bet/odd"))
            {
                string oddName = xe.GetAttribute("name");
                string oddId = xe.GetAttribute("id");
                string oddValueString = xe.GetAttribute("value");
                float oddValue = float.Parse(oddValueString);              
                                

                string betName = bets[currentBetCounter].Name;

                Bet currentBet = bets[currentBetCounter];
                if (currentBet.NumberOfChildNodes <= 0)
                {
                    while (bets[currentBetCounter].NumberOfChildNodes <= 0 && currentBetCounter < (bets.Count - 1))
                    {
                        currentBetCounter++;
                    }
                    currentBet = bets[currentBetCounter];
                }

                Odd od = new Odd(oddName, oddId, oddValue, currentBet);

                string specialBetValue;
                if (xe.HasAttribute("specialbetvalue"))
                {
                    specialBetValue = xe.GetAttribute("specialbetvalue");
                }
                
                odds.Add(od);
                bets[currentBetCounter].AddOddToOddsList(od);
                oddsCounter++;
                if (oddsCounter >= bets[currentBetCounter].NumberOfChildNodes)
                {
                    currentBetCounter++;
                    oddsCounter = 0;
                }
            }

            // todo: add foreach for odd
            return matches;
        }
    }
}
