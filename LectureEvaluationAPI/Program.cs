using LectureEvaluationAPI.Application.Mapper;
using LectureEvaluationAPI.Application.Repositories;
using LectureEvaluationAPI.Application.Services.LectureService;
using LectureEvaluationAPI.Infrastructure.Repositories;
using LectureEvaluationAPI.Infrastructure.Repositories.MySqlRepository;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddScoped<ILectureRepository, MySqlLectureRepository>();
builder.Services.AddScoped<IEvaluationRepository, MySqlEvaluationRepository>();

builder.Services.AddScoped<ILectureService, LectureService>();
builder.Services.AddTransient<DtoMapper>();

var connectionString = builder.Configuration.GetConnectionString("mySqlDb");

if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Database connection string is missing");

builder.Services.AddDbContext<MySqlDbContext>(options =>
    options.UseMySQL(connectionString)
);

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.Run();