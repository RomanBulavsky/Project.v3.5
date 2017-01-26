using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace RFoundation.PL.WEB.Infrastructure
{
    public class DependencyResolverNinject
    {
        private IKernel kernel;

        public DependencyResolverNinject(IKernel kernel)
        {
            this.kernel = kernel;
            kernel.ConfigurateResolverWeb();// Exten
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}