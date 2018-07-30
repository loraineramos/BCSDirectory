using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDirectoryProcessor.Interfaces
{
    public interface IContainer
    {
        Container ConfigureServices(IServiceCollection services);
    }
}
