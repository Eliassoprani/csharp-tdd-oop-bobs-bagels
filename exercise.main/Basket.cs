using System;
using System.Collections.Generic;

namespace main
{
    public class Basket
    {
        private int BasketCapacity;
        private List <List<InventoryItem>> ItemsInBasket;
        private BobsInventory BobsInventory;

        public Basket()
        {
            BobsInventory = new BobsInventory();
            BasketCapacity = 5;
            ItemsInBasket = new List<List<InventoryItem>>();
        }

        public float CostOfItem(string SKU)
        {
            bool outParam; // does not do anything. Will need to refactor this later
            List<InventoryItem> item = BobsInventory.GetItem(SKU, out outParam, null);
            float cost = item != null ? item[0].Price : 0;
            return cost;
        }

        public float TotalPrice()
        {
            float result = 0.0f;
            for (int i = 0; i < ItemsInBasket.Count(); i++)
            {
                float itemCost = 0.0f;
                for (int j = 0; j < ItemsInBasket[i].Count(); j++)
                {
                    itemCost += ItemsInBasket[i][j].Price;
                }
                result += itemCost;
            }
            return result;
        }

        public string Add(string SKU, List<string> SKUFilling = null)
        {
            if (ItemsInBasket.Count() >= BasketCapacity)
            {
                return "Your basket is full";
            }
            bool FillingWithoutBagel;
            List<InventoryItem> item = BobsInventory.GetItem(SKU, out FillingWithoutBagel, SKUFilling);
            if (item == null)
                return $"{SKU} is not an item on our menu";

            if (ItemsInBasket.Count < BasketCapacity && item.Count() == 1)
                {
                    ItemsInBasket.Add(item);
                    return $"{item[0].Variant} {item[0].Name} added to your basket";
                }
            if (ItemsInBasket.Count < BasketCapacity && item.Count() > 1)
            {
                string fillingsString = "";
                for (int i = 1; i < item.Count(); i++)
                {
                    if(i == item.Count() - 1)
                    {
                        fillingsString += $"{item[i].Variant}";
                        break;
                    }
                    fillingsString += $"{item[i].Variant} ";
                }
                ItemsInBasket.Add(item);
                return $"{item[0].Variant} {item[0].Name} with {fillingsString} filling added to your basket";
            }
            if (FillingWithoutBagel)
            {
                return "Can only add filling to bagel";
            }
            return "";
        }

        public string Remove(List<InventoryItem> item)
        {
            string output = "item does not exist in basket";
            foreach (var basketList in ItemsInBasket)
            {
                if (basketList.Count == item.Count &&
                    basketList.All(basketItem => item.Any(i => AreInventoryItemsEqual(basketItem, i))))
                {
                    ItemsInBasket.Remove(basketList);
                    output = "item removed from your basket";
                    break; 
                }
            }
            return output;
        }
        private bool AreInventoryItemsEqual(InventoryItem item1, InventoryItem item2)
        {
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