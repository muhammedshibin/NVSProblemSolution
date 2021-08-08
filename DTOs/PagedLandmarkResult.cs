using NVSTravelSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVSTravelSolution.DTOs
{
    public class PagedLandmarkResult
    {
        public int Count { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<Landmark> Data { get; set; } = new List<Landmark>();
    }
}
