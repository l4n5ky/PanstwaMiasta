﻿using Autofac;
using PanstwaMiasta.Infrastructure.Commands;
using System.Reflection;

namespace PanstwaMiasta.Infrastructure.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>))
                   .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                   .As<ICommandDispatcher>()
                   .InstancePerLifetimeScope();
        }
    }
}
