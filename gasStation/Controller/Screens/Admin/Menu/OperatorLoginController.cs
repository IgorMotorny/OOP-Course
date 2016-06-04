using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    class OperatorLoginController : ScreenController {
        private GasStationView _view;
        private GasStationModel _model;
        private FileManager _fileManager = new FileManager();

        private string _name;
        private string _surname;
        private Date _birthday;
        private List<Operator> _operatorsList;
        private Operator _currentOperator;
        public OperatorLoginController(GasStationView view, GasStationModel model) {
            _view = view;
            _model = model;
        }
        public void InitScreen() {
            GetUserInfro();
            GetOperatorsList();
        }

        private void GetUserInfro() {
            _view.print("Name: ");
            _name = Console.ReadLine();

            _view.print("Surname: ");
            _surname = Console.ReadLine();

            try {
                _view.print("Birthday: ");
                _birthday = new Date(Console.ReadLine());
            } catch { }
        }

        private void GetOperatorsList() {
            _currentOperator = null;

            _operatorsList = _fileManager.ReadOpertorsList("Operators.txt");

            FindOperator();

            if (_currentOperator == null) {
                _view.print("Kek. Who are you?!");
                Console.ReadKey();
            }

            _model.Operator = _currentOperator;
        }

        private void FindOperator() {
            foreach (Operator currentOperator in _operatorsList) {
                if ((_name == currentOperator.Name) &&
                    (_surname == currentOperator.Surname) &&
                    (_birthday == currentOperator.Birthday)) {
                    _currentOperator = currentOperator;
                }
            }
        }

    }
}
