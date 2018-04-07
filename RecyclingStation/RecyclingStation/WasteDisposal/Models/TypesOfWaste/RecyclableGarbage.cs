using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.TypesOfWaste
{
    [RecyclableGarbageDispose]
    public class RecyclableGarbage : IWaste
    {
        private static double _capitalLowBorder = double.MinValue;
        private static double _energyLowBorder = double.MinValue;

        public RecyclableGarbage(string name, double volumePerKg, double weight)
        {
            Name = name;
            VolumePerKg = volumePerKg;
            Weight = weight;
        }
        public string Name { get; }
        public double VolumePerKg { get; }
        public double Weight { get; }

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