using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasStation {
    class Date {
        private byte day;
        private byte month;
        private short year;
        public byte Day {
            set {
                if((value > 0) && (value <= 31)) 
                    day = value;
            }
        }
        public byte Month {
            set {
                if ((value > 0) && (value <= 12)) 
                    month = value;
            }
        }
        public short Year {
            set {
                System.DateTime currentDate = new System.DateTime();
                if (value >= currentDate.Year)
                    year = value;
            }
        }
        
        public Date(String date) {
            String[] dateArrary;
            dateArrary = date.Split(',');
            Day = dateArrary[0].toByte;

        }
        private String FormatDate(byte value, int finalLength) {
            StringBuilder resultString = new StringBuilder(finalLength);
            String valueString = value.ToString();
    
            for(var i = 0; i < finalLength - valueString.Length; i++) {
                resultString.Append("0");
            }

            resultString.Append(valueString);

            return resultString.ToString();
        }
      
        public override string ToString() {
            StringBuilder resultString = new StringBuilder(2+2+4+2); // dd.mm.yyyy
            resultString.Append(FormatDate(day, 2));
            resultString.Append(FormatDate(month, 2));
            resultString.Append(year);
            return resultString.ToString();
        }
    }
}
