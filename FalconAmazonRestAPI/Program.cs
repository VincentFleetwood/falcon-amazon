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
string connectionString = builder.Configuration.GetConnectionString("AmyConnection");
builder.Services.AddDbContext<IDatabaseContext, DatabaseContext>(options => options.UseSqlServer(connectionString));

// Add the customer service to the dependency injection container
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ProductService>();


// Builds the app
var app = builder.Build();

// Replaces repated routes for ease of use
RouteGroupBuilder customers = app.MapGroup("/customers");
RouteGroupBuilder products = app.MapGroup("/products");


// Creates the endpoint definitions
customers.MapPost("/", AddNewCustomer);
customers.MapGet("/{customerID}", GetCustomerFromID);
customers.MapPut("/{customerID}", UpdateCustomerFromID);
customers.MapDelete("/{customerID}", DeleteCustomerFromID);

products.MapGet("/", GetAllProducts);

// Starts the API
app.Run();


static async Task<IResult> AddNewCustomer([FromBody] Customer customer, [FromServices] CustomerService customerService) 
{
    return await customerService.AddNewCustomerAsync(customer);
}

static async Task<IResult> GetCustomerFromID(int customerID, [FromServices] CustomerService customerService)
{
    var returnedCustomer = await customerService.GetCustomerFromIDAsync(customerID);
    return Results.Ok(returnedCustomer);
}

static async Task<IResult> UpdateCustomerFromID(int customerID, [FromBody] Customer customer, [FromServices] CustomerService customerService)
{
    var returnedCustomer = await customerService.UpdateCustomerFromIDAsync(customerID, customer);
    return Results.Ok(returnedCustomer);
}

static async Task<IResult> DeleteCustomerFromID(int customerID, [FromServices] CustomerService customerService)
{
    var returnedCustomer = await customerService.DeleteCustomerFromIDAsync(customerID);
    return Results.Ok(returnedCustomer);
}

static async Task<IResult> GetAllProducts([FromServices] ProductService productService)
{
    var returnedProducts = await productService.GetAllProductsAsync();
    return Results.Ok(returnedProducts);
}
