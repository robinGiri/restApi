using Catalog.Dtos;
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

}