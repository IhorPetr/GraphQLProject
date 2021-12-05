using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Mutation;
using GraphQLApi.Query;
using GraphQLApi.Schema;
using GraphQLApi.Services;
using GraphQLApi.Type;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IProduct, ProductService>();
builder.Services.AddSingleton<ProductType>();
builder.Services.AddSingleton<ProductQuery>();
builder.Services.AddSingleton<ProductMutation>();
builder.Services.AddSingleton<ISchema, ProductSchema>();

builder.Services.AddGraphQL(options => 
{
    options.EnableMetrics = false;
}).AddSystemTextJson();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();
app.Run();
