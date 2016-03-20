using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.DependencyInjection.Services
{
    public class TransientService: ITransientService
    {
        public string Message { get; }

        public TransientService()
        {
            Message = Guid.NewGuid().ToString();
        }
    }
}
