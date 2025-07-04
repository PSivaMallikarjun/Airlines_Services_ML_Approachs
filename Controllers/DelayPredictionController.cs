using Airlines_Services_ML_Approachs.Models;
using Airlines_Services_ML_Approachs.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airlines_Services_ML_Approachs.Controllers;

[ApiController]
[Route("api/[controller]")]      // →  api/delayprediction
public class DelayPredictionController : ControllerBase
{
    private readonly DelayPredictionService _service;

    public DelayPredictionController(DelayPredictionService service)
    {
        _service = service;
    }

    // POST api/delayprediction/predict
    [HttpPost("predict")]
    public ActionResult<FlightPrediction> Predict([FromBody] FlightData input)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = _service.Predict(input);
        return Ok(result);
    }
}
