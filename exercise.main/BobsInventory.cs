using System;
using System.Collections.Generic;

namespace main
{
    public class BobsInventory
    {
        private Dictionary<string, InventoryItem> inventory;

        public BobsInventory()
        {
            inventory = new Dictionary<string, InventoryItem>();
            FillInventory();
        }
        public InventoryItem GetItem(string SKU, List<string> SKUFilling = null)
        {
            InventoryItem returnItem = null;
            List<InventoryItem> fillingList = new List<InventoryItem>();
            if (!inventory.ContainsKey(SKU))
            {
                returnItem = null;
            }
            else
            {
                returnItem = inventory[SKU];
            }
            if (inventory.ContainsKey(SKU) && SKUFilling != null && inventory[SKU] is Bagel)
            {

                returnItem = inventory[SKU];

                // Check if each SKUFilling value is in inventory
                foreach (var filling in SKUFilling)
                {
                    if (inventory.ContainsKey(filling))
                    {
                        fillingList.Add(inventory[filling]);
                    }
                    else
                    {
                        returnItem = null;
                    }
                }

                Bagel bagel = (Bagel)returnItem;
                bagel.AddFilling(fillingList);
                returnItem = bagel;
            }
            return returnItem;
        }


        private void FillInventory()
        {
            inventory.Add("BGLO", new Bagel("BGLO", 0.49f, "Onion", "Bagel"));
            inventory.Add("BGLP", new Bagel("BGLP", 0.39f, "Plain", "Bagel"));
            inventory.Add("BGLE", new Bagel("BGLE", 0.49f, "Everything", "Bagel"));
            inventory.Add("BGLS", new Bagel("BGLS", 0.49f, "Sesame", "Bagel"));
            inventory.Add("COFB", new Coffee("COFB", 0.99f, "Black", "Coffee"));
            inventory.Add("COFW", new Coffee("COFW", 1.19f, "White", "Coffee"));
            inventory.Add("COFC", new Coffee("COFC", 1.29f, "Capuccino", "Coffee"));
            inventory.Add("COFL", new Coffee("COFL", 1.29f, "Latte", "Filling"));
            inventory.Add("FILB", new Filling("FILB", 0.12f, "Bacon", "Filling"));
            inventory.Add("FILE", new Filling("FILE", 0.12f, "Egg", "Filling"));
            inventory.Add("FILC", new Filling("FILC", 0.12f, "Cheese", "Filling"));
            inventory.Add("FILX", new Filling("FILX", 0.12f, "Cream Cheese", "Filling"));
            inventory.Add("FILS", new Filling("FILS", 0.12f, "Smoked Salmon", "Filling"));
            inventory.Add("FILH", new Filling("FILH", 0.12f, "Ham", "Filling"));
        }

    }
}