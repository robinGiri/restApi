using Catalog.Entities;

namespace Catalog.Repositories
{
  public class InMemItemsRepository : IItemsRepository
  {
    private readonly List<Item> items = new()
    {
      new Item { Id= Guid.NewGuid(), Name= "Robin", Price = 8, CreatedDate = DateTimeOffset.UtcNow},
      new Item { Id= Guid.NewGuid(), Name= "Ashna", Price = 80, CreatedDate = DateTimeOffset.UtcNow},
      new Item { Id= Guid.NewGuid(), Name= "Bijay", Price = 20, CreatedDate = DateTimeOffset.UtcNow},
    };

    public IEnumerable<Item> GetItems()
    {
      return items;
    }

    public void CreateItem(Item item)
    {
      items.Add(item);
    }

    public void UpdateItem(Item item)
    {
      var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
      items[index] = item;
    }

    public void DeleteItem(Guid id)
    {
      var index = items.FindIndex(existingItem => existingItem.Id == id);
      items.RemoveAt(index);
    }

    public Item GetItem(Guid id)
    {
      return items.Where(item => item.Id == id).SingleOrDefault();
    }

  }
}