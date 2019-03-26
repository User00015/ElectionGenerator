namespace ElectionGenerator
{
    public class Voter
    {
        public Voter()
        {
            Age = Random.Integers(18, 90);
            Gender = Random.Integers(0, 1);
            Result = Random.Integers(1, 101);
        }

        public Voter(Location loc) : this()
        {
            Location = loc;

            if (Result <= Location.Bias)
            {
                LionVote = true;
            }

            if (Result > Location.Bias)
            {
                TurtleVote = true;
            }

        }

        public bool LionVote { get; }
        public bool TurtleVote { get; }
        public int Result { get; }
        public int Gender { get; }
        public int Age { get; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public Location(int id = 0, int bias = 0)
        {
            Id = id;
            Bias = bias;
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public int Bias { get; set; }
    }
}
