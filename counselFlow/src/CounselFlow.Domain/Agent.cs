namespace CounselFlow.Domain.Entities;

public class Agent
{
    public string AgentId { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Team { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string ActiveYn { get; set; } = null!;   // char(1) 대신 string으로
    public DateTime CrdDate { get; set; }
    public DateTime UpdDate { get; set; }

    public ICollection<Consult> Consults { get; set; } = new List<Consult>(); // Agent → Consult = 1:N 관계
}
