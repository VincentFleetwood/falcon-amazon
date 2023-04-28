using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

// Creates the application builder
var builder = WebApplication.CreateBuilder(args);

// Adds the database to the dependency injection container
builder.Services.AddDbContext<IDatabaseContext, DatabaseContext>();

// Add the customer service to the dependency injection container
builder.Services.AddScoped<CustomerService>();

// Builds the app
var app = builder.Build();

// Replaces repated routes for ease of use
RouteGroupBuilder customers = app.MapGroup("/customers");

// Creates the endpoint definitions
customers.MapPost("/", AddNewCustomer);
customers.MapGet("/", GetCustomerFromID);

// Starts the API
app.Run();


static async Task<IResult> AddNewCustomer([FromBody] Customer customer, [FromServices] CustomerService customerService) 
{
    return Results.Ok();
}

static async Task<IResult> GetCustomerFromID(int customerID, [FromServices] CustomerService customerService)
{
    return Results.Ok();
}
