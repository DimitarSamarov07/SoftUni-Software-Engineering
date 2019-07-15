using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Date_Modifier
{
    class DateModifier
    {
        private string startDate;

        public string startDatePublic
        {
            get { return startDate; }

            set { startDate = value; }
        }
        private string endDate;

        public string endDatePublic
        {
            get { return endDate; }

            set { endDate = value; }
        }

        public DateModifier(string startDate, string endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public double GetDifference()
        {
            string[] startDateArr = startDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] endDateArr = endDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int startYear = int.Parse(startDateArr[0]);
            int startMonth = int.Parse(startDateArr[1]);
            int startDay = int.Parse(startDateArr[2]);
            int endYear = int.Parse(endDateArr[0]);
            int endMonth = int.Parse(endDateArr[1]);
            int endDay = int.Parse(endDateArr[2]);

            DateTime startTime = new DateTime(startYear, startMonth, startDay);
            DateTime endTime = new DateTime(endYear, endMonth, endDay);
            return (startTime - endTime).TotalDays;
        }
    }
}
