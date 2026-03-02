using LectureEvaluationAPI.Application.Services.LectureService.Dto;
using LectureEvaluationAPI.Domain.Entities;

namespace LectureEvaluationAPI.Application.Mapper;

public class DtoMapper
{
    public LectureResponse ToLectureResponse(Lecture lecture)
    {
        return new LectureResponse()
        {
            Id = lecture.Id,
            Title = lecture.Title,
            ExternalId = lecture.ExternalId,
            LecturerName = lecture.LecturerName
        };
    }
}