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
        private readonly IPushSender _pushSender;

        public RoomService(IRoomRepository roomRepository,
                           IPlayerRepository playerRepository,
                           IMapper mapper, IPushSender pushSender)
        {
            _playerRepository = playerRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
            _pushSender = pushSender;
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

        public async Task CreateAsync(Guid playerId)
        {
            Room room = new Room(Guid.NewGuid(), playerId);
            await _roomRepository.AddAsync(room);
            await AddMemberAsync(playerId, room.Id);
        }

        public async Task DeleteAsync(Guid roomId)
        {
            var room = await _roomRepository.GetAsync(roomId);
            await _roomRepository.DeleteAsync(room);
        }

        public async Task AddMemberAsync(Guid playerId, Guid roomId)
        {
            var player = await _playerRepository.GetAsync(playerId);
            var room = await _roomRepository.GetAsync(roomId);
            room.AddPlayer(player);
            await _pushSender.SendToAllRoomMembersAsync(GetReceiversIds(room), "refresh");
        }

        public async Task RemoveMemberAsync(Guid playerId, Guid roomId)
        {
            var player = await _playerRepository.GetAsync(playerId);
            var room = await _roomRepository.GetAsync(roomId);

            if (room.RoomAdminId == player.Id)
            {
                await DeleteAsync(roomId);
            }
            else
            {
                room.DeletePlayer(player);
            }
            await _pushSender.SendToAllRoomMembersAsync(GetReceiversIds(room), "refresh");
        }

        private string[] GetReceiversIds(Room room)
        {
            int i = 0;
            foreach (var member in room.Players)
            {
                i++;
            }

            string[] receiversIds = new string[i];
            i = 0;
            foreach (var member in room.Players)
            {
                receiversIds[i] = member.DeviceId;
                i++;
            }

            return receiversIds;
        }
    }
}