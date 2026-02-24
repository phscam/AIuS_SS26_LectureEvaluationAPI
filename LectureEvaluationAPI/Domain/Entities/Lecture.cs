namespace LectureEvaluationAPI.Domain.Entities;

public class Lecture
{
    // Primary Key (Internal ID)
    public int Id { get; set; }

    // External ID (e.g., "CS101" or a GUID from a different system)
    public string ExternalId { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string LecturerName { get; set; } = string.Empty;

    // Navigation property for the 1 : Many relationship
    // A Lecture can have many Evaluations
    public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
}