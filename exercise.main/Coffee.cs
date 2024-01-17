using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    public class Coffee : InventoryItem
    {
        public Coffee(string sku, float price, string variant, string name)
            : base(sku, price, variant, name)
        {
        }
    }
}

