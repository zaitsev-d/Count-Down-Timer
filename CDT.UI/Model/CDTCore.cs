using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDT.UI.Model
{
    public class CDTCore
    {
        public int Days { get; set; } = default;
        public int Hours { get; set; } = default;
        public int Minutes { get; set; } = default;
        public int Seconds { get; set; } = default;

        private DateTime currentDate;
        private DateTime nextYear;

        public void CounterBuilder(DateTime holiday_Date)
        {
            currentDate = DateTime.Now;
            nextYear = holiday_Date.AddYears(currentDate.Year - holiday_Date.Year);

            if (nextYear < currentDate)
            {
                if (!DateTime.IsLeapYear(nextYear.Year + 1))
                    nextYear = nextYear.AddYears(1);
                else
                    nextYear = new DateTime(nextYear.Year + 1, holiday_Date.Month, holiday_Date.Day);
            }

            Days = (nextYear - currentDate).Days;
            Hours = (nextYear - currentDate).Hours;
            Minutes = (nextYear - currentDate).Minutes;
            Seconds = (nextYear - currentDate).Seconds;
        }
    }
}
