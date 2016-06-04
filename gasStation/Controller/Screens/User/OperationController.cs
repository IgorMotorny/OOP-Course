using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    class OperationController : Observer, ScreenController {
        private GasStationModel _model;
        private GasStationView _view;
        private Fuel _fuel;
        private Sale _operation;

        private GasStationController _mainController;
        
        public OperationController(GasStationModel model, GasStationController mainController) {
            _view = new GasStationView();
            _fuel = new Fuel();
            _model = model;
            _mainController = mainController;
        }

        public void InitScreen() {
            if (_fuel.FuelList == null) 
                return;

            if (_model.Operator == null) {
                _view.print("Operator is undefined!");
                Console.Read();
                return;
            }

            CreateOperation();
            AddOperation(_operation);  
        }

        public void CreateOperation() {
            bool isOk;
            float fuelAmount = 0;
            do {
                _view.print("Fuel: ");
                isOk = _fuel.SetCurrentFuel(Console.ReadLine());
            } while (!isOk);

            do {
                _view.print("Count: ");
                try {
                    fuelAmount = Single.Parse(Console.ReadLine());
                    isOk = true;
                } catch {
                    isOk = false;
                }
            } while (!isOk);
            _operation = new Sale(_model.Operator, _fuel, fuelAmount);
        }
        public void AddOperation(Sale newSale) {
            _mainController.AddOperation(newSale);
            _view.print("Operation finished succesfull");
            Console.Read();
        }
    }
}
