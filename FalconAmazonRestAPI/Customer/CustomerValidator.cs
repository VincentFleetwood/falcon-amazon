using System.Globalization;
using System.Text.RegularExpressions;

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
        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
        }

        if (string.IsNullOrEmpty(customer.FirstName))
        {
            throw new ArgumentException("First name cannot be null or empty.", nameof(customer.FirstName));
        }

        if (string.IsNullOrEmpty(customer.LastName))
        {
            throw new ArgumentException("Last name cannot be null or empty.", nameof(customer.LastName));
        }

        if (string.IsNullOrEmpty(customer.EmailAddress))
        {
            throw new ArgumentException("Email address cannot be null or empty.", nameof(customer.EmailAddress));
        }

        if (!IsValidEmail(customer.EmailAddress))
        {
            throw new ArgumentException("Email address is not in a valid format.", nameof(customer.EmailAddress));
        }

        if (string.IsNullOrEmpty(customer.PhoneNumber))
        {
            throw new ArgumentException("Phone number cannot be null or empty.", nameof(customer.PhoneNumber));
        }

        if (!IsValidPhoneNumber(customer.PhoneNumber))
        {
            throw new ArgumentException("Phone number is not in a valid format.", nameof(customer.PhoneNumber));
        }

        if (customer.DOB == null)
        {
            throw new ArgumentException("Date of birth cannot be null.", nameof(customer.DOB));
        }

        if (!IsValidDOB(customer.DOB))
        {
            throw new ArgumentException("Date of birth is not in a valid format.", nameof(customer.DOB));
        }

        // Check if identical record already exists
        var existingCustomer = _dbContext.tblCustomers.FirstOrDefault(c => c.FirstName == customer.FirstName
            && c.LastName == customer.LastName && c.EmailAddress == customer.EmailAddress
            && c.PhoneNumber == customer.PhoneNumber && c.DOB == customer.DOB);

        if (existingCustomer != null)
        {
            throw new InvalidOperationException("An identical customer record already exists in the database.");
        }

        // Check if email address is unique
        var existingEmail = _dbContext.tblCustomers.FirstOrDefault(c => c.EmailAddress == customer.EmailAddress);

        if (existingEmail != null)
        {
            throw new InvalidOperationException("Another customer with the same email address already exists in the database.");
        }

        // Check if phone number is unique
        var existingPhoneNumber = _dbContext.tblCustomers.FirstOrDefault(c => c.PhoneNumber == customer.PhoneNumber);

        if (existingPhoneNumber != null)
        {
            throw new InvalidOperationException("Another customer with the same phone number already exists in the database.");
        }
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private bool IsValidPhoneNumber(string phoneNumber)
    {
        var regex = new Regex(@"^\+447\d{9}$");
        return regex.IsMatch(phoneNumber);
    }

    public bool IsValidDOB(DateTime? dob)
    {
        if (dob > DateTime.UtcNow)
        {
            return false; // Date of birth is in the future
        }
        else
        {
            return true; // Valid date of birth
        }
    }
}