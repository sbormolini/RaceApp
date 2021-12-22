namespace RaceApp.DataAccess.Data;

public interface ICosmosDbClientFactory
{
    ICosmosDbClient GetClient(string collectionName);
}
