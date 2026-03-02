using LectureEvaluationAPI.Application.Repositories;
using LectureEvaluationAPI.Application.Services.LectureService;
using LectureEvaluationAPI.Application.Services.LectureService.Dto;
using LectureEvaluationAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LectureEvaluationAPI.Api.Controller;

[ApiController]
[Route("api/lectures")]
public class LectureController : ControllerBase
{
    private readonly ILectureRepository _lectureRepository;
    private readonly IEvaluationRepository _evaluationRepository;

    private readonly ILectureService _lectureService;

    public LectureController(
        ILectureRepository lectureRepository, 
        IEvaluationRepository evaluationRepository,
        ILectureService lectureService
    )
    {
        _lectureRepository = lectureRepository;
        _evaluationRepository = evaluationRepository;
        _lectureService = lectureService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Lecture>>> GetAll()
    {
        var lectures = await _lectureRepository.FindAllAsync();

        return Ok(lectures);
    }

    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Lecture>> GetById(int id)
    {
        var lecture = await _lectureRepository.FindByIdAsync(id);
        
        if (lecture == null)
            return NotFound();
        
        return Ok(lecture);
    }
    
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LectureResponse>> Create(CreateLectureRequest request)
    {
        var newLecture = await _lectureService.CreateLectureAsync(request);
        
        return CreatedAtAction(nameof(GetById), new { id = newLecture.Id }, newLecture);
    }
    
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LectureResponse>> Update(int id, UpdateLectureRequest request)
    {
        var updatedLecture = await _lectureService.UpdateAsync(id, request);
        
        if (updatedLecture == null)
            return NotFound();
        
        return Ok(updatedLecture);
    }
    
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Lecture>> Delete(int id)
    {
        var existingLecture = await _lectureRepository.FindByIdAsync(id);
        
        if (existingLecture == null)
            return NotFound();

        var deletedLecture = await _lectureRepository.DeleteAsync(existingLecture);
        
        return Ok(deletedLecture);
    }
    
    
    [HttpGet("{id}/evaluations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Evaluation>> GetEvaluationsByLectureId(int id)
    {
        var lecture = await _lectureRepository.FindByIdAsync(id);
        
        if (lecture == null)
            return NotFound();
        
        var evaluations = await _evaluationRepository.FindAllByLectureIdAsync(id);
        
        return Ok(evaluations);
    }
    
    
    [HttpPost("{id}/evaluations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Evaluation>> CreateEvaluationForLectureId(int id, Evaluation evaluation)
    {
        var lecture = await _lectureRepository.FindByIdAsync(id);
        
        if (lecture == null)
            return NotFound();
        
        evaluation.LectureId = id;
        
        var newEvaluation = await _evaluationRepository.AddAsync(evaluation);
        
        return CreatedAtAction(nameof(GetById), new { id = newEvaluation.Id }, newEvaluation);
    }
}