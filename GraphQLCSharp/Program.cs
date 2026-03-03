using GraphQLCSharp.Data;
using GraphQLCSharp.GraphQLService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQLServer");

// DbContext
builder.Services.AddDbContext<AnimalDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// GraphQL services
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting()
    .AddPagingArguments();


var app = builder.Build();


app.MapGraphQL();

app.Run();
