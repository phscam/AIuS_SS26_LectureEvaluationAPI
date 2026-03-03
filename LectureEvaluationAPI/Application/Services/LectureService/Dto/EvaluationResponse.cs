namespace LectureEvaluationAPI.Application.Services.LectureService.Dto;

public class EvaluationResponse
{
    public int Id { get; set; }
    
    public string PositiveCritic { get; set; } = string.Empty;
    
    public string ImprovementCritic { get; set; } = string.Empty;
}