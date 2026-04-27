using Microsoft.Azure.Cosmos;
using ProductsWebApp.Models;

namespace ProductsWebApp.Services
{

    public class ProductService : IProductService
    {
        private readonly Container _container;

        public ProductService(CosmosClient client,IConfiguration configuration)
        {

            _container = client.GetContainer(
                configuration["CosmosDB:DatabaseName"],
                configuration["CosmosDB:ContainerName"]
            );
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<Product>(
                new QueryDefinition("SELECT * FROM c")
            );

            List<Product> results = new();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        public async Task<Product> GetAsync(string id, string subCategory)
        {
            var response = await _container.ReadItemAsync<Product>(
                id,
                new PartitionKey(subCategory)
            );

            return response.Resource;
        }

        public async Task AddAsync(Product product)
        {
            product.Id ??= Guid.NewGuid().ToString();

            await _container.CreateItemAsync(
                product,
                new PartitionKey(product.SubCategory)
            );
        }

        public async Task UpdateAsync(Product product)
        {
            await _container.UpsertItemAsync(
                product,
                new PartitionKey(product.SubCategory)
            );
        }

        public async Task DeleteAsync(string id, string subCategory)
        {
            await _container.DeleteItemAsync<Product>(
                id,
                new PartitionKey(subCategory)
            );
        }

    }
}
