namespace Models
{

    //[Serializable]
    //[XmlRoot("Odd"), XmlType("Odd")]
    public class Odd
    {
        public Odd(string name, string id, float value, string specialBetValue, Bet bet)
        {
            this.Name = name;
            this.Id = id;
            this.Value = value;
            this.SpecialBetValue = specialBetValue;
            this.Bet = bet;
        }

        public Odd(string name, string id, float value, Bet bet)
        {
            this.Name = name;
            this.Id = id;
            this.Value = value;
            this.Bet = bet;
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public float Value { get; set; }
        public virtual string SpecialBetValue { get; set; }
        public Bet Bet { get; set; }
    }
}
