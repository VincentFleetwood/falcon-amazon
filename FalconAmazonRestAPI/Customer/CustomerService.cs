using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;

public class CustomerService
{
    private readonly IDatabaseContext _dbContext;
    public ICustomerValidator _customerValidator { get; set; }

    public CustomerService(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;

        // Initializes customer validator
        _customerValidator = new CustomerValidator(_dbContext);
    }

    // Adds a new customer to the database
    public async Task<IResult> AddNewCustomerAsync(Customer customer)
    {
        // Validates customer data
        _customerValidator.Validate(customer);

        // Adds the customer to the database
        _dbContext.tblCustomers.Add(customer);

        // Saves changes to the database
        await _dbContext.SaveChangesToDatabaseAsync();

        return Results.Ok(customer);
    }

    // Retrieves a customer from the database by ID
    public async Task<CustomerItemDTO> GetCustomerFromIDAsync(int customerID)
    {
        // Retrieves the customer from the database
        var customer = await _dbContext.tblCustomers.FindAsync(customerID);

        // Converts the customer to a DTO to protect sensitive data
        var customerDTO = new CustomerItemDTO()
        {
            CustomerID = customer.CustomerID,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            EmailAddress = customer.EmailAddress,
            PhoneNumber = customer.PhoneNumber,
            DOB = customer.DOB,
        };

        return customerDTO;
    }

    // Updates a customer in the database
    public async Task<Customer> UpdateCustomerFromIDAsync(int customerID, Customer updatedCustomer)
    {
        // Retrieves the customer from the database
        var customer = await _dbContext.tblCustomers.FindAsync(customerID);

        // Validates updated customer data
        _customerValidator.Validate(updatedCustomer);

        // Updates the customer data
        customer.FirstName = updatedCustomer.FirstName;
        customer.LastName = updatedCustomer.LastName;
        customer.EmailAddress = updatedCustomer.EmailAddress;
        customer.PhoneNumber = updatedCustomer.PhoneNumber;
        customer.DOB = updatedCustomer.DOB;

        // Saves changes to the database
        await _dbContext.SaveChangesToDatabaseAsync();

        return customer;
    }

    // Delete a customer from the database
    public async Task<Customer> DeleteCustomerFromIDAsync(int customerID)
    {
        // Retrieves the customer from the database
        var customer = await _dbContext.tblCustomers.FindAsync(customerID);

        // Remove the customer
        _dbContext.tblCustomers.Remove(customer);

        // Saves changes to the database
        await _dbContext.SaveChangesToDatabaseAsync();

        return customer;
    }
}
