using System;
using System.Linq;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal
{
    public class GarbageProcessor : IGarbageProcessor
    {
        private readonly IProcessingData currentData;

        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
            this.currentData = new ProcessingData(0, 0);
        }

        public IStrategyHolder StrategyHolder { get; }

        public IProcessingData CurrentData 
            => new ProcessingData(currentData.EnergyBalance, currentData.CapitalBalance);

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            Type garbageType = garbage.GetType();

            var disposalAttribute = garbageType
                .GetCustomAttributes(true)
                .FirstOrDefault(x => x.GetType().Name.Contains("DisposeAttribute"));

            IGarbageDisposalStrategy currentStrategy = null;

            var disposalStrategyExists = disposalAttribute != null && this.StrategyHolder
                                             .GetDisposalStrategies
                                             .TryGetValue(disposalAttribute.GetType(), out currentStrategy);

            if (disposalAttribute == null || !disposalStrategyExists)
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            var resultData = currentStrategy.ProcessGarbage(garbage);
            this.UpdateCurrentData(resultData);

            return resultData;
        }

        private void UpdateCurrentData(IProcessingData newData)
        {
            this.currentData.CapitalBalance += newData.CapitalBalance;
            this.currentData.EnergyBalance += newData.EnergyBalance;
        }
    }
}
