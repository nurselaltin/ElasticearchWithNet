using Elasticsearch.API.DTOs;
using Elasticsearch.API.Repositories;
using System.Net;

namespace Elasticsearch.API.Services
{
    //Servis katmanından dönüş modeli hepsinde aynı olmalı
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public  async Task<ResponseDTO<ProductDTO>> SaveAsync(ProductCreateDto request)
        {
            var resProduct = await _productRepository.SaveAsync(request.CreateProduct());

            if (resProduct == null) {
                return ResponseDTO<ProductDTO>.Fail(new List<string> { "" }, HttpStatusCode.InternalServerError);
            }

            return ResponseDTO<ProductDTO>.Succes(resProduct.CreateProductDTO(), HttpStatusCode.Created);
        }
    }
}
