using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    class GasStationModel {
        public Operator Operator { get; set; }
        private Balance _currentBalance;
        private FileManager _fileManager = new FileManager();
        private const string BALANCE_LIST_FILE_NAME = "BalanceList.dat";

        public Balance Balance {
            get {
                return _currentBalance;
            }
        }
        public GasStationModel() {
            _currentBalance = new Balance();
        }

        public void Reset() {
            Date currentDate = new Date();
            _fileManager.WriteBin(_currentBalance.Operations, "Balance\\Balance(" + currentDate + ").dat");
            _fileManager.WriteText<Sale>("Balance\\Balance(" + currentDate + ").txt", _currentBalance.Operations);
            _currentBalance = new Balance();
        }

        public void AddOpeation(Sale newSale) {
            _currentBalance.AddOperation(newSale);
        }
    }
}
