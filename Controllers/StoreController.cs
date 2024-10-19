using Microsoft.AspNetCore.Mvc;
using SimpleStore.Features.Store;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly StoreService _storeService;

    public StoreController(StoreService storeService) => _storeService = storeService;

    [HttpGet("{id}")]
    public ActionResult<ItemDTO> GetItem(string id)
    {
        var item = _storeService.GetItems().FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return new ItemDTO(item);
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveItem(string id)
    {
        var item = _storeService.GetItems().FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        _storeService.RemoveItem(id);
        return NoContent();
    }

    [HttpGet]
    public ActionResult<IEnumerable<ItemDTO>> GetAllItems()
    {
        var items = _storeService.GetItems().Select(item => new ItemDTO(item));
        return Ok(items);
    }

    [HttpPost]
    public IActionResult AddItem([FromBody] ItemDTO item)
    {
        var name = item.Name.Trim();
        var description = item.Description.Trim();

        if (item == null || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || item.Price <= 0)
            return BadRequest("Ulovlig data");

        _storeService.AddItem(new Item()
        {
            Name = name,
            Description = description,
            Price = item.Price
        });
        return Ok();
    }
}
