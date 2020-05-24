using System.Collections.Generic;
using System.Windows.Forms;

namespace ModdedCarSaver
{
    public class VehicleList
    {

        public string Warning = "IF you are editing manually be very cautios!";

        public Keys OpenMenuKeyCode = Keys.F6;

        public Keys DeleteCarKeyCode = Keys.Delete;

        public List<VehicleModel> Vehicles = new List<VehicleModel>();

    }
}
