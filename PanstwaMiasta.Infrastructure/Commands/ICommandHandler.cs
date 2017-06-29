using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command); 
    }
}
