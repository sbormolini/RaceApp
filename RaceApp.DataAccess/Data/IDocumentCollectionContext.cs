using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using RaceApp.Api.Models;

namespace RaceApp.DataAccess.Data;

public interface IDocumentCollectionContext<in T> where T : Entity
{
    string CollectionName { get; }

    string GenerateId(T entity);

    PartitionKey ResolvePartitionKey(string entityId);
}
