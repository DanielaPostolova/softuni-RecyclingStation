using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.TypesOfWaste
{
    [StorableGarbageDispose]
    public class StorableGarbage : IWaste
    {
        public StorableGarbage(string name, double volumePerKg, double weight)
        {
            Name = name;
            VolumePerKg = volumePerKg;
            Weight = weight;
        }
        public string Name { get; }
        public double VolumePerKg { get; }
        public double Weight { get; }
        
        
    }
}