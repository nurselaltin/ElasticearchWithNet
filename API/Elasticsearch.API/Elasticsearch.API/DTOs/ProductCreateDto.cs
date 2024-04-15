using Elasticsearch.API.Models;

namespace Elasticsearch.API.DTOs
{
    //Record : nesnenin üretildikten sonra değiştirilememesi anlamına gelir
    //Örneğin mikroservis mimamride bir sınıf  4 farklı serviste kullanıldığında propertisi değiştirildiğinde nerede değiştirildiğini bulmak zor olur.Ama recordları kullandığımız noktada
    //değiştirme anında hata fırlatır.
    public record ProductCreateDto(string Name, decimal Price, int Stock, ProductFeatureDTO Feature)
    {
        //İlgili kodu ilgili yere yaklaştır : Clean Code
        public Product CreateProduct()
        {
            return new Product { 
                Name = Name, 
                Price = Price, 
                Stock = Stock,
                Feature = new ProductFeature() { Width = Feature.Width, Height = Feature.Height }   
            }
        }
    }
}
