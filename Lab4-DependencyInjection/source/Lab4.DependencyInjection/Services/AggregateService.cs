using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.DependencyInjection.Services
{
    public class AggregateService : IAggregateService
    {
        public AggregateService(IInstanceService instance, IScopedService scoped, ITransientService transient,ISingletonService singleton)
        {
            Instance = instance;
            Scoped = scoped;
            Transient = transient;
            Singleton = singleton;
        }

        public IInstanceService Instance { get; }
        public IScopedService Scoped { get; }
        public ITransientService Transient { get; }
        public ISingletonService Singleton { get; }
    }
}
