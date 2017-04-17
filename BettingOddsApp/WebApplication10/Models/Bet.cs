using System.Collections.Generic;

namespace Models
{

    //[Serializable]
    //[XmlRoot("Bet"), XmlType("Bet")]
    public class Bet
    {
        public List<Odd> OddsList = new List<Odd>();
        public Bet(string name, string id, bool isLive, Match match)
        {
            this.Name = name;
            this.Id = id;
            this.IsLive = isLive;
            this.Match = match;
        }

        public Bet()
        {

        }

        public string Name { get; set; }
        public string Id { get; set; }
        public bool IsLive { get; set; }
        public Match Match { get; set; }

        public int NumberOfChildNodes { get; set; }

        public void AddOddToOddsList(Odd odd)
        {
            OddsList.Add(odd);
        }

        public int GetOddsCountForOneBet()
        {
            return this.OddsList.Count;
        }
    }
}
