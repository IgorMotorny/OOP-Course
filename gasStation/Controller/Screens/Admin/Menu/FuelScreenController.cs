using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    class FuelScreenController : ScreenController {
        GasStationView _view;
        Fuel _model;
        FileManager _fileManager = new FileManager(); 
        public FuelScreenController(GasStationView view) : this(view, new Fuel()) { }
        public FuelScreenController(GasStationView view, Fuel model) {
            _view = view;
            _model = model;
        }

        public void InitScreen() {
            string key;
            float val;
            do {
                Console.Write("Fuel name: ");
                key = Console.ReadLine();

                Console.Write(key + " price: ");
                try {
                    val = Convert.ToSingle(Console.ReadLine());
                } catch {
                    Console.WriteLine("Can't parse data");
                    continue;
                }

                _model.AddFuel(key, val);

            } while (CheckExit());

            _fileManager.WriteBin(_model.FuelList, "Fuel.dat");
        }

        private bool CheckExit() {
            Console.Write("Exit?");
            ConsoleKeyInfo key;

            key = Console.ReadKey();

            Console.Clear();
            return (key.Key == ConsoleKey.Escape);
        }
    }
}
