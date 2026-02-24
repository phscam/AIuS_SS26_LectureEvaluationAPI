using LectureEvaluationAPI.Application.Repositories;
using LectureEvaluationAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LectureEvaluationAPI.Api.Controller;

[ApiController]
[Route("api/evaluations")]
public class EvaluationController : ControllerBase
{
    private readonly IEvaluationRepository _evaluationRepository;

    public EvaluationController(IEvaluationRepository evaluationRepository)
    {
        _evaluationRepository = evaluationRepository;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Evaluation>> GetById(int id)
    {
        var evaluation = await _evaluationRepository.FindByIdAsync(id);
        
        if (evaluation == null)
            return NotFound();
        
        return Ok(evaluation);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Evaluation>> Delete(int id)
    {
        var evaluation = await _evaluationRepository.FindByIdAsync(id);
        
        if (evaluation == null)
            return NotFound();
        
        var deletedEvaluation = await _evaluationRepository.DeleteAsync(evaluation);
        
        return Ok(deletedEvaluation);
    }
}