using LectureEvaluationAPI.Application.Repositories;
using LectureEvaluationAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LectureEvaluationAPI.Api.Controller;

[ApiController]
[Route("api/lectures")]
public class LectureController : ControllerBase
{
    private readonly ILectureRepository _lectureRepository;
    private readonly IEvaluationRepository _evaluationRepository;

    public LectureController(ILectureRepository lectureRepository, IEvaluationRepository evaluationRepository)
    {
        _lectureRepository = lectureRepository;
        _evaluationRepository = evaluationRepository;
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
    public async Task<ActionResult<Lecture>> Create(Lecture lecture)
    {
        var newLecture = await _lectureRepository.AddAsync(lecture);
        
        return CreatedAtAction(nameof(GetById), new { id = newLecture.Id }, newLecture);
    }
    
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Lecture>> Update(int id, Lecture lecture)
    {
        var existingLecture = await _lectureRepository.FindByIdAsync(id);
        
        if (existingLecture == null)
            return NotFound();
        
        var updatedLecture = await _lectureRepository.UpdateAsync(lecture);
        
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