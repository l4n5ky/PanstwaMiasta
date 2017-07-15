using AutoMapper;
using PanstwaMiasta.Core.Models;
using PanstwaMiasta.Core.Repositories;
using PanstwaMiasta.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Services
{
    public class RoomService : IRoomService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository,
            IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<RoomDto> GetAsync(Guid roomId)
        {
            var room = await _roomRepository.GetAsync(roomId);

            return _mapper.Map<Room, RoomDto>(room);
        }

        public async Task<IEnumerable<RoomDto>> BrowseAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            
            return _mapper.Map<IEnumerable<Room>, IEnumerable<RoomDto>>(rooms);
        }

        public async Task AddMemberAsync(Guid playerId, Guid roomId)
        {
            var player = await _playerRepository.GetAsync(playerId);
            var room = await _roomRepository.GetAsync(roomId);
            room.AddPlayer(player);
        }

        public async Task RemoveMemberAsync(Guid playerId, Guid roomId)
        {
            var player = await _playerRepository.GetAsync(playerId);
            var room = await _roomRepository.GetAsync(roomId);
            room.DeletePlayer(player);
        }
    }
}
