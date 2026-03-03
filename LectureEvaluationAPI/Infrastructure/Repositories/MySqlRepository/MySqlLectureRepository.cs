using LectureEvaluationAPI.Application.Repositories;
using LectureEvaluationAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LectureEvaluationAPI.Infrastructure.Repositories.MySqlRepository;

public class MySqlLectureRepository : ILectureRepository
{
    private readonly MySqlDbContext _context;

    public MySqlLectureRepository(MySqlDbContext context)
    {
        _context = context;
    }

    public async Task<List<Lecture>> FindAllAsync()
    {
        return await _context.Lectures.ToListAsync();
    }

    public async Task<Lecture?> FindByIdAsync(int id)
    {
        return await _context.Lectures.FindAsync(id);
    }

    public async Task<Lecture> AddAsync(Lecture entity)
    {
        _context.Lectures.Add(entity);
        await _context.SaveChangesAsync();
        
        return entity;
    }

    public async Task<Lecture> UpdateAsync(Lecture entity)
    {
        _context.Lectures.Update(entity);
        await _context.SaveChangesAsync();
        
        return entity;
    }

    public async Task<Lecture> DeleteAsync(Lecture entity)
    {
        _context.Lectures.Remove(entity);
        await _context.SaveChangesAsync();
        
        return entity;
    }
}