using GraphQLApi.Models;

namespace GraphQLApi.Interfaces
{
    public interface IProduct
    {
       List<Product> GetAllProduct();
       Product AddProduct(Product product);
       Product UpdateProduct(int id, Product product);
       void DeleteProduct(int id);
       Product GetProductById(int id);
    }
}
