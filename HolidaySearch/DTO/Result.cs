using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
