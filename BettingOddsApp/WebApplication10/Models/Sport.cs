using System.Collections.Generic;

namespace Models
{
    public class Sport
    {
        private List<Event> EventsList = new List<Event>();

        public Sport(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public int NumberOfChildNodes { get; set; }

        public void AddEventToEventsList(Event ev)
        {
            EventsList.Add(ev);
        }
    }
}
