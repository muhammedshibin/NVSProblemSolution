using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NVSTravelSolution.Data.Entities;
using NVSTravelSolution.Data.Filters;
using NVSTravelSolution.DTOs;
using NVSTravelSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVSTravelSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandmarksController : ControllerBase
    {
        private readonly ILandmarkService _landmarkService;

        public LandmarksController(ILandmarkService landmarkService)
        {
            _landmarkService = landmarkService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLandmark(LandmarkDto landmarkDto)
        {
            var result = await _landmarkService.CreateLandmark(landmarkDto);

            if (!result) return BadRequest("Distance should be more than 1000 Metres");

            return Ok(true);
        }

        [HttpGet]
        public async Task<ActionResult<PagedLandmarkResult>> GetLandmarks([FromQuery]LandmarkFilter landmarkFilter)
        {
            return Ok(await _landmarkService.GetLandmarks(landmarkFilter));
        }
    }
}
