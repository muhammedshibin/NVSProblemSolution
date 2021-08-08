using NVSTravelSolution.Data.Entities;
using NVSTravelSolution.Data.Filters;
using NVSTravelSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVSTravelSolution.Interfaces
{
    public interface ILandmarkRepository
    {
        void Create(Landmark landmark);
        Task<List<Landmark>> GetLandmarksAsync();
        Task<PagedLandmarkResult> GetLandmarksByFilterAsync(LandmarkFilter filter);
        void UpdateMany(IList<Landmark> landmarks);
        Task<bool> Commit();
    }
}
