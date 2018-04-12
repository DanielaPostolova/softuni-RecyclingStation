using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.Commands
{
    public class ChangeManagementRequirementCommand : ICommand
    {
        private readonly IComponentContext componentContext;

        public ChangeManagementRequirementCommand(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }
        public string Execute(IList<string> args)
        {
            if (args == null)
            {
                throw new ArgumentException();
            }

            double energyLowBorder = double.Parse(args[0]);
            double capitalLowBorder = double.Parse(args[1]);
            string garbage = args[2];
            
            var processor = this.componentContext.Resolve<IGarbageProcessor>();
            processor.Restriction = new Restriction(garbage, energyLowBorder, capitalLowBorder);

            return "Management requirement changed!";
        }
    }
}