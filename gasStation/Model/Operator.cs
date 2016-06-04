using GasStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {

    [Serializable()]
    public class Operator {
        private string _name;
        private string _surname;
        private Date _birthday;

        public string Name {
            get {
                return _name;
            }
        }
        public string Surname {
            get {
                return _surname;
            }
        }
        public Date Birthday {
            get {
                return _birthday;
            }
        }
        public Operator(string name, string surname, string birthday) {
            _name = name;
            _surname = surname;
            _birthday = new Date(birthday);
        }

        public Operator(string name, string surname, Date birthday) {
            _name = name;
            _surname = surname;
            _birthday = birthday;
        }

        public override string ToString() {
            return _name + " " + _surname + " (" 
                + _birthday.ToString() + ")";
        }
    }
}
