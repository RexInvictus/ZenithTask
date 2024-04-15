using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithTask.Checkout
{
    public class Checkout
    {
        private Rule[] _rules;
        private List<Char> _items = [];

        public Checkout(Rule[] rules)
        {
            _rules = rules;
        }

        public void Scan(char item)
        {
            _items.Add(item);
        }

        public int GetTotalPrice()
        {
            return 0;
        }

    }
}