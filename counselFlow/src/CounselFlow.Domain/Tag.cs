namespace CounselFlow.Domain.Entities;

public class Tag
{
    public string TagId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public DateTime CrdDate { get; set; }

    public ICollection<ConsultTag> ConsultTags { get; set; } = new List<ConsultTag>();
}
