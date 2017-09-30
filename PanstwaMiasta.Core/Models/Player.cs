using PanstwaMiasta.Core.Exceptions;
using System;

namespace PanstwaMiasta.Core.Models
{
    public class Player
    {
        public Guid Id { get; protected set; }
        public string DeviceId { get; protected set; }
        public string Nickname { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Player() { } // for entity framework

        public Player(Guid id, string nickname, string password, string salt)
        {
            Id = id;
            SetNickname(nickname);
            SetPassword(password, salt);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetNickname(string nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
            {
                throw new DomainException(ErrorCodes.InvalidUsername, "Nickname can not be empty.");
            }
            if (nickname.Length > 20 || nickname.Length < 6)
            {
                throw new DomainException(ErrorCodes.InvalidUsername, "Nickname must contain between 6 and 20 characters.");
            }
            if (Nickname == nickname)
            {
                return;
            }

            Nickname = nickname;
        }

        public void SetPassword(string password, string salt)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new DomainException(ErrorCodes.InvalidPassword, "Password can not be empty.");
            }
            if (password.Length > 100 || password.Length < 6)
            {
                throw new DomainException(ErrorCodes.InvalidPassword, "Password must contain between 6 and 20 characters.");
            }
            if (Password == password)
            {
                return;
            }
            if (string.IsNullOrEmpty(salt))
            {
                throw new DomainException(ErrorCodes.InvalidPassword, "Salt can not be empty.");
            }

            Password = password;
            Salt = salt;
        }

        public void SetDeviceId(string deviceId)
        {
            DeviceId = deviceId;
        }
    }
}
