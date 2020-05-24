using GTA;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ModdedCarSaver
{
    public class Saver : Script
    {


        string configName = ".\\scripts\\ModdedCarSaver.ini";

        public Saver()
        {
            Tick += OnTick;
            KeyUp += OnKeyUp;
            KeyDown += OnKeyDown;
        }

        private void OnTick(object sender, EventArgs e)
        {
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0)
                SaveVehicle();

            if (e.KeyCode == Keys.NumPad1)
            {
                SaveVehicle();
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                LoadVehicle();
            }
        }

        private void LoadVehicleOrig()
        {
            GTA.Vehicle vehicle = GTA.World.CreateVehicle(GTA.VehicleHash.Zentorno, Game.Player.Character.Position + Game.Player.Character.ForwardVector * 3.0f, Game.Player.Character.Heading + 90);
            vehicle.CanTiresBurst = false;
            vehicle.Mods.CustomPrimaryColor = Color.FromArgb(38, 38, 38);
            vehicle.Mods.CustomSecondaryColor = Color.DarkOrange;
            vehicle.PlaceOnGround();
            vehicle.Mods.LicensePlate = "SHVDN";
        }

        private void LoadVehicle()
        {
            string vehiclejson = File.ReadAllText(configName);
            VehicleModel m = JsonConvert.DeserializeObject<VehicleModel>(vehiclejson);
            GTA.Vehicle vehicle = GTA.World.CreateVehicle(
                (GTA.VehicleHash)m.VehicleHash,
                Game.Player.Character.Position + Game.Player.Character.ForwardVector * 3.0f,
                Game.Player.Character.Heading + 90
                );

            m.ApplyToVehicle(vehicle);

            vehicle.PlaceOnGround();
        }

        private void SaveVehicle()
        {
            var v = Game.Player.LastVehicle;
            if (v != null)
            {
                VehicleModel vehicleModel = VehicleModel.FromVehicle(v);
                var vehiclejson = JsonConvert.SerializeObject(vehicleModel);
                File.WriteAllText(configName, vehiclejson);
            }

        }
    }
}