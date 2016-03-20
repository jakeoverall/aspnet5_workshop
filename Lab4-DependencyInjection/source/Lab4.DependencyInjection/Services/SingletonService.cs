using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.DependencyInjection.Services
{
    public class SingletonService: ISingletonService
    {
        public String Message { get; }

        public SingletonService()
        {
            Message = Guid.NewGuid().ToString();
        }
    }
}
