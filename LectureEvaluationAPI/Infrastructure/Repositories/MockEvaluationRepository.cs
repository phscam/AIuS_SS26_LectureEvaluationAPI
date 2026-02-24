using LectureEvaluationAPI.Application.Repositories;
using LectureEvaluationAPI.Domain.Entities;

namespace LectureEvaluationAPI.Infrastructure.Repositories;

public class MockEvaluationRepository : MockRepository<Evaluation>, IEvaluationRepository
{
    public Task<List<Evaluation>> FindAllByLectureIdAsync(int lectureId)
    {
        return Task.FromResult(Store.Values.Where(e => e.LectureId == lectureId).ToList());
    }
}