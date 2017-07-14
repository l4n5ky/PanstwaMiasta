using PanstwaMiasta.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using PanstwaMiasta.Core.Models;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace PanstwaMiasta.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public PlayerRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Player player)
            => await Players.InsertOneAsync(player);

        public async Task<Player> GetAsync(Guid id)
            => await Players.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Player> GetAsync(string nickname)
            => await Players.AsQueryable().FirstOrDefaultAsync(x => x.Nickname == nickname);

        public async Task<IEnumerable<Player>> GetAllAsync()
            => await Players.AsQueryable().ToListAsync();

        public async Task UpdateAsync(Player player)
            => await Players.ReplaceOneAsync(x => x.Id == player.Id, player);

        private IMongoCollection<Player> Players => _database.GetCollection<Player>("Players");
    }
}
