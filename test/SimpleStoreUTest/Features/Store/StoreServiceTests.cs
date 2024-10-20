using SimpleStore.Features.Store;
using SimpleStore.Shared;

namespace SimpleStoreUTest.Store;

public class StoreServiceTests
{
    [Fact]
    public void ConstructsEmptyItemList()
    {
        Assert.Empty(new StoreService([]).GetItems());
    }

    [Fact]
    public void ConstructsPresetItemList()
    {
        Assert.Equal(10, new StoreService().GetItems().Count);
    }

    [Fact]
    public void AddItem_AddsItem()
    {
        var service = new StoreService([]);
        service.AddItem(new Item() { Name = "Name", Description = "Description" });
        Assert.Single(service.GetItems());
    }

    [Fact]
    public void AddItem_AddsSameItemTwice_Throws()
    {
        var service = new StoreService([]);
        Item item = new() { Name = "Name", Description = "Description" };
        service.AddItem(item);
        var exception = Assert.Throws<ArgumentException>(() => service.AddItem(item));
        Assert.Equal($"There's already an item with the id {item.Id}", exception.Message);
    }

    [Fact]
    public void RemoveItem_RemovesItem()
    {
        var service = new StoreService([]);
        Item item = new() { Name = "Name", Description = "Description" };
        service.AddItem(item);
        Assert.Single(service.GetItems());
        service.RemoveItem(item.Id);
        Assert.Empty(service.GetItems());
    }
    [Fact]
    public void RemoveItem_NoMatchFound_Throws()
    {
        var service = new StoreService([]);
        var id = "123";
        var exception = Assert.Throws<ArgumentException>(() => service.RemoveItem(id));
        Assert.Equal($"Cannot find item to delete with id {id}", exception.Message);
    }

    [Fact]
    public void RemoveItem_HasExistingItem_NoMatchFound_Throws()
    {
        var service = new StoreService([]);
        Item item = new() { Name = "Other item", Description = "Description" };
        service.AddItem(item);

        var id = "123";
        var exception = Assert.Throws<ArgumentException>(() => service.RemoveItem(id));
        Assert.Equal($"Cannot find item to delete with id {id}", exception.Message);
    }
}
