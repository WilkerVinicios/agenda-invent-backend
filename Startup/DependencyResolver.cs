
using Busines.Services;
using Domain.Contracts.Repository;
using Domain.Contracts.Services;
using Domain.Model;
using Infraestructure.Data;
using Infraestructure.Repository;
using Unity;
using Unity.Lifetime;

namespace Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IContatoRepository, ContatoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IContatoService, ContatoService>(new HierarchicalLifetimeManager());
            container.RegisterType<Contato, Contato>(new HierarchicalLifetimeManager());
        }
    }
}
