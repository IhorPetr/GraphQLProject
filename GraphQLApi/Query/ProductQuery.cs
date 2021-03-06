using GraphQL;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Type;

namespace GraphQLApi.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProduct productService)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => productService.GetAllProduct());
            Field<ProductType>("product", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }), 
                resolve: context => productService.GetProductById(context.GetArgument<int>("id")));
        }
    }
}
