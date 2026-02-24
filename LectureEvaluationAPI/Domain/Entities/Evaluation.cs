namespace LectureEvaluationAPI.Domain.Entities;

public class Evaluation
{
    public int Id { get; set; }
    
    public string PositiveCritic { get; set; } = string.Empty;
    
    public string ImprovementCritic { get; set; } = string.Empty;

    // Foreign Key linking back to the Lecture
    public Lecture? Lecture { get; set; }
}