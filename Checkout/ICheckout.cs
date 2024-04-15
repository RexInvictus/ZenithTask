using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithTask.Checkout
{
    public interface ICheckout
    {
        void Scan(char item);
        decimal GetTotalPrice();

    }
}