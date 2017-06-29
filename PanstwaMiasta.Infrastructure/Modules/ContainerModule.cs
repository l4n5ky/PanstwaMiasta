using Autofac;
using Microsoft.Extensions.Configuration;

namespace PanstwaMiasta.Infrastructure.Modules
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfigurationRoot _configuration;

        public ContainerModule(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
