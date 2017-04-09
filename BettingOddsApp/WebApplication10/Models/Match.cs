using System;
using System.Collections.Generic;

namespace Models
{
    public class Match
    {
        public List<Bet> BetsList = new List<Bet>();
        public Match(string name, string id, string startDate, MatchType matchType, Event ev)
        {
            this.Name = name;
            this.Id = id;
            this.StartDate = startDate;
            this.MatchType = matchType;
            this.Ev = ev;
            this.ParsedDateAndTime = ParseDateAndTime(startDate);
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public string StartDate { get; set; }

        public DateTime ParsedDateAndTime { get; set; }

        public int NumberOfChildNodes { get; set; }

        public MatchType MatchType { get; set; }
        public Event Ev { get; set; }

        public void AddBetToBetsList(Bet bet)
        {
            BetsList.Add(bet);
        }

        public int GetBetsCountForOneMatch()
        {
            return this.BetsList.Count;
        }

        public List<Bet> GetBetsList()
        {
            return this.BetsList;
        }

        public DateTime ParseDateAndTime(string startDate)
        {
            string[] startDateArray = startDate.Split('T');
            startDate = string.Format(startDateArray[0] + " " + startDateArray[1]);
            DateTime dateTime = DateTime.Parse(startDate);
            return dateTime;
        }

    }
}
