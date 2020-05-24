using Newtonsoft.Json;
using System.IO;

namespace ModdedCarSaver
{
    public class IniHelper
    {

        static string configName = ".\\scripts\\ModdedCarSaver.ini";

        public static VehicleList LoadIni()
        {
            try
            {
                string vehiclejson = File.ReadAllText(configName);
                return JsonConvert.DeserializeObject<VehicleList>(vehiclejson);
            }
            catch (FileNotFoundException) { return null; }
        }

        public static void SaveIni(VehicleList vehicleList)
        {
            var vehiclejson = JsonConvert.SerializeObject(vehicleList, Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter());
            File.WriteAllText(configName, vehiclejson);
        }

    }
}
