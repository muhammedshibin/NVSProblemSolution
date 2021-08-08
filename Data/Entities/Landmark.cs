using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVSTravelSolution.Data.Entities
{
    public class Landmark
    {
        public int LandmarkId { get; set; }
        public string LandmarkName { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ContactNumber { get; set; }
        public int PointOrder { get; set; }
        public decimal Distance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
