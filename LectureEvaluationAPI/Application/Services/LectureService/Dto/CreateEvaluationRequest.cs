namespace LectureEvaluationAPI.Application.Services.LectureService.Dto;

public class CreateEvaluationRequest
{
    public string PositiveCritic { get; set; } = string.Empty;
    
    public string ImprovementCritic { get; set; } = string.Empty;
}