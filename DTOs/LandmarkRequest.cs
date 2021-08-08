using System.ComponentModel.DataAnnotations;

namespace NVSTravelSolution.DTOs
{
    public class LandmarkDto
    {
        [Required]
        public string LandmarkName { get; set; }        
        public string Address { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string ContactNumber { get; set; }
    }
}
