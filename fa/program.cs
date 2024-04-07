using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }

    public class FA1
    {
        public bool? Run(IEnumerable<char> s)
        {
            if (s is null || s.Count() == 0)
            {
                return false;
            }

            var zeroCount = 0;
            var oneCount = 0;

            foreach (char c in s)
            {
                if (c == '0')
                {
                    zeroCount++;

                    continue;
                }

                if (c == '1')
                {
                    oneCount++;

                    continue;
                }

                return false;
            }

            if (zeroCount > 1 || oneCount < 1)
            {
                return false;
            }

            return true;
        }
    }

    public class FA2
    {
        public bool? Run(IEnumerable<char> s)
        {
            if (s is null || s.Count() == 0)
            {
                return false;
            }

            var zeroCount = 0;
            var oneCount = 0;

            foreach (char c in s)
            {
                if (c == '0')
                {
                    zeroCount++;

                    continue;
                }

                if (c == '1')
                {
                    oneCount++;

                    continue;
                }

                return false;
            }

            if (zeroCount % 2 == 0 || oneCount % 2 == 0)
            {
                return false;
            }

            return true;
        }
    }

    public class FA3
    {
        public bool? Run(IEnumerable<char> s)
        {
            if (s is null || s.Count() == 0)
            {
                return false;
            }

            var previousIsOne = false;
            var twoSequentialOnesCount = 0;

            foreach (char c in s)
            {
                if (c == '0')
                {
                    previousIsOne = false;

                    continue;
                }

                if (c == '1')
                {
                    if (previousIsOne)
                    {
                        twoSequentialOnesCount++;
                    }

                    previousIsOne = true;
                    continue;
                }

                return false;
            }

            if (twoSequentialOnesCount == 0)
            {
                return false;
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}
