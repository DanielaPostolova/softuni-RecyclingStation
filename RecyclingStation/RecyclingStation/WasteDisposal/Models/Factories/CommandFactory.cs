using System;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Autofac;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.Factories
{
    class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext componentContext;

        public CommandFactory(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }
        public ICommand GetCommand(string commandName)
        {
            var commandType = Assembly.GetAssembly(typeof(ICommand))
                .GetTypes()
                .FirstOrDefault(x =>
                    x.GetInterfaces().Contains(typeof(ICommand)) && x.Name.Contains(commandName))
                ?? throw new ArgumentNullException();

            return this.componentContext.ResolveNamed<ICommand>(commandName);
        }
    }
}