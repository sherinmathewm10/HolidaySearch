using HolidaySearch.DTO;

namespace HolidaySearch.Services
{
    public interface ISearchService
    {
       Result Search(Search holidaySearch);
    }
}
