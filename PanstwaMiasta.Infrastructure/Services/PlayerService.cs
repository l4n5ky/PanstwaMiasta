using AutoMapper;
using PanstwaMiasta.Core.Models;
using PanstwaMiasta.Core.Repositories;
using PanstwaMiasta.Infrastructure.DTO;
using PanstwaMiasta.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

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
                throw new ServiceException(ErrorCodes.UserExist,"User with this nickname already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);

            player = new Player(id, nickname, hash, salt);
            await _playerRepository.AddAsync(player);
        }

        public async Task LoginAsync(string nickname, string password, string deviceId)
        {
            var player = await _playerRepository.GetAsync(nickname);
            if (player == null)
            {
                throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials.");
            }

            if (player.DeviceId != deviceId && deviceId != null)
            {
                player.SetDeviceId(deviceId);
                await _playerRepository.UpdateAsync(player);
            }

            var hash = _encrypter.GetHash(password, player.Salt);
            if (player.Password == hash)
            {
                return;
            }

            throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials.");
        }

        public async Task UpdateAsync(Guid id, string password, string newPassword)
        {
            var player = await _playerRepository.GetAsync(id);
            if (player == null)
            {
                throw new ServiceException(ErrorCodes.UserNotFound, $"Player with id : {id} does not exists.");
            }
            if (password == newPassword)
            {
                return;
            }

            var hash = _encrypter.GetHash(password, player.Salt);
            if (player.Password != hash)
            {
                throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials.");
            }

            var newSalt = _encrypter.GetSalt(newPassword);
            var newHash = _encrypter.GetHash(newPassword, newSalt);
            player.SetPassword(newHash, newSalt);
            await _playerRepository.UpdateAsync(player);
        }
    }
}
