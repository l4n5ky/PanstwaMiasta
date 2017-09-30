using Autofac;
using PanstwaMiasta.Infrastructure.Repositories;
using System.Reflection;

namespace PanstwaMiasta.Infrastructure.Modules
{
    public class SqlModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(SqlModule)
                    .GetTypeInfo()
                    .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<ISqlRepository>())
                   .InstancePerLifetimeScope();
        }
    }
}
