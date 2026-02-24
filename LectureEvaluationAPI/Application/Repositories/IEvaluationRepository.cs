using LectureEvaluationAPI.Domain.Entities;

namespace LectureEvaluationAPI.Application.Repositories;

public interface IEvaluationRepository : IRepository<Evaluation>
{
    public Task<List<Evaluation>> FindAllByLectureIdAsync(int lectureId);
}