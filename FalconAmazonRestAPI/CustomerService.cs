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
        _customerValidator = new CustomerValidator(_dbContext);
    }

    public async Task<Customer> AddNewCustomerAsync(Customer customer) 
    {
        _customerValidator.Validate(customer);

        _dbContext.tblCustomers.Add(customer);

        // Save changes to the database
        await _dbContext.SaveChangesToDatabaseAsync();

        return customer;
    }

    public async Task<CustomerItemDTO> GetCustomerFromIDAsync(int customerID)
    {
        // Get user by ID from the database
        var customer = await _dbContext.tblCustomers.FindAsync(customerID);

        // Converts the user into a DTO to protect data
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
}
