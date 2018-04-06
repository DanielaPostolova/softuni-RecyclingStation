using System;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;
using RecyclingStation.WasteDisposal.Models.TypesOfWaste;

namespace RecyclingStation.WasteDisposal.Models.DisposalStrategies
{
    public class RecyclableGarbageDisposeStrategy : IGarbageDisposalStrategy
    {
        public Type DisposeAttributeType => typeof(RecyclableGarbageDisposeAttribute);

        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            if (garbage == null || garbage.GetType() != typeof(RecyclableGarbage))
            {
                throw new ArgumentException();
            }

            double totalVolume = garbage.VolumePerKg * garbage.Weight;

            return new ProcessingData(-totalVolume / 2, 400 * garbage.Weight);
        }
    }
}