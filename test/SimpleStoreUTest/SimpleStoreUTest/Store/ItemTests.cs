using SimpleStore.Features.Store;

namespace SimpleStoreUTest.Store;

public class ItemTests
{
    [Fact]
    public void TrimsName()
    {
        Item item = new() { Name = " test ", Description = "Description", Price = 1m };
        Assert.Equal("test", item.Name);
    }

    [Fact]
    public void TrimsDescription()
    {
        Item item = new() { Name = "Test", Description = " description ", Price = 1m };
        Assert.Equal("description", item.Description);
    }
}
