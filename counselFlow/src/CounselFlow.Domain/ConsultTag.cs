namespace CounselFlow.Domain.Entities;

public class ConsultTag
{
    public string ConsultId { get; set; } = null!;
    public string TagId { get; set; } = null!;

    public Consult Consult { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}
