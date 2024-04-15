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
            if (char.IsLetter(item))
            {
                _items.Add(item);
            }
            else
            {
                Console.WriteLine("SCAN ERROR: Item key must be alphabetical.");
            }
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0.00m;

            // group items by value
            var groups = _items.GroupBy(item => item);

            foreach (var group in groups)
            {
                // take group-specific rules in order of NumItems
                var groupRules = _rules.Where(rule => rule.Item == group.Key).OrderByDescending(rule => rule.NumItems);

                
                var numItems = group.Count();
                while (numItems > 0)
                {
                    var rule = groupRules.First(rule => rule.NumItems <= numItems);
                    
                    // floor divide to get batches
                    int batch = numItems / rule.NumItems;

                    totalPrice += batch * rule.Price;
                    numItems -= batch * rule.NumItems;
                }
            }   
            return totalPrice;
        }

    }
}