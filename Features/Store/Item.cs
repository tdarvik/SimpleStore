namespace SimpleStore.Features.Store;

public class Item
{
    public string Id { get; private set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }

    public Item() => Id = GenerateRandomId();

    private static string GenerateRandomId() => Guid.NewGuid().ToString();
}
