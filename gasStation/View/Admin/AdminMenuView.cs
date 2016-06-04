using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    class AdminMenuView : GasStationView {
        public void PrintMenu() {
            Console.WriteLine("1. Set fuel price");
            Console.WriteLine("2. Login as operator");
            Console.WriteLine("3. Print current balance");
        }
    }
}
