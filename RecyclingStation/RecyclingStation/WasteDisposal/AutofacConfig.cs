using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Reflection;
using Autofac;
using RecyclingStation.WasteDisposal.Interfaces;
using RecyclingStation.WasteDisposal.Models.Factories;

namespace RecyclingStation.WasteDisposal
{
    public static class AutofacConfig
    {
        private static IContainer container;
        public static IContainer Container
        {
            get
            {
                if (container == null)
                {
                    throw new InvalidOperationException();
                }

                return container;
            }
        }

        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(x => SetupStrategyHolder());
            builder.RegisterType<Engine>().As<IEngine>();
            builder.RegisterType<WasteFactory>().As<IWasteFactory>();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>();
            builder.RegisterType<GarbageProcessor>().As<IGarbageProcessor>().SingleInstance();
            builder.RegisterType<ConsoleRenderer>().As<IConsoleRenderer>();

            RegisterCommandTypes(builder);
            RegisterWasteTypes(builder);

            container = builder.Build();
            return container;
        }

        private static void RegisterCommandTypes(ContainerBuilder builder)
        {
            var commandTypes = Assembly.GetAssembly(typeof(ICommand))
                .DefinedTypes
                .Where(x => x.ImplementedInterfaces.Contains(typeof(ICommand)));

            foreach (var commandType in commandTypes)
            {
                var commandName = commandType.Name.Replace("Command", String.Empty);
                builder.RegisterType(commandType.AsType()).Named<ICommand>(commandName);
            }
        }

        private static void RegisterWasteTypes(ContainerBuilder builder)
        {
            var wasteTypes = Assembly.GetAssembly(typeof(IWaste))
                .DefinedTypes
                .Where(x => x.ImplementedInterfaces.Contains(typeof(IWaste)));

            foreach (var wasteType in wasteTypes)
            {
                var wasteName = wasteType.Name.Replace("Garbage", string.Empty);
                builder.RegisterType(wasteType.AsType())
                    .Named<IWaste>(wasteName)
                    .WithParameter("name", string.Empty)
                    .WithParameter("volumePerKg", 0)
                    .WithParameter("weight", 0);
            }
        }

        private static IStrategyHolder SetupStrategyHolder()
        {
            var strategyHolder = new StrategyHolder();

            var strategies = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterfaces().Contains(typeof(IGarbageDisposalStrategy)));

            foreach (var strategy in strategies)
            {
                var disposalStrategy = (IGarbageDisposalStrategy)Activator.CreateInstance(strategy);

                strategyHolder.AddStrategy(disposalStrategy.DisposeAttributeType, disposalStrategy);
            }

            return strategyHolder;
        }
    }
}