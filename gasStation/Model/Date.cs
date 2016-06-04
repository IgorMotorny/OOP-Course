using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    [Serializable()]
    public class Date {
        private int _day;
        private int _month;
        private int _year;
        public int Day {
            set {
                if ((value > 0) && (value <= 31))
                    _day = value;
            }
            get {
                return _day;
            }
        }
        public int Month {
            set {
                if ((value > 0) && (value <= 12))
                    _month = value;
            }
            get {
                return _month;
            }
        }
        public int Year {
            set {
                _year = value;
            }
            get {
                return _year;
            }
        }

        public Date() {
            DateTime currentDate = DateTime.Today;
            Day = currentDate.Day;
            Month = currentDate.Month;
            Year = currentDate.Year;
        }
        public Date(String date) {
            String[] dateArrary;
            dateArrary = date.Split('.');
            Day = int.Parse(dateArrary[0]);
            Month = int.Parse(dateArrary[1]);
            Year = int.Parse(dateArrary[2]);
        }

        public Date(int day, int month, int year) {
            Day = day;
            Month = month;
            Year = year;
        }

        public Date(DateTime date) {
            Day = date.Day;
            Month = date.Month;
            Year = date.Year;
        }

        private String FormatDate(int value, int finalLength) {
            StringBuilder resultString = new StringBuilder(finalLength);
            String valueString = value.ToString();

            for (var i = 0; i < finalLength - valueString.Length; i++) {
                resultString.Append("0");
            }

            resultString.Append(valueString);

            return resultString.ToString();
        }

        public static bool operator >(Date firstDate, Date secondDate) {
            DateTime firstDateLocal = new DateTime(firstDate._year, firstDate._month, firstDate._day);
            DateTime secondDateLocal = new DateTime(secondDate._year, secondDate._month, secondDate._day);
            return (firstDateLocal.CompareTo(secondDateLocal) > 0);
        }

        public static bool operator >=(Date firstDate, Date secondDate) {
            DateTime firstDateLocal = new DateTime(firstDate._year, firstDate._month, firstDate._day);
            DateTime secondDateLocal = new DateTime(secondDate._year, secondDate._month, secondDate._day);
            return (firstDateLocal.CompareTo(secondDateLocal) >= 0);
        }

        public static bool operator <(Date firstDate, Date secondDate) {
            DateTime firstDateLocal = new DateTime(firstDate._year, firstDate._month, firstDate._day);
            DateTime secondDateLocal = new DateTime(secondDate._year, secondDate._month, secondDate._day);
            return (firstDateLocal.CompareTo(secondDateLocal) < 0);
        }

        public static bool operator <=(Date firstDate, Date secondDate) {
            DateTime firstDateLocal = new DateTime(firstDate._year, firstDate._month, firstDate._day);
            DateTime secondDateLocal = new DateTime(secondDate._year, secondDate._month, secondDate._day);
            return (firstDateLocal.CompareTo(secondDateLocal) <= 0);
        }

        public static bool operator ==(Date firstDate, Date secondDate) {
            return ((firstDate._day == secondDate._day) &&
                   (firstDate._month == secondDate._month) &&
                   (firstDate._year == secondDate._year));
        }

        public static bool operator !=(Date firstDate, Date secondDate) {
            return !((firstDate._day == secondDate._day) &&
                   (firstDate._month == secondDate._month) &&
                   (firstDate._year == secondDate._year));
        }

        public override string ToString() {
            StringBuilder resultString = new StringBuilder(2 + 2 + 4 + 2); // dd.mm.yyyy
            resultString.Append(FormatDate(_day, 2));
            resultString.Append(".");
            resultString.Append(FormatDate(_month, 2));
            resultString.Append(".");
            resultString.Append(_year);
            return resultString.ToString();
        }
    }
}
