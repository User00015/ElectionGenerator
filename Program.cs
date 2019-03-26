using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ElectionGenerator
{
    class Program
    {
        public static RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();
        static void Main(string[] args)
        {

            var locations = new List<Location>();
            var voters = new List<Voter>();

            while(voters.Count(v => v.TurtleVote) < 500)
            {
                locations.Clear();
                voters.Clear();

                10.Times((j) => locations.Add(new Location(j, Random.Integers(50, 60))));

                foreach (var loc in locations)
                {
                    100.Times(() => voters.Add(new Voter(loc)));
                }

                Console.WriteLine($"Bias: {locations.Average(p => p.Bias)} -- Turtle Voters: {voters.Count(v => v.TurtleVote)}");


            }

            var lionCount = voters.Count(v => v.LionVote);
            var turtleCount = voters.Count(v => v.TurtleVote);
            var winner = lionCount > turtleCount ? $"Lion at {lionCount:###,###,###} out of {lionCount + turtleCount} or %{lionCount / (double)(lionCount + turtleCount) * 100}" :
                $"Turtle at {turtleCount:###,###,###} out of {lionCount + turtleCount} %{turtleCount / (double)(lionCount + turtleCount) * 100}";

            Console.WriteLine($"Winner: {winner}!");

            //            foreach (var locId in locationIds)
            //            {
            //                Console.WriteLine($@"
            //In {voters.FirstOrDefault(v => v.Location.Id == locId).Location.Id} with bias {voters.FirstOrDefault(v => v.Location.Id == locId).Location.Bias}
            //Lion voters: {voters.Where(v => v.Location.Id == locId).Count(p => p.LionVote)}, Turtle voters: {voters.Where(v => v.Location.Id == locId).Count(p => p.TurtleVote)}
            //");

            //            }
            //foreach (var voteSequence in votes)
            //{
            //    var count = voteSequence.Count(p => p);
            //    avg.Add(count);
            //}

            //Console.WriteLine($"Avg: {avg.Average()}");
            //Console.Read();
        }


        public static IEnumerable<Voter> GetVoters()
        {
            var voters = new List<Voter>();
            while (voters.Count < 100000)
            {
                voters.Add(new Voter());
            }

            return voters;

        }

        public static bool[] GetVotes()
        {
            var numbers = new bool[100];
            for (int i = 0; i < 100; i++)
            {
                var normalBias = 10;
                var voteResult = Random.Integers(1, 101);
                if (voteResult <= 50 + normalBias)
                {
                    numbers[i] = true;
                }
            }

            return numbers;
        }
    }
}
