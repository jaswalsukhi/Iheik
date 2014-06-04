using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Iheik.Providers;
namespace Iheik.Installers
{
    public class MembershipProviderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMembershipProvider>()
                .ImplementedBy<MembershipProvider>()
                .LifeStyle.Transient);
        }
    }
}