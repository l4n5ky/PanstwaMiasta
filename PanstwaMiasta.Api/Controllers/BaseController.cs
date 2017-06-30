using Microsoft.AspNetCore.Mvc;
using PanstwaMiasta.Infrastructure.Commands;
using System.Threading.Tasks;

namespace PanstwaMiasta.Api.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        private readonly ICommandDispatcher CommandDispatcher;

        protected BaseController(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            await CommandDispatcher.DispatchAsync(command);
        }
    }
}
