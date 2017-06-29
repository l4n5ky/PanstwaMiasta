using AutoMapper;
using PanstwaMiasta.Core.Models;
using PanstwaMiasta.Core.Repositories;
using PanstwaMiasta.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper; // automapper library

        public PlayerService(IPlayerRepository playerRepository,
            IEncrypter encrypter, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerDto>> BrowseAsync()
        {
            var players = await _playerRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Player>, IEnumerable<PlayerDto>>(players);
        }

        public async Task<PlayerDto> GetAsync(Guid id)
        {
            var player = await _playerRepository.GetAsync(id);

            return _mapper.Map<Player, PlayerDto>(player);
        }

        public async Task<PlayerDto> GetAsync(string nickname)
        {
            var player = await _playerRepository.GetAsync(nickname);

            return _mapper.Map<Player, PlayerDto>(player);
        }

        public async Task RegisterAsync(Guid id, string nickname, string password)
        {
            var player = await _playerRepository.GetAsync(nickname);
            if (player != null)
            {
                throw new Exception("User with this nickname already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);

            player = new Player(id, nickname, password, salt);
            await _playerRepository.AddAsync(player);
        }

        public async Task LoginAsync(string nickname, string password)
        {
            var player = await _playerRepository.GetAsync(nickname);
            if (player == null)
            {
                throw new Exception("Invalid credentials.");
            }

            var hash = _encrypter.GetHash(password, player.Salt);
            if (player.Password == hash)
            {
                return;
            }

            throw new Exception("Invalid credentials.");
        }
    }
}
