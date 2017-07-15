using PanstwaMiasta.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Core.Repositories
{
    public interface IRoomRepository : IRepository
    {
        Task<Room> GetAsync(Guid roomId);
        Task<IEnumerable<Room>> GetAllAsync();
        Task AddAsync(Room room);
        Task DeleteAsync(Room room);
    }
}
