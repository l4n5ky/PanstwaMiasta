using PanstwaMiasta.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Core.Repositories
{
    public interface IPlayerRepository : IRepository
    {
        Task<IEnumerable<Player>> GetAllAsync();
        Task AddAsync(Player player);
        Task<Player> GetAsync(Guid id);
        Task<Player> GetAsync(string nickname);
        Task UpdateAsync(Player player);
    }
}
