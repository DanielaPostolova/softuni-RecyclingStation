using System.Collections.Generic;

namespace RecyclingStation.WasteDisposal.Interfaces
{
    public interface ICommand
    {
        string Execute(IList<string> args);
    }
}