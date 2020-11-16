using GTA;
using NativeUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModdedCarSaver
{
    public class Saver : Script
    {
        private int highlighted = 0;
        private readonly VehicleList VehicleList;


        private readonly MenuPool myMenuPool = new MenuPool();
        private readonly UIMenu myMenu = new UIMenu("Modded Car Saver", "Select Your Car")
        {
            ResetCursorOnOpen = true,
        };

        public Saver()
        {
            Console.WriteLine(nameof(ModdedCarSaver) + " booting up");

            Tick += OnTick;
            KeyUp += OnKeyUp;
            KeyDown += OnKeyDown;


            VehicleList = IniHelper.LoadIni() ?? new VehicleList()
            {
                Vehicles = new System.Collections.Generic.List<VehicleModel>()
                {
                    new VehicleModel()
                    {
                        VehicleHash = VehicleHash.Zentorno,
                    }
                }
            };

            myMenu.OnItemSelect += Menu_OnItemSelect;
            myMenu.OnIndexChange += (sender, newIndex) => highlighted = newIndex;
            //StyleMenu();
            RefreshMenu();
            myMenuPool.Add(myMenu);
        }


        private void StyleMenu()
        {
            //this is only temporary because the native ui lib is bugged and shows only white.
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
            myMenuPool.ProcessMenus();
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
                {
                    if (highlighted == 0)
                        Game.Player.LastVehicle.Repair();
                    else if (highlighted >= 1)
                    {
                        string carName = VehicleList.Vehicles[highlighted - 1].VehicleHash.ToString();
                        VehicleList.Vehicles.RemoveAt(highlighted - 1);
                        IniHelper.SaveIni(VehicleList);
                        RefreshMenu();
                        BigMessageThread.MessageInstance.ShowMissionPassedMessage($"Deleted {carName}", 3000);
                    }
                }
            }
        }


        private void OnKeyUp(object sender, KeyEventArgs e)
        {

        }


        private void RefreshMenu()
        {
            myMenu.Clear();
            UIMenuColoredItem item = new UIMenuColoredItem("Save Current Vehicle", Color.FromArgb(80, 80, 50, 80), Color.FromArgb(180, 205, 41, 255));
            item.Description = $"Press Enter to save, {VehicleList.DeleteCarKeyCode} to repair.";
            item.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            myMenu.AddItem(item);
            foreach (var i in VehicleList.Vehicles)
            {
                item = new UIMenuColoredItem(i.VehicleHash.ToString() + " (" + i.PrimaryColor.ToString()+ ")", Color.FromArgb(30, 50, 50, 50), Color.FromArgb(180, 234, 237, 64));
                item.Description = $"Press Enter to spawn, {VehicleList.DeleteCarKeyCode} to delete.";
                item.SetLeftBadge(UIMenuItem.BadgeStyle.Car);
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


        private void LoadVehicle(VehicleModel m)
        {
            myMenu.Visible = false;

            GTA.Vehicle vehicle = GTA.World.CreateVehicle(
                new GTA.Model(m.VehicleHash), // or straight m.VehicleHash,
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
                IniHelper.SaveIni(VehicleList);
                myMenu.Visible = false;
                RefreshMenu();
                GTA.UI.Notification.Show($"Saved vehicle: { v.DisplayName}.", true);
            }

        }
    }
}