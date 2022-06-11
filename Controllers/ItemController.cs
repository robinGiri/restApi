using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[ApiController]
[Route("items")]
public class ItemController : ControllerBase
{
    private readonly InMemItemsRepository _repository;

    public ItemController()
    {
        _repository = new InMemItemsRepository();
    }

    [HttpGet]
    public IEnumerable<Item> GetItems()
    {
        var items = _repository.GetItems();
        return items;
    }

    [HttpGet("{id}")]
    public ActionResult<Item> GetItem(Guid id)
    {
        var item = _repository.GetItem(id);

        if (item is null)
        {
            NotFound();
        }

        return item;
    }

}