using PanstwaMiasta.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Services
{
    public interface IRoomService : IService
    {
        Task<RoomDto> GetAsync(Guid roomId);
        Task<IEnumerable<RoomDto>> BrowseAsync();
        Task CreateAsync(Guid playerId);
        Task DeleteAsync(Guid roomId);
        Task AddMemberAsync(Guid playerId, Guid roomId);
        Task RemoveMemberAsync(Guid playerId, Guid roomId);
    }
}
