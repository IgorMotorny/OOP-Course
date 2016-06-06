using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {

    class ScreenManager {
        delegate void Rout(string screenName);
        private ScreenController _currentScreen;

        private static GasStationModel _model = new GasStationModel();

        private GasStationView _view;
        private GasStationController _controller;

        public ScreenManager() {
            _view = new GasStationView();
            _controller = new GasStationController(_model, _view);
        }
        public void GoToScreen(string screenName) {
            Console.Clear();
            switch (screenName) {
                case "Main":
                    _currentScreen = new MainScreenController();
                    break;
                case "Operation":
                    _currentScreen = null;
                    OperationController currentScreen = new OperationController(_model, _controller);
                    currentScreen.InitScreen();
                    break;
                case "Authentication":
                    _currentScreen = new AuthenticationScreenController();
                    break;
                case "Admin menu":
                    _currentScreen = new AdminMenuController();
                    break;
                case "Fuel":
                    _currentScreen = new FuelScreenController(_view);
                    break;
                case "Operator login":
                    _currentScreen = new OperatorLoginController(_view, _model);
                    break;
                case "Print balance":
                    _currentScreen = new PrintBalnceController(_model, _view);
                    break;
                default:
                    _currentScreen = new MainScreenController();
                    break;
            }

            if (_currentScreen != null)
                _currentScreen.InitScreen();

            Console.Clear();
        }
        public void CheckAction(string succes, string fail) {
            ConsoleKeyInfo key;

            key = Console.ReadKey();

            switch (key.Key) {
                case ConsoleKey.Enter:
                    GoToScreen(succes);
                    break;
                case ConsoleKey.Escape:
                    GoToScreen(fail);
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        public void CheckExit(string exitTo) {
            ConsoleKeyInfo key;

            key = Console.ReadKey();

            if (key.Key == ConsoleKey.Escape)
                GoToScreen(exitTo);
       
        }
    }
}
