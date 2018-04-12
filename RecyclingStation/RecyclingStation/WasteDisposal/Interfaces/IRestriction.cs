namespace RecyclingStation.WasteDisposal.Interfaces
{
    public interface IRestriction
    {
        string RestrictionType { get; set; }
        double CapitalLowBorder { get; set; }
        double EnergyLowBorder { get; set; }
    }
}