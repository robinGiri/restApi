using Catalog.Entities;

namespace Catalog.Repositories
{
  public class InMemItemsRepository
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

    public Item GetItem(Guid id) {
      return items.Where(item => item.Id == id).SingleOrDefault();
    }

  }
}