using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithTask.Checkout
{
    public class Rule
    {
        public Char Item { get; private set; }
        public int NumItems { get; private set; }
        public decimal Price { get; private set; }

        public Rule(char item, decimal price, int numItems = 1)
        {
            Item = item;
            NumItems = numItems;
            Price = price;
        }
    }
}