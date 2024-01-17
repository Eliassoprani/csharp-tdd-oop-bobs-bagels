using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    public class Filling : InventoryItem
    {
        public Filling(string sku, float price, string variant, string name)
            : base(sku, price, variant, name)
        {
        }
    }
}
