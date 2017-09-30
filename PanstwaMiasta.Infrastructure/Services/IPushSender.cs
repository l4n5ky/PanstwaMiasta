using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Services
{
    public interface IPushSender
    {
        Task SendToAllRoomMembersAsync(string[] ids, string message);
    }
}
