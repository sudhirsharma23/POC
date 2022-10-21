using System;

namespace CP.DTO.Ach
{
    public class DateRangeDto
    {
        public DateTime Submitted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FormattedDateRange { get; set; }
    }
}