namespace SimpleStore.Features.Store;

public class Item
{
    public string Id { get; private set; }
    private string _name;
    private string _description;
    public decimal Price { get; set; }

    public required string Name
    {
        get => _name;
        set => _name = value?.Trim() ?? string.Empty;
    }

    public required string Description
    {
        get => _description;
        set => _description = value?.Trim() ?? string.Empty;
    }

    public Item(string name, string description, decimal price)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Description = description;
        Price = price;
    }
    public Item()
    {
        Id = Guid.NewGuid().ToString();
    }
}
