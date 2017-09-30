using Microsoft.EntityFrameworkCore;
using PanstwaMiasta.Core.Models;
using PanstwaMiasta.Core.Repositories;
using PanstwaMiasta.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository, ISqlRepository
    {
        private readonly PMContext _context;

        public PlayerRepository(PMContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Player player)
        {
            await _context.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
            => await _context.Players.ToListAsync();

        public async Task<Player> GetAsync(Guid id)
            => await _context.Players.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Player> GetAsync(string nickname)
            => await _context.Players.SingleOrDefaultAsync(x => x.Nickname == nickname);

        public async Task UpdateAsync(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }
    }
}
