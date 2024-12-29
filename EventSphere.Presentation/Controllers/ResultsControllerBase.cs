using EventSphere.Core.Enums;
using EventSphere.Core.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace EventSphere.Presentation.Controllers;

[ApiController]
public class ResultsControllerBase : ControllerBase
{
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        if (result.IsFailure)
        {
            return result.Error?.ErrorType switch
            {
                ErrorType.InternalServerError => StatusCode(StatusCodes.Status500InternalServerError, result.Error),
                ErrorType.NotFound => NotFound(result.Error),
                ErrorType.Unauthorized => Unauthorized(result.Error),
                _ => StatusCode(StatusCodes.Status500InternalServerError, result.Error)
            };
        }

        return Ok(result.Value);
    }
}
