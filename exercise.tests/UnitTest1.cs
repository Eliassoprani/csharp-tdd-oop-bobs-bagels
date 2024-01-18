using main;

namespace exercise.tests;

public class Tests
{
    private Basket _basket;
    [SetUp]
    public void Setup()
    {
        _basket = new Basket(new BobsInventory());
    }

    [Test]
    public void AddTest1()
    {
        List<string> fillings = new List<string>();
        fillings.Add("FILB");
        fillings.Add("FILE");
        fillings.Add("FILC");
        string result = _basket.Add("BGLO", fillings);
        Assert.AreEqual("Onion Bagel with Bacon Egg Cheese filling added to your basket", result);
    }

    [Test]
    public void AddTest2()
    {
        string result = _basket.Add("BGLO");
        Assert.AreEqual("Onion Bagel added to your basket", result);
    }

    [Test]
    public void AddTest3()
    {
        string result = _basket.Add("apple");
        Assert.AreEqual("apple is not an item on our menu", result);
    }

    [Test]
    public void AddTest4()
    {
        List<string> fillings = new List<string>();
        fillings.Add("FILB");
        string result = _basket.Add("COFB", fillings);
        Assert.AreEqual("Can only add filling to bagel", result);
    }
    [Test]
    public void AddTest5()
    {
        List<string> fillings = new List<string>();
        fillings.Add("FILB");
        string result = _basket.Add("FILE", fillings);
        Assert.AreEqual("Can only add filling to bagel", result);
    }

    [Test]
    public void AddTest6()
    {
        _basket.UpdateCapacity(2);
        _basket.Add("COFB");
        _basket.Add("BGLO");
        string result = _basket.Add("BGLE");
        Assert.AreEqual("Your basket is full", result);
    }

    [Test]
    public void TotalPriceTest1()
    {
        List<string> fillings = new List<string>();
        fillings.Add("FILB");
        _basket.Add("COFB");
        _basket.Add("BGLO", fillings);
        _basket.Add("BGLP");
        float result = _basket.TotalPrice();
        Assert.AreEqual(1.99f, result);
    }

    [Test]
    public void CostOfItemTest1()
    {
        float result = _basket.CostOfItem("COFB");
        Assert.AreEqual(0.99f, result);
    }

    [Test]
    public void CostOfItemTest2()
    {
        float result = _basket.CostOfItem("apple");
        Assert.AreEqual(0, result);
    }

    [Test]
    public void CostOfItemTest3()
    {
        float result = _basket.CostOfItem("FILB");
        Assert.AreEqual(0.12f, result);
    }

    [Test]
    public void UpdateCapacityTest1()
    {
        string result = _basket.UpdateCapacity(5);
        Assert.AreEqual("New basket capacity is 5", result);
    }

    [Test]
    public void UpdateCapacityTest2()
    {
        string result = _basket.UpdateCapacity(-5);
        Assert.AreEqual("basket capacity cannot be smaller than 1", result);
    }

    [Test]
    public void RemoveTest1()
    {
        string inventoryMessage;
        BobsInventory bobsInventory = new BobsInventory();
        List<string> testfillings = new List<string>();
        testfillings.Add("FILE");
        InventoryItem itemToRemove = bobsInventory.GetItem("BGLO", testfillings, out inventoryMessage);

        List<string> fillings = new List<string>();
        fillings.Add("FILE");
        _basket.Add("BGLO", fillings);
        string result = _basket.Remove(itemToRemove);
        Assert.AreEqual("item removed from your basket", result);
    }
    [Test]
    public void RemoveTest2()
    {
        string inventoryMessage;
        BobsInventory bobsInventory = new BobsInventory();
        InventoryItem itemToRemove = bobsInventory.GetItem("BGLO", out inventoryMessage);

        List<string> fillings = new List<string>();
        fillings.Add("FILE");
        _basket.Add("BGLO", fillings);
        string result = _basket.Remove(itemToRemove);
        Assert.AreEqual("item does not exist in basket", result);
    }
}