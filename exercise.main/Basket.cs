using System;
using System.Collections.Generic;

namespace main
{
    public class Basket
    {
        private int BasketCapacity;
        private List <InventoryItem> ItemsInBasket;
        private BobsInventory BobsInventory;

        public Basket(BobsInventory bobsinventory)
        {
            BobsInventory = bobsinventory;
            BasketCapacity = 5;
            ItemsInBasket = new List<InventoryItem>();
        }

        public float CostOfItem(string SKU)
        {
            InventoryItem item = BobsInventory.GetItem(SKU, null);
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

        public string Add(string SKU, List<string> SKUFilling = null)
        {
            if (ItemsInBasket.Count() >= BasketCapacity)
            {
                return "Your basket is full";
            }

            InventoryItem item = BobsInventory.GetItem(SKU, SKUFilling);
            if (item == null)
                return $"{SKU} is not an item on our menu";

            if (item is not Bagel && SKUFilling != null)
            {
                return "Can only add filling to bagel";
            }

            if(item is Bagel)
            {
                Bagel bagel = (Bagel)item;
                string fillingsString = "";
                for (int i = 0; i < bagel.Fillings.Count(); i++)
                {
                    if (i == bagel.Fillings.Count() - 1)
                    {
                        fillingsString += $"{bagel.Fillings[i].Variant}";
                        break;
                    }
                    fillingsString += $"{bagel.Fillings[i].Variant} ";
                }
                ItemsInBasket.Add(item);
                return $"{bagel.Variant} {bagel.Name} with {(fillingsString.Length == 0 ? "no" : fillingsString)} filling added to your basket";
            }
            ItemsInBasket.Add(item);
            return $"{item.Variant} {item.Name} added to your basket";
          
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