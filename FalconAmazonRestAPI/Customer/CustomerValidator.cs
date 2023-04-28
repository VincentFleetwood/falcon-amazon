public class CustomerValidator : ICustomerValidator
{
    private readonly IDatabaseContext _dbContext;

    public CustomerValidator(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Validate(Customer customer)
    {
        // Perform validation checks, including checking if the customer already exists in the database
    }
}