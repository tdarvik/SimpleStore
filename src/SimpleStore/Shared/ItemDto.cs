namespace SimpleStore.Shared;

public class ItemDTO
{
    public string? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public ItemDTO() { }

    public ItemDTO(Item item)
    {
        Id = item.Id;
        Name = item.Name;
        Description = item.Description;
        Price = item.Price;
    }
}
