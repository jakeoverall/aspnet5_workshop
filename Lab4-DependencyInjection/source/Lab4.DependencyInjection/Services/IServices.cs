using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.DependencyInjection.Services
{
    public interface ISingletonService
    {
        string Message { get; }
    }

    public interface ITransientService
    {
        string Message { get; }
    }

    public interface IScopedService
    {
        string Message { get; }
    }

    public interface IInstanceService
    {
        string Message { get; }
    }

    public interface IAggregateService
    {
        IInstanceService Instance { get; }
        IScopedService Scoped { get; }
        ITransientService Transient { get; }
        ISingletonService Singleton { get; }
    }
}
