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
        public List<InventoryItem> GetItem(string SKU, out bool FillingWithoutBagel, List<string> SKUFilling = null)
        {
            List<InventoryItem> returnItem = new List<InventoryItem>();
            if (!inventory.ContainsKey(SKU))
            {
                returnItem = null;
            }
            if (inventory.ContainsKey(SKU) && SKUFilling == null)
            {
                returnItem.Add(inventory[SKU]);
                FillingWithoutBagel = false;
                return returnItem;
            }

            if (inventory.ContainsKey(SKU) && SKUFilling != null)
            {
                if (inventory[SKU].Name != "Bagel")
                {
                    // SKU is not a bagel, so don't add it
                    FillingWithoutBagel = true;
                    return returnItem;
                }

                returnItem.Add(inventory[SKU]);

                // Check if each SKUFilling value is in inventory
                foreach (var filling in SKUFilling)
                {
                    if (inventory.ContainsKey(filling))
                    {
                        returnItem.Add(inventory[filling]);
                    }
                    else
                    {
                        returnItem = null;
                    }
                }

                FillingWithoutBagel = false;
                return returnItem;
            }

            FillingWithoutBagel = false;
            return returnItem;
        }


        private void FillInventory()
        {
            inventory.Add("BGLO", new InventoryItem("BGLO", 0.49f, "Bagel", "Onion"));
            inventory.Add("BGLP", new InventoryItem("BGLP", 0.39f, "Bagel", "Plain"));
            inventory.Add("BGLE", new InventoryItem("BGLE", 0.49f, "Bagel", "Everything"));
            inventory.Add("BGLS", new InventoryItem("BGLS", 0.49f, "Bagel", "Sesame"));
            inventory.Add("COFB", new InventoryItem("COFB", 0.99f, "Coffee", "Black"));
            inventory.Add("COFW", new InventoryItem("COFW", 1.19f, "Coffee", "White"));
            inventory.Add("COFC", new InventoryItem("COFC", 1.29f, "Coffee", "Capuccino"));
            inventory.Add("COFL", new InventoryItem("COFL", 1.29f, "Coffee", "Latte"));
            inventory.Add("FILB", new InventoryItem("FILB", 0.12f, "Filling", "Bacon"));
            inventory.Add("FILE", new InventoryItem("FILE", 0.12f, "Filling", "Egg"));
            inventory.Add("FILC", new InventoryItem("FILC", 0.12f, "Filling", "Cheese"));
            inventory.Add("FILX", new InventoryItem("FILX", 0.12f, "Filling", "Cream Cheese"));
            inventory.Add("FILS", new InventoryItem("FILS", 0.12f, "Filling", "Smoked Salmon"));
            inventory.Add("FILH", new InventoryItem("FILH", 0.12f, "Filling", "Ham"));
        }

    }
}