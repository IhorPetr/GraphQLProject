using GraphQLApi.Interfaces;
using GraphQLApi.Models;

namespace GraphQLApi.Services
{
    public class ProductService : IProduct
    {
        private static List<Product> products = new List<Product>()
        { 
            new Product() 
            { 
                Id = 0,
                Name = "Coffe",
                Price = 45.6        
            },
            new Product()
            {
                Id = 0,
                Name = "Tea",
                Price = 23
            }
        };
        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public void DeleteProduct(int id)
        {
            products.RemoveAt(id);
        }

        public List<Product> GetAllProduct()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.Find(x => x.Id == id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            products[id] = product;
            return product;
        }
    }
}
