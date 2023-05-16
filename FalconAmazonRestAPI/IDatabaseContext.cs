using Microsoft.EntityFrameworkCore;

// This interface represents the database context and defines the properties and methods required by the database context
public interface IDatabaseContext
{
    DbSet<Customer> tblCustomers { get; set; } // A DbSet property for the Customer entity
    Task SaveChangesToDatabaseAsync(); // A method for saving changes made to the database
}
