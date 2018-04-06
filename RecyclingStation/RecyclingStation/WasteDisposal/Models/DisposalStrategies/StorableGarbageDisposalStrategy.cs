using System;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;
using RecyclingStation.WasteDisposal.Models.TypesOfWaste;

namespace RecyclingStation.WasteDisposal.Models.DisposalStrategies
{
    public class StorableGarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public Type DisposeAttributeType => typeof(StorableGarbageDisposeAttribute);

        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            if (garbage == null || garbage.GetType() != typeof(StorableGarbage))
            {
                throw new ArgumentException();
            }

            double totalVolume = garbage.Weight * garbage.VolumePerKg;

            return new ProcessingData(-13 * totalVolume / 100, -65 * totalVolume / 100);
        }
    }
}