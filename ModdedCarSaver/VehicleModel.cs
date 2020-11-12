using GTA;
using System.Drawing;

namespace ModdedCarSaver
{
    public class VehicleModel
    {



        public VehicleHash VehicleHash { get; set; }
        public VehicleColor PrimaryColor { get; set; }
        public VehicleColor SecondaryColor { get; set; }
        public VehicleColor PearlescentColor { get; set; }
        public VehicleColor TrimColor { get; set; }
        public VehicleColor RimColor { get; set; }
        public VehicleColor DashboardColor { get; set; }
        public int ColorCombination { get; set; }
        public string LicensePlate { get; set; }
        public LicensePlateStyle LicensePlateStyle { get; set; }

        public Color NeonLightsColor { get; set; }
        public bool NeonBack { get; set; }
        public bool NeonFront { get; set; }
        public bool NeonLeft { get; set; }
        public bool NeonRight { get; set; }

        public VehicleWheelType WheelType { get; set; }

        public bool FrontWheelVariation { get; set; }
        public bool BackWheelVariation { get; set; }

        public bool BulletProofTires { get; set; }

        public Color TireSmokeColor { get; set; }

        public VehicleWindowTint WindowTint { get; set; }
        public int LiveryMod { get; set; }

        public Color CustomPrimaryColor { get; set; }
        public Color CustomSecondaryColor { get; set; }

        public int Spoilers { get; internal set; }
        public int FrontBumper { get; internal set; }
        public int RearBumper { get; internal set; }
        public int SideSkirt { get; internal set; }
        public int Exhaust { get; internal set; }
        public int Frame { get; internal set; }
        public int Grille { get; internal set; }
        public int Hood { get; internal set; }
        public int Fender { get; internal set; }
        public int RightFender { get; internal set; }
        public int Roof { get; internal set; }
        public int Engine { get; internal set; }
        public int Brakes { get; internal set; }
        public int Transmission { get; internal set; }
        public int Horns { get; internal set; }
        public int Suspension { get; internal set; }
        public int Armor { get; internal set; }
        public int FrontWheel { get; internal set; }
        public int RearWheel { get; internal set; }
        public int PlateHolder { get; internal set; }
        public int VanityPlates { get; internal set; }
        public int TrimDesign { get; internal set; }
        public int Ornaments { get; internal set; }
        public int Dashboard { get; internal set; }
        public int DialDesign { get; internal set; }
        public int DoorSpeakers { get; internal set; }
        public int Seats { get; internal set; }
        public int SteeringWheels { get; internal set; }
        public int ColumnShifterLevers { get; internal set; }
        public int Plaques { get; internal set; }
        public int Speakers { get; internal set; }
        public int Trunk { get; internal set; }
        public int Hydraulics { get; internal set; }
        public int EngineBlock { get; internal set; }
        public int AirFilter { get; internal set; }
        public int Struts { get; internal set; }
        public int ArchCover { get; internal set; }
        public int Aerials { get; internal set; }
        public int Trim { get; internal set; }
        public int Tank { get; internal set; }
        public int Windows { get; internal set; }
        public int Livery { get; internal set; }

        public bool Turbo { get; internal set; }
        public bool TireSmoke { get; internal set; }
        public bool XenonHeadlights { get; internal set; }




        public static VehicleModel FromVehicle(Vehicle v)
        {
            VehicleModel m = new VehicleModel()
            {
                VehicleHash = v.Model,

                CustomPrimaryColor = v.Mods.CustomPrimaryColor,
                CustomSecondaryColor = v.Mods.CustomSecondaryColor,
                PearlescentColor = v.Mods.PearlescentColor,
                TrimColor = v.Mods.TrimColor,
                RimColor = v.Mods.RimColor,
                LicensePlate = v.Mods.LicensePlate,
                LicensePlateStyle = v.Mods.LicensePlateStyle,
                NeonLightsColor = v.Mods.NeonLightsColor,
                NeonBack = v.Mods.IsNeonLightsOn(VehicleNeonLight.Back),
                NeonFront = v.Mods.IsNeonLightsOn(VehicleNeonLight.Front),
                NeonLeft = v.Mods.IsNeonLightsOn(VehicleNeonLight.Left),
                NeonRight = v.Mods.IsNeonLightsOn(VehicleNeonLight.Right),
                TireSmokeColor = v.Mods.TireSmokeColor,
                WindowTint = v.Mods.WindowTint,
                DashboardColor = v.Mods.DashboardColor,
                ColorCombination = v.Mods.ColorCombination,
                SecondaryColor = v.Mods.SecondaryColor,
                PrimaryColor = v.Mods.PrimaryColor,
                LiveryMod = v.Mods.Livery,
                WheelType = v.Mods.WheelType,


                Spoilers = v.Mods[VehicleModType.Spoilers].Index,
                FrontBumper = v.Mods[VehicleModType.FrontBumper].Index,
                RearBumper = v.Mods[VehicleModType.RearBumper].Index,
                SideSkirt = v.Mods[VehicleModType.SideSkirt].Index,
                Exhaust = v.Mods[VehicleModType.Exhaust].Index,
                Frame = v.Mods[VehicleModType.Frame].Index,
                Grille = v.Mods[VehicleModType.Grille].Index,
                Hood = v.Mods[VehicleModType.Hood].Index,
                Fender = v.Mods[VehicleModType.Fender].Index,
                RightFender = v.Mods[VehicleModType.RightFender].Index,
                Roof = v.Mods[VehicleModType.Roof].Index,
                Engine = v.Mods[VehicleModType.Engine].Index,
                Brakes = v.Mods[VehicleModType.Brakes].Index,
                Transmission = v.Mods[VehicleModType.Transmission].Index,
                Horns = v.Mods[VehicleModType.Horns].Index,
                Suspension = v.Mods[VehicleModType.Suspension].Index,
                Armor = v.Mods[VehicleModType.Armor].Index,
                FrontWheel = v.Mods[VehicleModType.FrontWheel].Index,
                RearWheel = v.Mods[VehicleModType.RearWheel].Index,
                PlateHolder = v.Mods[VehicleModType.PlateHolder].Index,
                VanityPlates = v.Mods[VehicleModType.VanityPlates].Index,
                TrimDesign = v.Mods[VehicleModType.TrimDesign].Index,
                Ornaments = v.Mods[VehicleModType.Ornaments].Index,
                Dashboard = v.Mods[VehicleModType.Dashboard].Index,
                DialDesign = v.Mods[VehicleModType.DialDesign].Index,
                DoorSpeakers = v.Mods[VehicleModType.DoorSpeakers].Index,
                Seats = v.Mods[VehicleModType.Seats].Index,
                SteeringWheels = v.Mods[VehicleModType.SteeringWheels].Index,
                ColumnShifterLevers = v.Mods[VehicleModType.ColumnShifterLevers].Index,
                Plaques = v.Mods[VehicleModType.Plaques].Index,
                Speakers = v.Mods[VehicleModType.Speakers].Index,
                Trunk = v.Mods[VehicleModType.Trunk].Index,
                Hydraulics = v.Mods[VehicleModType.Hydraulics].Index,
                EngineBlock = v.Mods[VehicleModType.EngineBlock].Index,
                AirFilter = v.Mods[VehicleModType.AirFilter].Index,
                Struts = v.Mods[VehicleModType.Struts].Index,
                ArchCover = v.Mods[VehicleModType.ArchCover].Index,
                Aerials = v.Mods[VehicleModType.Aerials].Index,
                Trim = v.Mods[VehicleModType.Trim].Index,
                Tank = v.Mods[VehicleModType.Tank].Index,
                Windows = v.Mods[VehicleModType.Windows].Index,
                Livery = v.Mods[VehicleModType.Livery].Index,


                Turbo = v.Mods[VehicleToggleModType.Turbo].IsInstalled,
                TireSmoke = v.Mods[VehicleToggleModType.TireSmoke].IsInstalled,
                XenonHeadlights = v.Mods[VehicleToggleModType.XenonHeadlights].IsInstalled,
                BulletProofTires = v.CanTiresBurst,

                BackWheelVariation = v.Mods[VehicleModType.RearWheel].Variation,
                FrontWheelVariation = v.Mods[VehicleModType.FrontWheel].Variation,

            };

            return m;

        }


        public void ApplyToVehicle(Vehicle v)
        {
            v.Mods.PrimaryColor = PrimaryColor;
            v.Mods.SecondaryColor = SecondaryColor;
            v.Mods.CustomPrimaryColor = CustomPrimaryColor;
            v.Mods.CustomSecondaryColor = CustomSecondaryColor;
            v.Mods.PearlescentColor = PearlescentColor;
            v.Mods.TrimColor = TrimColor;
            v.Mods.RimColor = RimColor;
            v.Mods.LicensePlate = LicensePlate;
            v.Mods.LicensePlateStyle = LicensePlateStyle;
            v.Mods.NeonLightsColor = NeonLightsColor;

            v.Mods.SetNeonLightsOn(VehicleNeonLight.Back, NeonBack);
            v.Mods.SetNeonLightsOn(VehicleNeonLight.Front, NeonFront);
            v.Mods.SetNeonLightsOn(VehicleNeonLight.Left, NeonLeft);
            v.Mods.SetNeonLightsOn(VehicleNeonLight.Right, NeonRight);

            v.Mods.TireSmokeColor = TireSmokeColor;
            v.Mods.WindowTint = WindowTint;
            v.Mods.DashboardColor = DashboardColor;
            v.Mods.ColorCombination = ColorCombination;
            //v.Mods.Livery = LiveryMod;
            v.Mods.WheelType = WheelType;


            v.Mods[VehicleModType.Spoilers].Index = Spoilers;
            v.Mods[VehicleModType.FrontBumper].Index = FrontBumper;
            v.Mods[VehicleModType.RearBumper].Index = RearBumper;
            v.Mods[VehicleModType.SideSkirt].Index = SideSkirt;
            v.Mods[VehicleModType.Exhaust].Index = Exhaust;
            v.Mods[VehicleModType.Frame].Index = Frame;
            v.Mods[VehicleModType.Grille].Index = Grille;
            v.Mods[VehicleModType.Hood].Index = Hood;
            v.Mods[VehicleModType.Fender].Index = Fender;
            v.Mods[VehicleModType.RightFender].Index = RightFender;
            v.Mods[VehicleModType.Roof].Index = Roof;
            v.Mods[VehicleModType.Engine].Index = Engine;
            v.Mods[VehicleModType.Brakes].Index = Brakes;
            v.Mods[VehicleModType.Transmission].Index = Transmission;
            v.Mods[VehicleModType.Horns].Index = Horns;
            v.Mods[VehicleModType.Suspension].Index = Suspension;
            v.Mods[VehicleModType.Armor].Index = Armor;
            v.Mods[VehicleModType.FrontWheel].Index = FrontWheel;
            v.Mods[VehicleModType.RearWheel].Index = RearWheel;
            v.Mods[VehicleModType.PlateHolder].Index = PlateHolder;
            v.Mods[VehicleModType.VanityPlates].Index = VanityPlates;
            v.Mods[VehicleModType.TrimDesign].Index = TrimDesign;
            v.Mods[VehicleModType.Ornaments].Index = Ornaments;
            v.Mods[VehicleModType.Dashboard].Index = Dashboard;
            v.Mods[VehicleModType.DialDesign].Index = DialDesign;
            v.Mods[VehicleModType.DoorSpeakers].Index = DoorSpeakers;
            v.Mods[VehicleModType.Seats].Index = Seats;
            v.Mods[VehicleModType.SteeringWheels].Index = SteeringWheels;
            v.Mods[VehicleModType.ColumnShifterLevers].Index = ColumnShifterLevers;
            v.Mods[VehicleModType.Plaques].Index = Plaques;
            v.Mods[VehicleModType.Speakers].Index = Speakers;
            v.Mods[VehicleModType.Trunk].Index = Trunk;
            v.Mods[VehicleModType.Hydraulics].Index = Hydraulics;
            v.Mods[VehicleModType.EngineBlock].Index = EngineBlock;
            v.Mods[VehicleModType.AirFilter].Index = AirFilter;
            v.Mods[VehicleModType.Struts].Index = Struts;
            v.Mods[VehicleModType.ArchCover].Index = ArchCover;
            v.Mods[VehicleModType.Aerials].Index = Aerials;
            v.Mods[VehicleModType.Trim].Index = Trim;
            v.Mods[VehicleModType.Tank].Index = Tank;
            v.Mods[VehicleModType.Windows].Index = Windows;
            //  v.Mods[VehicleModType.Livery].Index = Livery;


            v.Mods[VehicleToggleModType.Turbo].IsInstalled = Turbo;
            v.Mods[VehicleToggleModType.TireSmoke].IsInstalled = TireSmoke;
            v.Mods[VehicleToggleModType.XenonHeadlights].IsInstalled = XenonHeadlights;
            v.CanTiresBurst = BulletProofTires;

            v.Mods[VehicleModType.RearWheel].Variation = BackWheelVariation;
            v.Mods[VehicleModType.FrontWheel].Variation = FrontWheelVariation;




        }
    }
}
