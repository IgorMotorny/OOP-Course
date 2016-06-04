using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    class AdminMenuController : ScreenController {
        private AdminMenuView _view;
        private ScreenManager _screenManger = new ScreenManager();
        public AdminMenuController() {
            _view = new AdminMenuView();
        }

        public void InitScreen() {
            _view.PrintMenu();
            RoutFromMenu();
        }
        public void RoutFromMenu() {
            string key = Console.ReadLine();
            switch (key) {
                case "1":
                    _screenManger.GoToScreen("Fuel");
                    break;
                case "2":
                    _screenManger.GoToScreen("Operator login");
                    break;
                case "3":
                    _screenManger.GoToScreen("Print balance");
                    break;
            }
        }
    }
}
