using LectureEvaluationAPI.Application.Repositories;
using LectureEvaluationAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LectureEvaluationAPI.Api.Controller;

[ApiController]
[Route("api/lectures")]
public class LectureController : ControllerBase
{
    private readonly Lecture _lecture = new Lecture()
    {
        Id = 1,
        Title = "Anwendungsintegration und Sicherheit",
        LecturerName = "Valmir & Philipp",
        ExternalId = "FHV AIuS SS 2026"
    };
    
    private readonly ILectureRepository _lectureRepository;

    public LectureController(ILectureRepository lectureRepository)
    {
        _lectureRepository = lectureRepository;
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
    public ActionResult<Lecture> GetById(int id)
    {
        return Ok(_lecture);
    }
    
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Lecture> Create(Lecture lecture)
    {
        var newLecture = _lecture;
        
        return CreatedAtAction(nameof(GetById), new { id = newLecture.Id }, newLecture);
    }
    
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Lecture> Update(int id, Lecture lecture)
    {
        return Ok(_lecture);
    }
    
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Lecture> Delete(int id)
    {
        return Ok(_lecture);
    }
    
    
    [HttpGet("{id}/evaluations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Evaluation> GetEvaluationsByLectureId(int id)
    {
        var evaluations = new List<Evaluation>()
        {
            new Evaluation()
            {
                Id = 1,
                PositiveCritic = "Sehr nice"
            }
        };
        
        return Ok(evaluations);
    }
    
    
    [HttpPost("{id}/evaluations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Evaluation> CreateEvaluationForLectureId(int id, Evaluation evaluation)
    {
        return CreatedAtAction(nameof(EvaluationController.GetById), new { id = evaluation.Id }, evaluation);
    }
}