using System;

namespace PanstwaMiasta.Infrastructure.Commands
{
    public class AuthenticatedCommandBase : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
    }
}
