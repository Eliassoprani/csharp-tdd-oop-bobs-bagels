using System;
using System.Collections.Generic;

public class InventoryItem
{
    public string SKU { get; set; }
    public float Price { get; set; }
    public string Name { get; set; }
    public string Variant { get; set; }

    public InventoryItem(string sku, float price, string name, string variant)
    {
        SKU = sku;
        Price = price;
        Name = name;
        Variant = variant;
    }
}