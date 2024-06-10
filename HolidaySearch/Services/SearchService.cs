using HolidaySearch.DTO;

namespace HolidaySearch.Services
{
    public class SearchService : ISearchService
    {
        public readonly List<Flight> Flights;
        public readonly List<Hotel> Hotels;

        public SearchService(List<Flight> flights, List<Hotel> hotels)
        {
            this.Flights = flights;
            this.Hotels = hotels;
        }
        public Result Search(Search holidaySearch)
        {
            var matchedhotel = Hotels.Where(h => h.LocalAirports.Contains(holidaySearch.TravellingTo);
            var matchedFlight =Flights.Where(f=> f.)
            return Result;
        }
    }
}
