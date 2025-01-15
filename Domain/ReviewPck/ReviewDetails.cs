namespace CVB.BL.Domain.ReviewPck;

public class ReviewDetails
{
    public Guid Id { get; set; }
    public Guid ReviewId { get; set; }
    public required string Comment { get; set; }
    public double Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int NumberOfLikes { get; set; }
    public int NumberOfDislikes { get; set; }
    
    public virtual required Review Review { get; set; }
}