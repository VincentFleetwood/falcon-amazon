using Microsoft.EntityFrameworkCore;

// This class represents the database context and inherits from the DbContext class from Entity Framework Core..
public class DatabaseContext : DbContext, IDatabaseContext
{
    public DbSet<Customer> tblCustomers { get; set; }// A DbSet property for the Customer 

    // The constructor of the DatabaseContext class takes an instance of DbContextOptions, which is used to configure the database context.
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    // This method saves changes made to the database.
    public async Task SaveChangesToDatabaseAsync()
    {
        await SaveChangesAsync();
    }
}
