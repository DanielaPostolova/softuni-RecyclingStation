using System;
using System.Collections.Generic;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal
{
    internal class StrategyHolder : IStrategyHolder
    {
        private IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder()
        {
            this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        }

        public IReadOnlyDictionary<Type,IGarbageDisposalStrategy> GetDisposalStrategies => (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies;

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            if (disposableAttribute == null || strategy == null)
            {
                throw new ArgumentException();
            }

            this.strategies.Add(disposableAttribute, strategy);
            return true;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            if (disposableAttribute == null)
            {
                throw new ArgumentException();
            }

            return this.strategies.Remove(disposableAttribute);
        }
    }
}
