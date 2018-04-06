using System;
using Autofac;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation
{
    public class RecyclingStationMain
    {
        private static void Main(string[] args)
        {
            var container = AutofacConfig.BuildContainer();
            var engine = container.Resolve<IEngine>();

            engine.Start();

        }

    }
}
