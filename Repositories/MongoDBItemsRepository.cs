using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories;

public class MongoDBItemsRepository : IItemsRepository
{
    private const string databaseName = "catalog";
    private const string collectionName = "items";
    private readonly IMongoCollection<Item> itemsCollections;
    private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

    public MongoDBItemsRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase(databaseName);
        itemsCollections = database.GetCollection<Item>(collectionName);
    }
    public Item GetItem(Guid id)
    {
        var filter = filterBuilder.Eq(item => item.Id, id);
        return itemsCollections.Find(filter).SingleOrDefault();
    }

    public IEnumerable<Item> GetItems()
    {
        return itemsCollections.Find(new BsonDocument()).ToList();
    }

    public void CreateItem(Item item)
    {
        itemsCollections.InsertOne(item);
    }

    public void UpdateItem(Item item)
    {
        var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
        itemsCollections.ReplaceOne(filter, item);
    }

    public void DeleteItem(Guid id)
    {
        var filter = filterBuilder.Eq(existingItem => existingItem.Id, id);
        itemsCollections.DeleteOne(filter);    
    }
}