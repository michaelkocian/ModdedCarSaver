using System.Collections.Generic;
using System.Windows.Forms;

namespace ModdedCarSaver
{
    public class VehicleList
    {

        public string Warning = "IF you are editing manually be very cautios! You can delete this file and it will be recreated on next save.";

        public string KeyCodeInfo = "Valid keys can be found at https://github.com/microsoft/CodeContracts/blob/master/Microsoft.Research/Contracts/System.Windows.Forms/System.Windows.Forms.Keys.cs";

        public Keys OpenMenuKeyCode = Keys.F6;

        public Keys DeleteCarKeyCode = Keys.Delete;

        public List<VehicleModel> Vehicles = new List<VehicleModel>();

    }
}
