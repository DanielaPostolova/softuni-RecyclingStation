namespace RecyclingStation.WasteDisposal.Interfaces
{
    public interface IWasteFactory
    {
        IWaste GetWaste(string typeOfWaste, string name, double weight, double volumePerkg);
    }
}