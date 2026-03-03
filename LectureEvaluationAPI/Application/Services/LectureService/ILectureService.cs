using LectureEvaluationAPI.Application.Services.LectureService.Dto;

namespace LectureEvaluationAPI.Application.Services.LectureService;

public interface ILectureService
{
    Task<LectureResponse> CreateLectureAsync(CreateLectureRequest request);

    Task<LectureResponse?> FindByIdAsync(int id);

    Task<LectureResponse?> UpdateAsync(int id, UpdateLectureRequest request);

    Task<EvaluationResponse?> CreateEvaluationForLectureId(int id, CreateEvaluationRequest request);
}