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

            var garbageType = Assembly.GetAssembly(typeof(IWaste))
                .GetTypes()
                .FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IWaste)) && x.Name.Contains(garbage));
            
            garbageType.GetProperty("CapitalLowBorder")?.SetValue(null, capitalLowBorder);
            garbageType.GetProperty("EnergyLowBorder")?.SetValue(null, energyLowBorder);
            
            var processor = this.componentContext.Resolve<IGarbageProcessor>();
            var enumValues = Enum.GetValues(typeof(ManagementRequirements));
            foreach (var enumValue in enumValues)
            {
                if (enumValue.ToString().Contains(garbage))
                    processor.CurrentRequirement = (ManagementRequirements) enumValue;
            }

            return "Management requirement changed!";
        }
    }
}