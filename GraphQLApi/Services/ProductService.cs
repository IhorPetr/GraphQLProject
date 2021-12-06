using GraphQLApi.Data;
using GraphQLApi.Interfaces;
using GraphQLApi.Models;

namespace GraphQLApi.Services
{
    public class ProductService : IProduct
    {
        private GraphQLDbContext graphQLDbContext;
        public ProductService(GraphQLDbContext graphQLDbContext)
        {
            this.graphQLDbContext = graphQLDbContext;
        }
        public Product AddProduct(Product product)
        {
            graphQLDbContext.Product.Add(product);
            graphQLDbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var productObj = graphQLDbContext.Product.Find(id);
            graphQLDbContext.Product.Remove(productObj);
            graphQLDbContext.SaveChanges();
        }

        public List<Product> GetAllProduct()
        {
            return graphQLDbContext.Product.ToList();
        }

        public Product GetProductById(int id)
        {
            return graphQLDbContext.Product.Find(id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            var productObj = graphQLDbContext.Product.Find(id);
            productObj.Name = product.Name;
            productObj.Price = product.Price;
            graphQLDbContext.SaveChanges();
            return product;
        }
    }
}
