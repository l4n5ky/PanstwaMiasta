using Autofac;
using Microsoft.Extensions.Configuration;
using PanstwaMiasta.Infrastructure.Extensions;
using PanstwaMiasta.Infrastructure.Mongo;
using PanstwaMiasta.Infrastructure.Settings;

namespace PanstwaMiasta.Infrastructure.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
                   .SingleInstance();
        }
    }
}
