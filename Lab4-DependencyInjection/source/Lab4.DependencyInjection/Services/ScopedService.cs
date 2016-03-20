using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.DependencyInjection.Services
{
    public class ScopedService: IScopedService
    {
        public string Message { get; }

        public ScopedService()
        {
            Message = Guid.NewGuid().ToString();
        }
    }
}
