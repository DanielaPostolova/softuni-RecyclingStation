using System;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;
using RecyclingStation.WasteDisposal.Models.TypesOfWaste;

namespace RecyclingStation.WasteDisposal.Models.DisposalStrategies
{
    public class BurnableGarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public Type DisposeAttributeType => typeof(BurnableGarbageDisposeAttribute);

        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            if (garbage == null || garbage.GetType() != typeof(BurnableGarbage))
            {
                throw new ArgumentException();
            }

            double totalVolume = garbage.VolumePerKg * garbage.Weight;

            return new ProcessingData(4 * totalVolume / 5, 0);
        }
    }
}