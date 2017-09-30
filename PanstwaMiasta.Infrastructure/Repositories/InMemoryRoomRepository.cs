using PanstwaMiasta.Core.Models;
using PanstwaMiasta.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Repositories
{
    public class InMemoryRoomRepository : IRoomRepository
    {
        private static readonly ISet<Room> _rooms = new HashSet<Room>();
       
        public async Task<Room> GetAsync(Guid roomId)
            => await Task.FromResult(_rooms.SingleOrDefault(x => x.Id == roomId));

        public async Task<IEnumerable<Room>> GetAllAsync()
            => await Task.FromResult(_rooms);
        
        public async Task AddAsync(Room room)
        {
            room.Number = _rooms.Count + 1;
            _rooms.Add(room);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Room room)
        {
            _rooms.Remove(room);
            await Task.CompletedTask;
        }
    }
}
