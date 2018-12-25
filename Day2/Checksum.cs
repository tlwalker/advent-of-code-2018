using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    public class Checksum
    {
        private readonly IEnumerable<string> _source;

        public Checksum(IEnumerable<string> source)
        {
            _source = source;
        }
        public int Calculate()
        {
            (int doubles, int triples) = _source.Aggregate((0, 0), AddInDoublesAndTriples);
            return doubles * triples;
        }

        private static (int, int) AddInDoublesAndTriples((int, int) accTuple, string line)
        {
            var charCounts = line.GroupBy(c => c);
            (int doubles, int triples) = accTuple;
            bool doubleAdded = false;
            bool tripleAdded = false;
            foreach (var charCount in charCounts)
            {
                switch (charCount.Count())
                {
                    case 3 when !tripleAdded:
                        triples++;
                        tripleAdded = true;
                        break;
                    case 2 when !doubleAdded:
                        doubles++;
                        doubleAdded = true;
                        break;
                }

                if (doubleAdded && tripleAdded)
                {
                    break;
                }
            }

            return (doubles, triples);
        }
    }
}