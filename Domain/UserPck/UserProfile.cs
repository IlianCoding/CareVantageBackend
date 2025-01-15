namespace CVB.BL.Domain.UserPck;

public class UserProfile
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Address { get; set; }
    public required string PostalCode { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    
    public virtual required User User { get; set; }
}