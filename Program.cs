using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using ToDoListQL.GraphQL;
using ToDoQl.Data;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPooledDbContextFactory<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<ListType>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions()
    .AddProjections()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();


var app = builder.Build();

app.UseRouting();

app.UseWebSockets();

app.MapGraphQL();

app.UseGraphQLVoyager(
    "/graphql-ui", 
    new VoyagerOptions() {
        GraphQLEndPoint = "/graphql"
    }
);


app.Run();
