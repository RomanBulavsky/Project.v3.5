using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using NinjectConfigurator;

namespace RFoundation.PL.WEB.Infrastructure
{
    public class DependencyResolverNinject : IDependencyResolver
    {
        private IKernel kernel;

        public DependencyResolverNinject(IKernel kernel)
        {
            this.kernel = kernel;
            kernel.ConfigurateResolverWeb();
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