using System.Collections.Generic;
using System.Linq;
using RecyclingStation.WasteDisposal.Interfaces;
using RecyclingStation.WasteDisposal.Models.Factories;

namespace RecyclingStation.WasteDisposal
{
    public class Engine : IEngine
    {
        private readonly IConsoleRenderer consoleRenderer;
        private readonly ICommandFactory commandFactory;

        public Engine(IConsoleRenderer consoleRenderer, ICommandFactory commandFactory)
        {
            this.consoleRenderer = consoleRenderer;
            this.commandFactory = commandFactory;
        }
        
        public void Start()
        {
            string inputLine;

            while ((inputLine = consoleRenderer.ReadLine()) != "TimeToRecycle")
            {
                var input = inputLine.Split();

                var commandName = input[0];

                var command = commandFactory.GetCommand(commandName);

                IList<string> commandParams = new List<string>();
                if (input.Length > 1)
                {
                    commandParams = input[1].Split('|');
                }
                
                var result = command.Execute(commandParams);

                this.consoleRenderer.WriteLine(result);
            }
        }
    }
}