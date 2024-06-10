using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HolidaySearch.DTO;
using HolidaySearch.Services;
namespace HolidaySearch.UnitTest
{
    [TestClass]
    public class SearchTest
    {
        public readonly ISearchService searchService;
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
            Assert.AreEqual(flight.Id,hotel.Id);
        }
    }
}
