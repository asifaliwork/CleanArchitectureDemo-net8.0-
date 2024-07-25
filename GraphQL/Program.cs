using GraphQL;
using GraphQL.Mutation;
using GraphQL.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGraphQLServer()
    .AddMutationType<ItemMutations>()
    .AddQueryType<Query>();

builder.Services.AddGraphQlDI();


var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

//app.MapGraphQL("/graphql");

app
    .UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL("/GraphQl");
    });




app.MapControllers();

app.Run();
