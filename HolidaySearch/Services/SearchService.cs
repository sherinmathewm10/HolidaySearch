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
            var results = new List<Result>();
           
            var matchedhotel = Hotels.Where(h => h.ArrivalDate == holidaySearch.DepartureDate 
                                                 && h.NoOfNights==holidaySearch.Duration).ToList() ;
            var matchedFlight =Flights.Where(f=> f.DepartureDate == holidaySearch.DepartureDate 
                                                 && holidaySearch.DepartingFrom == f.From || holidaySearch.DepartingFrom == "" 
                                                 && holidaySearch.TravellingTo == f.To).ToList() ;
            foreach(var flight in matchedhotel)
            {
                foreach(var hotel in matchedFlight)
                {
                    results.Add(new Result(flight,hotel));
                }
            }
           return results.OrderBy(r => r.TotalPrice = r.TotalPrice + r.Flight.Price + (r.Hotel.PricePerNight * r.Hotel.NoOfNights)).ToList().First();
        }

    }
}
