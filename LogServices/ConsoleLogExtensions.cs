using LogServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConsoleLogExtensions
    {
        public static void AddConsoleLog(this IServiceCollection service)
        {
            service.AddScoped<ILogProvider, ConsoleLogProvider>();
        }
    }
}
