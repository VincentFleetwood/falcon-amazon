// Represents a Data Transfer Object (DTO) for the Customer entity
public class CustomerItemDTO 
{
    public int? CustomerID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DOB { get; set; }

    // Default constructor
    public CustomerItemDTO() { }

    // Constructor that initializes the DTO from a Customer entity
    public CustomerItemDTO(Customer customerItem) =>
        // Using tuple deconstruction to set the values of the DTO properties
        (CustomerID, FirstName, LastName, EmailAddress, PhoneNumber, DOB) =
        (customerItem.CustomerID, customerItem.FirstName, customerItem.LastName, customerItem.EmailAddress, customerItem.PhoneNumber, customerItem.DOB);
}
