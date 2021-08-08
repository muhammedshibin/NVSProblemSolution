using NVSTravelSolution.Data.Entities;
using NVSTravelSolution.Data.Filters;
using NVSTravelSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVSTravelSolution.Interfaces
{
    public interface ILandmarkService
    {
        Task<bool> CreateLandmark(LandmarkDto request);
        Task<PagedLandmarkResult> GetLandmarks(LandmarkFilter landmarkFilter);
    }
}
