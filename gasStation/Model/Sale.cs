using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    [Serializable()]
    public class Sale {
        private Operator _opearator;
        private Fuel _fuel;
        private float _fueltAmount;
        private float _totalPrice;
        private Date _currentDate; 

        public Date Date {
            get {
                return _currentDate;
            }
        }

        public Sale(Operator gasStationOperator, Fuel fuel, float fuelAmount) {
            _opearator = gasStationOperator;
            _fuel = fuel;
            _fueltAmount = fuelAmount;
            _totalPrice = fuelAmount * fuel.Price;
           _currentDate = new Date();
        }

        public string StringConverter(string str, int length) {
            StringBuilder resultString = new StringBuilder();
            resultString.Append(str);
            for (int i = 0; i < length - str.Length; i++)
                resultString.Append(" ");
            return resultString.ToString();
        }

        public override string ToString() {
            return StringConverter(_opearator.ToString(), 30) +
                StringConverter(_fuel.Title, 10) +
                StringConverter(_fueltAmount.ToString(), 5) +
                StringConverter(_totalPrice.ToString(), 5);

        }

    }
}
