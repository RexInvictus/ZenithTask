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

        void Scan(char item)
        {
            _items.Add(item);
        }
    }
}