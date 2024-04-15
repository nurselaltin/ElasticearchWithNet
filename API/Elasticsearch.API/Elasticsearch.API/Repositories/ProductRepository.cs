using Elasticsearch.API.Models;
using Nest;

namespace Elasticsearch.API.Repositories
{
    public class ProductRepository
    {
        private readonly ElasticClient _client;
        public ProductRepository(ElasticClient  client)
        {
            _client = client;
        }

        //index = datayı  kayıt etmek demek
        public async Task<Product?> SaveAsync(Product newProduct)
        {
            newProduct.Created = DateTime.Now;

            var response = await _client.IndexAsync(newProduct, x => x.Index("products"));

            //Clean Code => fast fail
            if(!response.IsValid) return null;

            newProduct.Id = response.Id;

            return newProduct;
        }
    }
}
