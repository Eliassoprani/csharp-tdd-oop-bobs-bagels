using System;
using System.Collections.Generic;

public class InventoryItem
{
    private string _sku;
    private float _price;
    private string _variant;
    private string _name;
    public string SKU { get { return _sku;  } }
    public float Price { get { return _price; } }
    public string Variant { get { return _variant; } }
    public string Name { get { return _name; } }


    public InventoryItem(string sku, float price, string variant, string name)
    {
        _sku = sku;
        _price = price;
        _variant = variant;
        _name = name;
    }
}