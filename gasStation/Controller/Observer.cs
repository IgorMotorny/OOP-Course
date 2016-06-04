using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    interface Observer {
        void AddOperation(Sale newSale);
    }
}
