namespace CVB.BL.Domain.User;

public class User
{
    public Guid Id { get; set; }
    public required string KeycloakId { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public bool IsActive { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastLogin { get; set; }
    
    public virtual required UserProfile Profile { get; set; }
}