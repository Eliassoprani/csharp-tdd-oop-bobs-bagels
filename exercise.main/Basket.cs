using System;
using System.Collections.Generic;

namespace main
{
    public class Basket
    {
        private int BasketCapacity;
        private List<InventoryItem> ItemsInBasket;
        private BobsInventory BobsInventory;
        public Basket(BobsInventory bobsinventory)
        {
            BobsInventory = bobsinventory;
            BasketCapacity = 5;
            ItemsInBasket = new List<InventoryItem>();
        }

        public float CostOfItem(string SKU)
        {
            string inventoryMessage;
            InventoryItem item = BobsInventory.GetItem(SKU, out inventoryMessage);
            float cost = item != null ? item.Price : 0;
            return cost;
        }
        public float TotalPrice()
        {
            float result = 0.0f;

            float itemCost = 0.0f;
            for (int i = 0; i < ItemsInBasket.Count(); i++)
            {
                float bagelFillingCost = 0;
                if (ItemsInBasket[i] is Bagel)
                {
                    Bagel bagel = (Bagel)ItemsInBasket[i];
                    for (int j = 0; j < bagel.Fillings.Count(); j++)
                    {
                        bagelFillingCost += bagel.Fillings[j].Price;
                    }
                }
                itemCost += ItemsInBasket[i].Price + bagelFillingCost;
            }
            result += itemCost;

            return result;
        }

        public string Add(string SKU)
        {
            if (ItemsInBasket.Count() >= BasketCapacity)
            {
                return "Your basket is full";
            }
            string inventoryMessage;
            InventoryItem item = BobsInventory.GetItem(SKU, out inventoryMessage);

            if (item == null)
                return inventoryMessage;

            ItemsInBasket.Add(item);
            return inventoryMessage;
        }
        public string Add(string SKU, List<string> SKUFilling)
        {
            string inventoryMessage;
            if (ItemsInBasket.Count() >= BasketCapacity)
                return "Your basket is full";


            InventoryItem item = BobsInventory.GetItem(SKU, SKUFilling, out inventoryMessage);
            if (item == null)
                return inventoryMessage;

            ItemsInBasket.Add(item);
            return inventoryMessage;
        }

        public string Remove(InventoryItem item)
        {
            string output = "item does not exist in basket";

            for (int i = 0; i < ItemsInBasket.Count; i++)
            {
                if (AreItemsEqual(ItemsInBasket[i], item))
                {
                    ItemsInBasket.RemoveAt(i);
                    output = "item removed from your basket";
                }
            }

            return output;
        }

        private bool AreItemsEqual(InventoryItem item1, InventoryItem item2)
        {
            if (item1 is Bagel bagel1 && item2 is Bagel bagel2)
            {
                // Compare properties of the Bagel class
                bool arePropertiesEqual = bagel1.Name == bagel2.Name &&
                                          bagel1.Price == bagel2.Price &&
                                          bagel1.SKU == bagel2.SKU &&
                                          bagel1.Variant == bagel2.Variant;

                // Compare Fillings lists
                bool areFillingsEqual = bagel1.Fillings.Count == bagel2.Fillings.Count &&
                                        bagel1.Fillings.All(filling1 =>
                                            bagel2.Fillings.Any(filling2 => AreItemsEqual(filling1, filling2)));

                return arePropertiesEqual && areFillingsEqual;
            }

            // Compare properties for other types
            return item1.Name == item2.Name &&
                   item1.Price == item2.Price &&
                   item1.SKU == item2.SKU &&
                   item1.Variant == item2.Variant;
        }



        public string UpdateCapacity(int newCapacity)
        {
            if (newCapacity < 1)
            {
                return "basket capacity cannot be smaller than 1";
            }
            BasketCapacity = newCapacity;
            return $"New basket capacity is {newCapacity}";
        }
    }
}