using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    class MainScreenController : ScreenController {
        private ScreenManager _screenManager = new ScreenManager();

        private MainScreenView _view;

        public MainScreenController() {
            _view = new MainScreenView();
        }

        public void InitScreen() {
            do {
                _view.PrintMenu();
                _screenManager.CheckAction("Operation", "Authentication");
            } while (true);
        }
    }
}
