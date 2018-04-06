using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.TypesOfWaste
{
    [RecyclableGarbageDispose]
    public class RecyclableGarbage : IWaste
    {
        public RecyclableGarbage(string name, double volumePerKg, double weight)
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