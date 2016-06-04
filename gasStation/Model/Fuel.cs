using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

namespace GasStation {
    [Serializable()]
    public class Fuel {
        private Hashtable _fuelList;
        private string _currentFuelName;
        private float _price;
        public string Title {
            get {
                return _currentFuelName;
            }
        }
        public float Price {
            get {
                return _price;
            }
        }
        // List of all available fuels
        public Hashtable FuelList {
            get {
                return _fuelList;
            }
        }
        private FileManager _fileManager;
        public Fuel() {
            _fileManager = new FileManager();
            GetFuelInfo();
        }

        public bool SetCurrentFuel(string fuelName) {
            if (_fuelList == null)
                return false;

            if(_fuelList.ContainsKey(fuelName)) {
                _currentFuelName = fuelName;
                _price = Convert.ToSingle(FuelList[_currentFuelName].ToString());
                return true;
            } else {
                Console.WriteLine("Wrong fuel name");
                return false;
            }
        }
        private void GetFuelInfo() {
            _fuelList = _fileManager.ReadBin<Hashtable>("Fuel.dat");
        }
        private void PrintFuelPrice() {
            foreach (DictionaryEntry item in _fuelList) {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }
        private bool MessageWithAnswer(string message) {
            String answerString;
            bool answer = false;
            Regex yesAnswer = new Regex("^Y|y(e(s|p))?$");

            Console.Write(message + " (y/n)");
            answerString = Console.ReadLine();
            if (yesAnswer.IsMatch(answerString))
                answer = true;

            return answer;
        }
        public void AddFuel(string key, float val) {
            if (_fuelList == null)
                _fuelList = new Hashtable();

            _fuelList[key] = val;
        }
        public void InitFuelPrice() {
            
        }
    }
}
