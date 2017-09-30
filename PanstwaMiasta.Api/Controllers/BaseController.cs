using Microsoft.AspNetCore.Mvc;
using PanstwaMiasta.Infrastructure.Commands;
using System;
using System.Threading.Tasks;

namespace PanstwaMiasta.Api.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        private readonly ICommandDispatcher CommandDispatcher;
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) : Guid.Empty;

        protected BaseController(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command is IAuthenticatedCommand authenticatedCommand)
            {
                authenticatedCommand.Id = UserId;
            }

            await CommandDispatcher.DispatchAsync(command);
        }
    }
}
