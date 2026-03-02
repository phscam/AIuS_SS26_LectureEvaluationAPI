namespace LectureEvaluationAPI.Application.Services.LectureService.Dto;

public class LectureResponse
{
    public int Id { get; set; }
    
    public string ExternalId { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string LecturerName { get; set; } = string.Empty;
}