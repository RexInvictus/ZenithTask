using ZenithTask.Checkout;
using System;

namespace Program
{
    class Program
    {
        public static void Assert(decimal expected, decimal actual)
        {
            if (expected == actual)
            {
                Console.WriteLine("\n");
                Console.WriteLine("EXPECTED: " + expected + "; ACTUAL: " + actual + ";");
                Console.WriteLine("Test passed!");
            }
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine("Test failed!");
                Console.WriteLine("EXPECTED: " + expected + "; ACTUAL: " + actual + ";");
            }
        }

        public static decimal TestPrice(string str)
        {
            // test rules (same as in assignment doc)
            Rule[] rules = 
                [
                    new Rule('A', 50.00m),
                    new Rule('A', 130.00m, 3),
                    new Rule('B', 30.00m),
                    new Rule('B', 45.00m, 2),
                    new Rule('C', 20.00m),
                    new Rule('D', 15.00m)
                ];
            

            var checkout = new Checkout(rules);

            foreach (char c in str)
            {
                checkout.Scan(c);
            }

            return checkout.GetTotalPrice();
        }
        static void Main(string[] args)
        {
            // empty string
            Assert(0, TestPrice(""));
            // single
            Assert(50, TestPrice("A"));
            Assert(30, TestPrice("B"));
            Assert(20, TestPrice("C"));
            Assert(15, TestPrice("D"));
            // offers on their own
            Assert(130, TestPrice("AAA"));
            Assert(45, TestPrice("BB"));
            // multiple offers
            Assert(260, TestPrice("AAAAAA"));
            Assert(90, TestPrice("BBBB"));
            // mixed offers
            Assert(130 + 45, TestPrice("AAABB"));
            // mixed offers (non contiguous order)
            Assert(130 + 45, TestPrice("ABABA"));
            // offers mixed with non offers
            Assert((15 * 3) + (20 * 4) + (45 * 2) + 30 + 130 + 100, TestPrice("ADABADCDBCCBABBAC"));
        
        }
    }
}