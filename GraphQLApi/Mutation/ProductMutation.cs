using GraphQL;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Models;
using GraphQLApi.Type;

namespace GraphQLApi.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {
            Field<ProductType>("createProduct", arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }), 
                resolve: context => productService.AddProduct(context.GetArgument<Product>("product")));
            Field<ProductType>("updateProduct", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }, new QueryArgument<ProductInputType> { Name = "product" }), 
                resolve: context => productService.UpdateProduct(context.GetArgument<int>("id"), context.GetArgument<Product>("product")));
            Field<StringGraphType>("deleteProduct", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }), 
                resolve: context => { productService.DeleteProduct(context.GetArgument<int>("id")); return $"Product {context.GetArgument<int>("id")} was delete"; });
        }
    }
}
