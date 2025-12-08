namespace CounselFlow.Domain.Entities;

public class Consult
{
    public string ConsultId { get; set; } = null!;
    public string AgentId { get; set; } = null!;
    public string CustomerId { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string? Channel { get; set; }
    public string Title { get; set; } = null!;
    public string Summary { get; set; } = null!;
    public DateTime StdDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CrdDate { get; set; }
    public DateTime UpdDate { get; set; }

    public Agent Agent { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public ICollection<ConsultTag> ConsultTags { get; set; } = new List<ConsultTag>();
}
