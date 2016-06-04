using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    class PrintBalnceController : ScreenController {
        private GasStationModel _model;
        private GasStationView _view;
        public PrintBalnceController(GasStationModel model, GasStationView view) {
            _model = model;
            _view = view;
        }
        public void InitScreen() {
            foreach (Sale item in _model.Balance.Operations) 
                _view.print(item.ToString() + "\n");
            Console.Read();
        }
    }
}
