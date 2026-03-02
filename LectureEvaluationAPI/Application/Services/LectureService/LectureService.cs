using LectureEvaluationAPI.Application.Mapper;
using LectureEvaluationAPI.Application.Repositories;
using LectureEvaluationAPI.Application.Services.LectureService.Dto;
using LectureEvaluationAPI.Domain.Entities;
using LectureEvaluationAPI.Infrastructure.Repositories;

namespace LectureEvaluationAPI.Application.Services.LectureService;

public class LectureService : ILectureService
{
    private ILectureRepository _lectureRepository;
    private DtoMapper _mapper;

    public LectureService(ILectureRepository lectureRepository, DtoMapper mapper)
    {
        _lectureRepository = lectureRepository;
        _mapper = mapper;
    }
    
    public async Task<LectureResponse> CreateLectureAsync(CreateLectureRequest request)
    {
        // neue Entität erstellen ( new Lecture() )
        var lecture = new Lecture()
        {
            Title = request.Title,
            ExternalId = request.ExternalId,
            LecturerName = request.LecturerName,
        };
        
        // speichern mit Repository
        var newLecture = await _lectureRepository.AddAsync(lecture);
        
        // neu erstelle Entität in LectureResponse DTO umwandeln und zurück geben
        return _mapper.ToLectureResponse(newLecture);
    }

    public async Task<LectureResponse?> FindByIdAsync(int id)
    {
        var lecture = await _lectureRepository.FindByIdAsync(id);
        
        if (lecture == null)
            return null;
        
        return _mapper.ToLectureResponse(lecture);
    }

    public async Task<LectureResponse?> UpdateAsync(int id, UpdateLectureRequest request)
    {
        var existingLecture = await _lectureRepository.FindByIdAsync(id);
        
        if (existingLecture == null)
            return null;

        existingLecture.Title = request.Title;
        existingLecture.ExternalId = request.ExternalId;
        existingLecture.LecturerName = request.LecturerName;
        
        await _lectureRepository.UpdateAsync(existingLecture);
        
        return _mapper.ToLectureResponse(existingLecture);
    }
}