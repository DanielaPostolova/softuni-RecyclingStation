using System;
using System.Collections.Generic;
using Autofac;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.Commands
{
    class StatusCommand : ICommand
    {
        private readonly IGarbageProcessor garbageProcessor;

        public StatusCommand(IGarbageProcessor garbageProcessor)
        {
            this.garbageProcessor = garbageProcessor;
        }

        public string Execute(IList<string> args)
        {
            if (args.Count != 0)
            {
                throw new ArgumentException();
            }

            return $"Energy: {this.garbageProcessor.CurrentData.EnergyBalance:0.00} Capital: {this.garbageProcessor.CurrentData.CapitalBalance:0.00}";
        }
    }
}