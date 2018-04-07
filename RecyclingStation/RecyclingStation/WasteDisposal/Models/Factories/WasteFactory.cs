using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.Factories
{
    public class WasteFactory : IWasteFactory
    {
        private IComponentContext componentContext;

        public WasteFactory(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public IWaste GetWaste(string typeOfWaste, string name, double volumePerKg,  double weight)
        {
            var wasteType = Assembly.GetAssembly(typeof(IWaste))
                .GetTypes()
                .FirstOrDefault(x => 
                    x.GetInterfaces().Contains(typeof(IWaste)) && x.Name.Contains(typeOfWaste))
                ?? throw new ArgumentException();

            return this.componentContext.ResolveNamed<IWaste>(typeOfWaste, new NamedParameter("name", name), new NamedParameter("volumePerKg", volumePerKg), new NamedParameter("weight", weight));
        }
    }
}