namespace HolidaySearch.DTO
{
    public class Result
    {
        public Hotel Hotel { get; set; }
        public Flight Flight { get; set; }
        public Result(Hotel hotel, Flight flight) { 
            Hotel = hotel;
            Flight = flight;
        }

    }
}
