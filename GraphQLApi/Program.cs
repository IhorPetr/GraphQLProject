using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLApi.Data;
using GraphQLApi.Interfaces;
using GraphQLApi.Mutation;
using GraphQLApi.Query;
using GraphQLApi.Schema;
using GraphQLApi.Services;
using GraphQLApi.Type;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IProduct, ProductService>();
builder.Services.AddTransient<ProductType>();
builder.Services.AddTransient<ProductQuery>();
builder.Services.AddTransient<ProductMutation>();
builder.Services.AddTransient<ISchema, ProductSchema>();

builder.Services.AddGraphQL(options => 
{
    options.EnableMetrics = false;
}).AddSystemTextJson();

builder.Services.AddDbContext<GraphQLDbContext>(options => options.UseSqlServer(@"Data Source= localhost\SQLEXPRESS;Initial Catalog=GraphQLDb;Integrated Security = True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
{
    var graphQLDbContext = scope.ServiceProvider.GetRequiredService<GraphQLDbContext>();
    graphQLDbContext.Database.EnsureCreated();
}
app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();
app.Run();
