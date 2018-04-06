using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal
{
    class ProcessingData : IProcessingData
    {
        public ProcessingData(double energyBalance, double capitalBalance)
        {
            EnergyBalance = energyBalance;
            CapitalBalance = capitalBalance;
        }
        public double EnergyBalance { get; set; }
        public double CapitalBalance { get; set; }

    }
}