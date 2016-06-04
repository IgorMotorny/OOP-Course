using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    class GasStationController : Observer {
        private GasStationModel _model;
        private GasStationView _view;
        private FileManager _fileManager = new FileManager();
        public GasStationController(GasStationModel model, GasStationView view) {
            _model = model;
            _view = view;
        }
        public void AddOperation(Sale newSale) {
            Date currentDate = new Date();

            if (newSale.Date.Day != currentDate.Day) 
                _model.Reset();

            _model.AddOpeation(newSale);
            
        }
    }
}
