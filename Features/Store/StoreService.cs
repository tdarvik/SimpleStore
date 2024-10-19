namespace SimpleStore.Features.Store;
using System.Collections.Generic;
using System.Linq;

public class StoreService
{
    private readonly List<Item> _items;

    public StoreService(List<Item> items)
    {
        _items = items;
    }

    public StoreService()
    {
        _items =
        [
            new() { Name = "Melk", Description = "En liter melk", Price = 19.90M },
            new() { Name = "Brød", Description = "Hjemmebakt brød", Price = 29.50M },
            new() { Name = "Ost", Description = "500g gulost", Price = 59.90M },
            new() { Name = "Epler", Description = "Pakke med 6 epler", Price = 25.00M },
            new() { Name = "Kaffe", Description = "250g filtermalt kaffe", Price = 39.90M },
            new() { Name = "Sjokolade", Description = "200g melkesjokolade", Price = 49.90M },
            new() { Name = "Yoghurt", Description = "4-pack med vaniljeyoghurt", Price = 34.90M },
            new() { Name = "Appelsiner", Description = "Pakke med 4 appelsiner", Price = 20.00M },
            new() { Name = "Poteter", Description = "2kg norske poteter", Price = 29.90M },
            new() { Name = "Smør", Description = "250g ekte smør", Price = 32.90M }
        ];
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void RemoveItem(string id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            _items.Remove(item);
        }
    }

    public List<Item> GetItems()
    {
        return new List<Item>(_items);
    }
}
