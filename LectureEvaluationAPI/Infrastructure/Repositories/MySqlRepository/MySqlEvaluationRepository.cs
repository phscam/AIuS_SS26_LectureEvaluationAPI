using LectureEvaluationAPI.Application.Repositories;
using LectureEvaluationAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LectureEvaluationAPI.Infrastructure.Repositories.MySqlRepository;

public class MySqlEvaluationRepository : IEvaluationRepository
{
    private readonly MySqlDbContext _context;

    public MySqlEvaluationRepository(MySqlDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Evaluation>> FindAllAsync()
    {
        return await _context.Evaluations.ToListAsync();
    }

    public async Task<Evaluation?> FindByIdAsync(int id)
    {
        return await _context.Evaluations.FindAsync(id);
    }

    public async Task<Evaluation> AddAsync(Evaluation entity)
    {
        _context.Evaluations.Add(entity);
        await _context.SaveChangesAsync();
        
        return entity;
    }

    public async Task<Evaluation> UpdateAsync(Evaluation entity)
    {
        _context.Evaluations.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Evaluation> DeleteAsync(Evaluation entity)
    {
        _context.Evaluations.Remove(entity);
        await _context.SaveChangesAsync();
        
        return entity;
    }

    public async Task<List<Evaluation>> FindAllByLectureIdAsync(int lectureId)
    {
        return await _context.Evaluations
            .Where(e => e.LectureId == lectureId).ToListAsync();
    }
}