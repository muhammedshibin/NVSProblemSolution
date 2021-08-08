using Microsoft.EntityFrameworkCore;
using NVSTravelSolution.Data.Entities;
using NVSTravelSolution.Data.Filters;
using NVSTravelSolution.DTOs;
using NVSTravelSolution.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVSTravelSolution.Data.Repositories
{

    public class LandmarkRepository : ILandmarkRepository
    {
        private readonly DataContext _context;

        public LandmarkRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Landmark landmark)
        {
            _context.Landmarks.Add(landmark);
            _context.Entry(landmark).State = EntityState.Added;
        }

        public void UpdateMany(IList<Landmark> landmarks)
        {
            _context.Landmarks.AttachRange(landmarks);
            foreach (var landmark in landmarks)
            {
                _context.Entry(landmark).State = EntityState.Modified;
            }
        }

        public async Task<PagedLandmarkResult> GetLandmarksByFilterAsync(LandmarkFilter filter)
        {
            var result = new PagedLandmarkResult();
            result.PageNumber = filter.PageNumber;
            result.PageSize = filter.PageSize;

            var query = _context.Landmarks.AsNoTracking()
                .Where(x => string.IsNullOrEmpty(filter.Search) || x.LandmarkName.ToLower().Contains(filter.Search)).AsQueryable();

            result.Count = await  query.CountAsync();

            if (filter.PageNumber == 0 && filter.PageSize == 0)
                result.Data =  await query.ToListAsync();           

            result.Data =  await query
                .OrderBy(l => l.Distance)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return result;
        }

        public async Task<List<Landmark>> GetLandmarksAsync()
        {
            return await _context.Landmarks.OrderBy(d => d.Distance).ThenBy(l => l.LandmarkName).ToListAsync();
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
