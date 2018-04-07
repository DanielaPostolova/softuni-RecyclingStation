using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.TypesOfWaste
{
    [BurnableGarbageDispose]
    public class BurnableGarbage : IWaste
    {
        private static double _capitalLowBorder = double.MinValue;
        private static double _energyLowBorder = double.MinValue;

        public BurnableGarbage(string name, double volumePerKg, double weight)
        {
            Name = name;
            VolumePerKg = volumePerKg;
            Weight = weight;
        }
        
        public string Name { get; set; }
        public double VolumePerKg { get; set; }
        public double Weight { get; set; }

        public static double CapitalLowBorder
        {
            get => _capitalLowBorder;
            set => _capitalLowBorder = value;
        }

        public static double EnergyLowBorder
        {
            get => _energyLowBorder;
            set => _energyLowBorder = value;
        }
    }
}