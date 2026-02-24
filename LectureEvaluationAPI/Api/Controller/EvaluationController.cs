using LectureEvaluationAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LectureEvaluationAPI.Api.Controller;

[ApiController]
[Route("api/evaluations")]
public class EvaluationController : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Evaluation> GetById(int id)
    {
        return Ok(new Evaluation()
        {
            Id = id,
            PositiveCritic = "Sehr nice"
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Evaluation> DeleteById(int id)
    {
        return Ok(new Evaluation()
        {
            Id = id,
            PositiveCritic = "Sehr nice"
        });
    }
}