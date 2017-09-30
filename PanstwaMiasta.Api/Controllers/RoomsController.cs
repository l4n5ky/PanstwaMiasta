using Microsoft.AspNetCore.Mvc;
using PanstwaMiasta.Core.Models;
using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Rooms;
using PanstwaMiasta.Infrastructure.DTO;
using PanstwaMiasta.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Api.Controllers
{
    public class RoomsController : BaseController
    {
        private readonly IRoomService _roomService;
        private readonly IPlayerService _playerService;

        public RoomsController(ICommandDispatcher commandDispatcher,
            IRoomService roomService, IPlayerService playerService) : base(commandDispatcher)
        {
            _roomService = roomService;
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomDto>> Get()
        {
            var rooms = await _roomService.BrowseAsync();

            return rooms;
        }

        [HttpGet("{id}")]
        public async Task<RoomDto> Get(Guid id)
        {
            var room = await _roomService.GetAsync(id);

            return room;
        }

        [HttpPost("create")]
        public async Task Post([FromBody]CreateRoom command)
        {
            await DispatchAsync(command);
        }

        [HttpDelete("delete")]
        public async Task Delete([FromBody]DeleteRoom command)
        {
            await DispatchAsync(command);
        }
        
        [HttpPost("join")]
        public async Task Post([FromBody]JoinRoom command)
        {
            await DispatchAsync(command);
        }

        [HttpPost("leave")]
        public async Task Post([FromBody]LeaveRoom command)
        {
            await DispatchAsync(command);
        }

        [HttpPost("start")]
        public async Task Post([FromBody]StartGame command)
        {
            await DispatchAsync(command);
            //Redirect("{api}/game/start");
        }
    }
}