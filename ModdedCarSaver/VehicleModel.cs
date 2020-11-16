using GTA;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ModdedCarSaver
{
    public class VehicleModel
    {

        public VehicleHash VehicleHash { get; set; }
        public VehicleColor PrimaryColor { get; set; } = VehicleColor.Orange;
        public VehicleColor SecondaryColor { get; set; }
        public VehicleColor PearlescentColor { get; set; }
        public VehicleColor TrimColor { get; set; }
        public VehicleColor RimColor { get; set; }
        public VehicleColor DashboardColor { get; set; }
        public int ColorCombination { get; set; } = 1;
        public string LicensePlate { get; set; } = "49KWL722";
        public LicensePlateStyle LicensePlateStyle { get; set; }

        public Color NeonLightsColor { get; set; }
        public bool NeonBack { get; set; }
        public bool NeonFront { get; set; }
        public bool NeonLeft { get; set; }
        public bool NeonRight { get; set; }

        public VehicleWheelType WheelType { get; set; }

        public bool BulletProofTires { get; set; }
        public Color TireSmokeColor { get; set; }

        public VehicleWindowTint WindowTint { get; set; }
        public int Livery { get; set; } = -1;

        public Color CustomPrimaryColor { get; set; }
        public Color CustomSecondaryColor { get; set; }

        public bool Turbo { get; internal set; }
        public bool TireSmoke { get; internal set; }
        public bool XenonHeadlights { get; internal set; }

        public List<VehicleModModel> Mods { get; internal set; } = new List<VehicleModModel>();


        public static VehicleModel FromVehicle(Vehicle vehicle)
        {
            return new VehicleModel()
            {
                VehicleHash = vehicle.Model,
                BulletProofTires = vehicle.CanTiresBurst,
                WheelType = vehicle.Mods.WheelType,
                LicensePlate = vehicle.Mods.LicensePlate,
                LicensePlateStyle = vehicle.Mods.LicensePlateStyle,
                PrimaryColor = vehicle.Mods.PrimaryColor,
                SecondaryColor = vehicle.Mods.SecondaryColor,
                PearlescentColor = vehicle.Mods.PearlescentColor,
                RimColor = vehicle.Mods.RimColor,
                TrimColor = vehicle.Mods.TrimColor,
                WindowTint = vehicle.Mods.WindowTint,

                CustomPrimaryColor = vehicle.Mods.CustomPrimaryColor,
                CustomSecondaryColor = vehicle.Mods.CustomSecondaryColor,
                NeonLightsColor = vehicle.Mods.NeonLightsColor,
                NeonBack = vehicle.Mods.IsNeonLightsOn(VehicleNeonLight.Back),
                NeonFront = vehicle.Mods.IsNeonLightsOn(VehicleNeonLight.Front),
                NeonLeft = vehicle.Mods.IsNeonLightsOn(VehicleNeonLight.Left),
                NeonRight = vehicle.Mods.IsNeonLightsOn(VehicleNeonLight.Right),
                TireSmokeColor = vehicle.Mods.TireSmokeColor,
                DashboardColor = vehicle.Mods.DashboardColor,
                ColorCombination = vehicle.Mods.ColorCombination,
                Livery = vehicle.Mods.Livery,

                Turbo = vehicle.Mods[VehicleToggleModType.Turbo].IsInstalled,
                TireSmoke = vehicle.Mods[VehicleToggleModType.TireSmoke].IsInstalled,
                XenonHeadlights = vehicle.Mods[VehicleToggleModType.XenonHeadlights].IsInstalled,

                Mods = vehicle.Mods.ToArray()
                    .Select(mod => new VehicleModModel() { Type = mod.Type, Index = mod.Index, Variation = mod.Variation })
                    .ToList(),
            };
        }


        public void ApplyToVehicle(Vehicle vehicle)
        {
            vehicle.CanTiresBurst = BulletProofTires;
            vehicle.Mods.WheelType = WheelType;
            vehicle.Mods.LicensePlate = LicensePlate;
            vehicle.Mods.LicensePlateStyle = LicensePlateStyle;

            vehicle.Mods.NeonLightsColor = NeonLightsColor;
            vehicle.Mods.SetNeonLightsOn(VehicleNeonLight.Back, NeonBack);
            vehicle.Mods.SetNeonLightsOn(VehicleNeonLight.Front, NeonFront);
            vehicle.Mods.SetNeonLightsOn(VehicleNeonLight.Left, NeonLeft);
            vehicle.Mods.SetNeonLightsOn(VehicleNeonLight.Right, NeonRight);

            vehicle.Mods.Livery = Livery;

            GTA.Native.Function.Call(GTA.Native.Hash.SET_VEHICLE_MOD_KIT, vehicle, 0);
            foreach (var myMod in Mods)
            {
                GTA.Native.Function.Call(GTA.Native.Hash.SET_VEHICLE_MOD, vehicle, myMod.Type, myMod.Index, myMod.Variation);
            }

            vehicle.Mods[VehicleToggleModType.Turbo].IsInstalled = Turbo;
            vehicle.Mods[VehicleToggleModType.TireSmoke].IsInstalled = TireSmoke;
            vehicle.Mods[VehicleToggleModType.XenonHeadlights].IsInstalled = XenonHeadlights;


            //colors should be at at the end. Eventual model replacement (wheels) would reset the color;
            vehicle.Mods.PrimaryColor = PrimaryColor;
            vehicle.Mods.SecondaryColor = SecondaryColor;
            vehicle.Mods.PearlescentColor = PearlescentColor;
            vehicle.Mods.ColorCombination = ColorCombination;

            //this resets the primary and secondary colors. This way it's not possible to set the chrome color.
            //vehicle.Mods.CustomPrimaryColor = CustomPrimaryColor;
            //vehicle.Mods.CustomSecondaryColor = CustomSecondaryColor;

            vehicle.Mods.RimColor = RimColor;
            vehicle.Mods.TrimColor = TrimColor;
            vehicle.Mods.WindowTint = WindowTint;
            vehicle.Mods.TireSmokeColor = TireSmokeColor;
            vehicle.Mods.DashboardColor = DashboardColor;
        }

    }



    public class VehicleModModel
    {
        public int Index { get; internal set; }
        public bool Variation { get; internal set; }
        public VehicleModType Type { get; internal set; }
    }
}
