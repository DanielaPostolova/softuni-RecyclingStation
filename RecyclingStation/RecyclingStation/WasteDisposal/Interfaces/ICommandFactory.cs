namespace RecyclingStation.WasteDisposal.Interfaces
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string commandName);
    }
}