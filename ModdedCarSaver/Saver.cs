using GTA;
using NativeUI;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ModdedCarSaver
{
    public class Saver : Script
    {
        int highlighted = 0;

        string configName = ".\\scripts\\ModdedCarSaver.ini";

        private MenuPool _myMenuPool = new MenuPool();
        private UIMenu myMenu = new UIMenu("Modded Car Saver", "Select Your Car")
        {
            ResetCursorOnOpen = true,
        };
        private VehicleList VehicleList = new VehicleList();

        public Saver()
        {
            Tick += OnTick;
            KeyUp += OnKeyUp;
            KeyDown += OnKeyDown;


            LoadIni();
            myMenu.OnItemSelect += Menu_OnItemSelect;
            myMenu.OnIndexChange += (sender, newIndex) => highlighted = newIndex;
            StyleMenu();
            RefreshMenu();
            _myMenuPool.Add(myMenu);

        }


        private void StyleMenu()
        {
            var background = new Sprite("commonmenu", "bgd_gradient", new Point(100, 20), new Size(200, 500))
            {
                Color = Color.Blue,
                Heading = 0,
                Visible = true,
            };
            myMenu.SetBannerType(background);
        }

        private void OnTick(object sender, EventArgs e)
        {
            _myMenuPool.ProcessMenus();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            //myMenu.ProcessKey(e.KeyCode); // We are using controls instead of keys, so we comment it out.
            if (e.KeyCode == VehicleList.OpenMenuKeyCode) // Our menu on/off switch
            {
                myMenu.Visible = !myMenu.Visible;
            }


            if (e.KeyCode == VehicleList.DeleteCarKeyCode) // Our menu on/off switch
            {
                if (myMenu.Visible)
                    if (highlighted >= 1)
                    {
                        string carName = VehicleList.Vehicles[highlighted - 1].VehicleHash.ToString();
                        VehicleList.Vehicles.RemoveAt(highlighted - 1);
                        SaveIni();
                        RefreshMenu();
                        BigMessageThread.MessageInstance.ShowMissionPassedMessage($"Deleted {carName}", 3000);
                    }
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0)
                LoadVehicleOrig();
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


        private void RefreshMenu()
        {
            myMenu.Clear();
            UIMenuColoredItem item = new UIMenuColoredItem("Save Current Vehicle", Color.Gray, Color.Yellow);
            //item.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            myMenu.AddItem(item);
            foreach (var i in VehicleList.Vehicles)
            {
                item = new UIMenuColoredItem(i.VehicleHash.ToString(), Color.Gray, Color.White);
                item.Description = "Press Enter to spawn, Del to delete.";
                myMenu.AddItem(item);
            }
            myMenu.RefreshIndex();

        }

        private void Menu_OnItemSelect(NativeUI.UIMenu sender, NativeUI.UIMenuItem selectedItem, int index)
        {
            if (index == 0)
                SaveVehicle();
            else
                LoadVehicle(VehicleList.Vehicles[index - 1]);
        }

        private void LoadIni()
        {
            try
            {
                string vehiclejson = File.ReadAllText(configName);
                VehicleList = JsonConvert.DeserializeObject<VehicleList>(vehiclejson);
            }
            catch (FileNotFoundException) { }
        }

        private void SaveIni()
        {
            var vehiclejson = JsonConvert.SerializeObject(VehicleList, Formatting.Indented);
            File.WriteAllText(configName, vehiclejson);
        }

        private void LoadVehicle(VehicleModel m)
        {
            GTA.Vehicle vehicle = GTA.World.CreateVehicle(
                m.VehicleHash,
                Game.Player.Character.Position + Game.Player.Character.ForwardVector * 4.0f,
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
                VehicleList.Vehicles.Insert(0, vehicleModel);
                SaveIni();
                myMenu.Visible = false;
                RefreshMenu();
                BigMessageThread.MessageInstance.ShowSimpleShard($"Saved {v.DisplayName}", "sub");
            }

        }
    }
}