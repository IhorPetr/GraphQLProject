using GraphQLApi.Mutation;
using GraphQLApi.Query;

namespace GraphQLApi.Schema
{
    public class ProductSchema : GraphQL.Types.Schema
    {
        public ProductSchema(ProductQuery productQuery, ProductMutation productMutation)
        {
            Query = productQuery;
            Mutation = productMutation;
        }
    }
}
