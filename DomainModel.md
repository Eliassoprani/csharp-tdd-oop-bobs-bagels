# Bobs Bagels Domain model

## User Stories

As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket

As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket

As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.

As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.

As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.

As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.

As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.

## Domain Model

Class InventoryItem
PROPERTIES
    public string SKU { get; set; }
    public float Price { get; set; }
    public string Name { get; set; }
    public string Variant { get; set; }
Constructor(string sku, float price, string name, string variant)

Class BobsInventory
PROPERTIES
    private Dictionary <string, InventoryItem> inventory

METHODS
    Constructor()
        when instantiated this object calls method FillInventory to fill the inventory with InventoryItems to desired inventory
    public List<InventoryItem> GetItem(string SKU, string SKUFilling = null)
        returns List<InventoryItemw> if SKU exists in inventory with either 1 inventory item if only bagel or coffee. If both bagel and filling List<InventoryItem> with two inventory items bagel and filling list
            if item does not exist in inventory return null
    private void FillInventory()
        method to fill inventory with all items

Class Basket:
    Properties:
        private int BasketCapacity
        private List <InventoryItem> ItemsInBasket
        private BobsInventory BobsInventory
    Methods:
        float CostOfItem(string SKU)
            check the cost of an item in BobsInventory.inventory and return the cost.
                If SKU does not exist in .inventory return 0
        float TotalPrice()
            loop through ItemsInBasket and count Price of each Item in List and return float totalprice
        string Add(string SKU, List<string> SKUFilling = null)
            returns "{ItemVariant} {itemName} added to your basket" if SKU exists in inventory and filling is null and SKU is not a filling
            returns "{ItemVariant} {itemName} with {fillingName} {fillingName2} {fillingName ... } filling added to your basket" if SKU exists in inventory and filling is not null and SKU is a bagel
            returns "Can only add filling to bagel" if SKU exists in inventory and filling is not null and SKU is not a bagel
            returns "{SKU} is not an item on our menu" if SKU does not exist in Bobsinventory.inventory,
            returns "Your basket is full" if ItemsInBasket.Count == inventory.basketCapacity
        string Remove(List<InventoryItem> item)
            returns "item removed from your basket" if item exists in ItemsInBasket
            returns "item does not exist in basket" if item does not exist in ItemsInBasket
        string UpdateCapacity(int newCapacity)
            basketCapacity = newCapacity; Returns "New basket capacity is {newCapacity}"
                if newCapacity < 1 return "basket capacity cannot be smaller than 1"
