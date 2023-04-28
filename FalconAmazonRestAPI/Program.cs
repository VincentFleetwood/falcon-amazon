using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

// Creates the application builder
var builder = WebApplication.CreateBuilder(args);

// Add configuration sources
builder.Configuration.AddJsonFile("appsettings.json", optional: true);

// Adds the database to the dependency injection container
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IDatabaseContext, DatabaseContext>(options => options.UseSqlServer(connectionString));

// Add the customer service to the dependency injection container
builder.Services.AddScoped<CustomerService>();

// Builds the app
var app = builder.Build();

// Replaces repated routes for ease of use
RouteGroupBuilder customers = app.MapGroup("/customers");

// Creates the endpoint definitions
customers.MapPost("/", AddNewCustomer);
customers.MapGet("/{customerID}", GetCustomerFromID);

// Starts the API
app.Run();


static async Task<IResult> AddNewCustomer([FromBody] Customer customer, [FromServices] CustomerService customerService) 
{
    var returnedCustomer = await customerService.AddNewCustomerAsync(customer);
    return Results.Ok(returnedCustomer);
}

static async Task<IResult> GetCustomerFromID(int customerID, [FromServices] CustomerService customerService)
{
    var returnedCustomer = await customerService.GetCustomerFromIDAsync(customerID);
    return Results.Ok(returnedCustomer);
}
