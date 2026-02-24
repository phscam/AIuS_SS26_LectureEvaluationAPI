using LectureEvaluationAPI.Application.Repositories;
using LectureEvaluationAPI.Domain.Entities;

namespace LectureEvaluationAPI.Infrastructure.Repositories;

public class MockLectureRepository : MockRepository<Lecture>, ILectureRepository
{
    
}