using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal
{
    public class Restriction : IRestriction
    {
        public Restriction(string restrictionType, double energyLowBorder, double capitalLowBorder)
        {
            RestrictionType = restrictionType;
            CapitalLowBorder = capitalLowBorder;
            EnergyLowBorder = energyLowBorder;
        }
        public string RestrictionType { get; set; }
        public double CapitalLowBorder { get; set; }
        public double EnergyLowBorder { get; set; }
    }
}