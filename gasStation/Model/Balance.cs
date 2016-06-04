using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    [Serializable()]
    public class Balance : Observer {
        private List<Sale> _operations;
        private Date _currentDate;
        private FileManager _fileManager = new FileManager();
        public int Day {
            get {
                return _currentDate.Day;
            }
        }

        public Date Date {
            get {
                return _currentDate;
            }
        }

        public List<Sale> Operations {
            get {
                return _operations;
            }
        }
        public Balance() {
            RestoreBalance();
            _currentDate = new Date();
        }

        private void RestoreBalance() {
            _operations = null;
            try {
                _operations = _fileManager.ReadBin<List<Sale>>("Balance\\Balance(" + new Date().ToString() + ").dat");
            } catch { }
         
            if (_operations == null)
                _operations = new List<Sale>();
        }

        public void AddOperation(Sale sale) {
            _operations.Add(sale);
        }
    }
}
