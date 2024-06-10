using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HolidaySearch.DTO;
using HolidaySearch.Services;
using System.Text.Json;
using Newtonsoft.Json;
namespace HolidaySearch.UnitTest
{
    [TestClass]
    public class SearchTest
    {
        public ISearchService searchService;

        [TestInitialize]
        public void ReadDataFromJsonFiles()
        {
            string flight = File.ReadAllText(@"Data\Flights.json");
            List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(flight);
            string hotel = File.ReadAllText(@"Data\Hotels.json");
            List<Hotel> hotels = JsonConvert.DeserializeObject<List<Hotel>>(hotel);
            searchService = new SearchService(flights, hotels);
        }
        [TestMethod]
        public void ManchesterAirportToMalagaAirport()
        {
            var search = new Search()
            {
                DepartingFrom = "MAN",
                TravellingTo = "AGP",
                Duration = 7,
                DepartureDate = DateTime.Parse("2023/07/01")
            };
            var flight = new Flight()
            {
                Id = 2,
            };
            var hotel = new Hotel()
            {
                Id = 9
            };
            var Result = searchService.Search(search);
            Assert.IsNotNull(Result);
            Assert.AreEqual(hotel.Id, Convert.ToInt64(Result.Hotel.Id));
            Assert.AreEqual(flight.Id, Convert.ToInt64(Result.Flight.Id));
        }
        [TestMethod]
        public void AnyAirportToMallorcaAirport()
        {
            var search = new Search()
            {
                DepartingFrom = "",
                TravellingTo = "PMI",
                Duration = 10,
                DepartureDate = DateTime.Parse("2023/06/15")
            };
            var flight = new Flight()
            {
                Id = 6,
            };
            var hotel = new Hotel()
            {
                Id = 5
            };
            var Result = searchService.Search(search);
            Assert.IsNotNull(Result);
            Assert.AreEqual(hotel.Id, Convert.ToInt64(Result.Hotel.Id));
            Assert.AreEqual(flight.Id, Convert.ToInt64(Result.Flight.Id));
        }

        [TestMethod]
        public void AnyAirportToGranCanariaAirport()
        {
            var search = new Search()
            {
                DepartingFrom = "",
                TravellingTo = "LPA",
                Duration = 14,
                DepartureDate = DateTime.Parse("2022/11/10")
            };
            var flight = new Flight()
            {
                Id = 7,
            };
            var hotel = new Hotel()
            {
                Id = 6
            };
            var Result = searchService.Search(search);
            Assert.IsNotNull(Result);
            Assert.AreEqual(hotel.Id, Convert.ToInt64(Result.Hotel.Id));
            Assert.AreEqual(flight.Id, Convert.ToInt64(Result.Flight.Id));
        }
    }
}
