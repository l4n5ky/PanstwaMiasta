using System;
using System.Collections.Generic;

namespace PanstwaMiasta.Core.Models
{
    // 1
    public class Player
    {
        private ISet<Answer> _answers = new HashSet<Answer>();

        public Guid Id { get; protected set; }
        public string Nickname { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public IEnumerable<Answer> Answers
        {
            get { return _answers; }
            set { _answers = new HashSet<Answer>(value); }
        }

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
                throw new Exception("Nickname can not be empty.");
            }
            if (nickname.Length > 20 || nickname.Length < 6)
            {
                throw new Exception("Nickname must contain between 6 and 20 characters.");
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
                throw new Exception("Password can not be empty.");
            }
            if (password.Length > 100 || password.Length < 6)
            {
                throw new Exception("Password must contain between 6 and 20 characters.");
            }
            if (Password == password)
            {
                return;
            }
            if (string.IsNullOrEmpty(salt))
            {
                throw new Exception("Salt can not be empty.");
            }

            Password = password;
            Salt = salt;
        }

    }
}
