using System;
using System.Collections.Generic;
using System.Linq;

namespace PanstwaMiasta.Core.Models
{
    public class Room
    {
        private ISet<Player> _players = new HashSet<Player>();

        public Guid Id { get; protected set; }
        public bool IsActive => _players.Any();

        public IEnumerable<Player> Players
        {
            get { return _players; }
            set { _players = new HashSet<Player>(value); }
        }

        public Room(Guid id)
        {
            Id = id;
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void DeletePlayer(Player player)
        {
            _players.Remove(player);
        }
    }
}
