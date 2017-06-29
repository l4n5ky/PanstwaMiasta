using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Players;
using System;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Handlers.Players
{
    public class LoginHandler : ICommandHandler<Login>
    {
        public Task HandleAsync(Login command)
        {
            throw new NotImplementedException();
        }
    }
}
