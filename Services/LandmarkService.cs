using NVSTravelSolution.Constants;
using NVSTravelSolution.Data.Entities;
using NVSTravelSolution.Data.Filters;
using NVSTravelSolution.DTOs;
using NVSTravelSolution.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NVSTravelSolution.Services
{
    public class LandmarkService : ILandmarkService
    {
        private readonly ILandmarkRepository _landmarkRepository;

        public LandmarkService(ILandmarkRepository landmarkRepository)
        {
            _landmarkRepository = landmarkRepository;
        }

        public async Task<bool> CreateLandmark(LandmarkDto request)
        {

            var distanceFromHeadQuarters = GetDistanceFromHeadQuarters(request.Latitude, request.Longitude);

            if (distanceFromHeadQuarters < 1000)
            {
                return false;
            }

            var landmark = new Landmark
            {
                LandmarkName = request.LandmarkName,
                Address = request.Address,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Distance = (decimal)distanceFromHeadQuarters,
                CreatedDate = DateTime.Now,
                ContactNumber = request.ContactNumber
            };

            var existingLandmarks = await _landmarkRepository.GetLandmarksAsync();

            if (!existingLandmarks.Any())
            {
                landmark.PointOrder = 1;
                _landmarkRepository.Create(landmark);
            }
            else
            {
                existingLandmarks.Add(landmark);
                var ordered = existingLandmarks.OrderBy(d => d.Distance).ToList();

                int index = 1;

                foreach (var loc in ordered)
                {
                    loc.PointOrder = index;
                    index++;
                }

                ordered.Remove(landmark);

                _landmarkRepository.Create(landmark);
                _landmarkRepository.UpdateMany(ordered);
            }

            return await _landmarkRepository.Commit();

        }

        public async Task<PagedLandmarkResult> GetLandmarks(LandmarkFilter landmarkFilter)
        {
            return await _landmarkRepository.GetLandmarksByFilterAsync(landmarkFilter);
        }

        private static double GetDistanceFromHeadQuarters(double destLatitude, double destLongitude)
        {
            var location = new Location(AppConstants.HEADQUARTERS_LATITUDE, AppConstants.HEADQUARTERS_LONGITUDE);

            return location.CalculateDistance(destLatitude, destLongitude, DistanceUnits.Kilometers) * 1000;
        }


    }
}
