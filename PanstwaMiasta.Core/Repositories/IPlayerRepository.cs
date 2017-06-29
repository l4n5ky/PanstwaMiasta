using PanstwaMiasta.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Core.Repositories
{
    // 4
    public interface IPlayerRepository : IRepository
    {
        Task<Player> GetAsync(Guid playerId);
        Task<IEnumerable<Player>> GetAllAsync();
        Task AddAsync(Player player);
    }
}
