using System;

namespace PanstwaMiasta.Infrastructure.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid Id { get; set; }
    }
}
