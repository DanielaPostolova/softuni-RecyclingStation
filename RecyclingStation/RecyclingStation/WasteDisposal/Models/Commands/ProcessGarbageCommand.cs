using System;
using System.Collections.Generic;
using Autofac;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.Commands
{
    class ProcessGarbageCommand : ICommand
    {
        private readonly IGarbageProcessor garbageProcessor;
        private readonly IWasteFactory wasteFactory;

        public ProcessGarbageCommand(IGarbageProcessor garbageProcessor, IWasteFactory wasteFactory)
        {
            this.garbageProcessor = garbageProcessor;
            this.wasteFactory = wasteFactory;
        }

        public string Execute(IList<string> args)
        {
            if (args == null)
            {
                throw new ArgumentException();
            }

            string result;
            try
            {
                string wasteName = args[0];
                double wasteWeight = double.Parse(args[1]);
                double wasteVolumePerKg = double.Parse(args[2]);

                string typeOfWaste = args[3];



                var waste = this.wasteFactory.GetWaste(typeOfWaste, wasteName, wasteVolumePerKg, wasteWeight);
                this.garbageProcessor.ProcessWaste(waste);

                result = $"{wasteWeight:0.00} kg of {wasteName} successfully processed!";

            }
            catch (Exception e)
            {
                return e.Message;
            }

            return result;
            
        }
    }
}