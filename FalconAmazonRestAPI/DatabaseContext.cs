﻿using Microsoft.EntityFrameworkCore;

// This class represents the database context and inherits from the DbContext class from Entity Framework Core..
public class DatabaseContext : DbContext, IDatabaseContext
{
    public DbSet<Customer> tblCustomers { get; set; }// A DbSet property for the Customer 

    // The constructor of the DatabaseContext class takes an instance of DbContextOptions, which is used to configure the database context.
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    // The OnConfiguring method is overridden to configure the database connection and other options.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=A-MAC\\SQLSERVER2019;Database=ShareSpaceDB;User Id=guestLogin;Password=guestpassword;Encrypt=False;");
    }

    // This method saves changes made to the database.
    public async Task SaveChangesToDatabaseAsync()
    {
        await SaveChangesAsync();
    }
}
