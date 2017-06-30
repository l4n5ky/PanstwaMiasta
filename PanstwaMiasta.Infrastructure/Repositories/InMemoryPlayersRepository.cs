using PanstwaMiasta.Core.Models;
using PanstwaMiasta.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Repositories
{
    public class InMemoryPlayersRepository : IPlayerRepository
    {
        private static readonly ISet<Player> _players = new HashSet<Player>()
        {
            new Player(Guid.NewGuid(), "first111", "secret5", "salt"),
            new Player(Guid.NewGuid(), "second", "secret6", "salt2")
        };

        public async Task AddAsync(Player player)
        {
            _players.Add(player);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
            => await Task.FromResult(_players);

        public async Task<Player> GetAsync(Guid id)
            => await Task.FromResult(_players.SingleOrDefault(x => x.Id == id));

        public async Task<Player> GetAsync(string nickname)
            => await Task.FromResult(_players.SingleOrDefault(x => x.Nickname == nickname));
    }
}
