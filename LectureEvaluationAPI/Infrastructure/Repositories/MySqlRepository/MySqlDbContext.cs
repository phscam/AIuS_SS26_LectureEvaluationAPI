using LectureEvaluationAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LectureEvaluationAPI.Infrastructure.Repositories.MySqlRepository;

public class MySqlDbContext : DbContext
{
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Evaluation> Evaluations { get; set; }

    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }
}