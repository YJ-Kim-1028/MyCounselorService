namespace CounselFlow.Domain.Entities;

public class Customer
{
    public string CustomerId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Grade { get; set; }
    public string? Zip { get; set; }
    public string? Address { get; set; }
    public DateTime CrdDate { get; set; }
    public DateTime UpdDate { get; set; }

    public ICollection<Consult> Consults { get; set; } = new List<Consult>();
}
