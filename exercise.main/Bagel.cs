using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    public class Bagel : InventoryItem
    {
        private List<InventoryItem> _fillings = new List<InventoryItem>();

        public List<InventoryItem> Fillings { get { return _fillings; } }

        public Bagel(string sku, float price, string variant, string name)
            : base(sku, price, variant, name)
        {
        }

        public void AddFilling(List<InventoryItem> filling)
        {
            _fillings.AddRange(filling);
        }

    }
}
