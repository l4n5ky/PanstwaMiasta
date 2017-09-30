using System;
using System.Collections.Generic;
using System.Linq;

namespace PanstwaMiasta.Core.Models
{
    public class Room
    {
        private IList<Player> _players = new List<Player>();

        public int Number { get; set; }
        public bool IsActive { get; set; }
        public Guid RoomAdminId { get; set; }

        public Guid Id { get; protected set; }
        public IEnumerable<Player> Players
        {
            get { return _players; }
            set { _players = new List<Player>(value); }
        }

        public Room(Guid id, Guid adminId)
        {
            Id = id;
            RoomAdminId = adminId;
            IsActive = true;
        }

        public void AddPlayer(Player player)
        {
            var member = _players.FirstOrDefault(x => x.Id == player.Id);

            if (member != null)
                return;

            _players.Add(player);
        }

        public void DeletePlayer(Player player)
        {
            var member = _players.FirstOrDefault(x => x.Id == player.Id);

            if (member == null)
                return;

            _players.Remove(member);
        }
    }
}
