using PanstwaMiasta.Core.Models;
using PanstwaMiasta.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Repositories
{
    public class InMemoryRoomsRepository : IRoomRepository
    {
        private readonly IPlayerRepository _playerRepository;
        private static readonly ISet<Room> _rooms = new HashSet<Room>();

        public InMemoryRoomsRepository(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task CreateAsync()
        {
            var room = new Room(Guid.NewGuid());
            _rooms.Add(room);
        }

        public async Task<Room> GetAsync(Guid roomId)
            => await Task.FromResult(_rooms.SingleOrDefault(x => x.Id == roomId));

        public async Task<IEnumerable<Room>> GetAllAsync()
            => await Task.FromResult(_rooms);

        public async Task AddMemberAsync(Player player)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveMemberAsync(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
