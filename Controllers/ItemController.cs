using Catalog.Dto;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[ApiController]
[Route("items")]
public class ItemController : ControllerBase
{
    private readonly IItemsRepository _repository;

    public ItemController(IItemsRepository repository)
    {
        this._repository = repository;
    }

    [HttpGet]
    public IEnumerable<ItemDto> GetItems()
    {
        var items = _repository.GetItems().Select(item => item.AsDto());
        return items;
    }

    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItem(Guid id)
    {
        var item = _repository.GetItem(id);

        if (item is null)
        {
            NotFound();
        }

        return item.AsDto();
    }

    [HttpPost]
    public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
    {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = itemDto.Name,
            Price = itemDto.Price,
            CreatedDate = DateTimeOffset.UtcNow,
        };

        _repository.CreateItem(item);

        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
    {
        var existingItem =  _repository.GetItem(id);

        if (existingItem is null)
        {
            return NotFound();
        }

        Item updatedItem = existingItem with
        {
            Name = itemDto.Name,
            Price = itemDto.Price
        };
        
        _repository.UpdateItem(updatedItem);

        return NoContent();

    }

    [HttpDelete("{id}")]

    public ActionResult DeleteItem(Guid id)
    {
        var existingItem = _repository.GetItem(id);
        if (existingItem is null)
        {
            NotFound();
        }
        
        _repository.DeleteItem(id);

        return NoContent();
    }
}