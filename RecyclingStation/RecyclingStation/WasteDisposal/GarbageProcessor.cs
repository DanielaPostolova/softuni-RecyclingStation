using System;
using System.Linq;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;
using RecyclingStation.WasteDisposal.Models.TypesOfWaste;

namespace RecyclingStation.WasteDisposal
{
    public class GarbageProcessor : IGarbageProcessor
    {
        private readonly IProcessingData currentData;

        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
            this.currentData = new ProcessingData(0, 0);
            this.CurrentRequirement = ManagementRequirements.None;
        }

        public IStrategyHolder StrategyHolder { get; }

        public ManagementRequirements CurrentRequirement { get; set; }
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

            if (garbageType.Name.Contains(this.CurrentRequirement.ToString()))
            {
                var capitalBorderProp = (double)garbageType.GetProperty("CapitalLowBorder").GetValue(null, null);
                if (this.currentData.CapitalBalance < capitalBorderProp)
                {
                    throw new InvalidOperationException("Processing Denied!");
                }

                var energyBorderProp = (double)garbageType.GetProperty("EnergyLowBorder").GetValue(null, null);
                if (this.currentData.EnergyBalance < energyBorderProp)
                {
                    throw new InvalidOperationException("Processing Denied!");
                }
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
