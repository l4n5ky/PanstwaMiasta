using PanstwaMiasta.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Core.Repositories
{
    public interface IRoomRepository : IRepository
    {
        Task CreateAsync();
        Task<Room> GetAsync(Guid roomId);
        Task<IEnumerable<Room>> GetAllAsync();
        Task AddMemberAsync(Player player);
        Task RemoveMemberAsync(Player player);
    }
}
