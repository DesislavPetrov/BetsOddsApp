using System;
using System.Collections.Generic;

namespace Models
{
    public class Event
    {
        public List<Match> MatchesList = new List<Match>();
        public Event(string name, string id, bool isLive, string categoryId, Sport sport)
        {
            this.Name = name;
            this.Id = id;
            this.IsLive = isLive;
            this.CategoryId = id;
            this.Sport = sport;
            this.Country = GetEventCountry(this.Name);
            this.Tournament = GetEventTournament(this.Name);
        }

        public Event()
        {

        }
        public string Name { get; set; }
        public string Id { get; set; }

        public bool IsLive { get; set; }
        public string CategoryId { get; set; }

        public int NumberOfChildNodes { get; set; }

        public Sport Sport { get; set; }

        public string Country { get; }
        public string Tournament { get; }

        public void AddMatchToMatchesList (Match match)
        {
            MatchesList.Add(match);
        }

        public string GetEventCountry (string eventName)
        {
            string[] eventNameArray = this.Name.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string eventCountry = eventName = eventNameArray[0];
            return eventCountry;
        }

        public string GetEventTournament(string eventName)
        {
            string[] eventNameArray = this.Name.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string eventTournament = eventName = eventNameArray[1];
            return eventTournament;
        }
    }
}
