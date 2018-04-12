using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.TypesOfWaste
{
    [BurnableGarbageDispose]
    public class BurnableGarbage : IWaste
    {
        public BurnableGarbage(string name, double volumePerKg, double weight)
        {
            Name = name;
            VolumePerKg = volumePerKg;
            Weight = weight;
        }
        
        public string Name { get; set; }
        public double VolumePerKg { get; set; }
        public double Weight { get; set; }

    }
}