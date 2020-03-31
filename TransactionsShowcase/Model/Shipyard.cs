using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Shipyard
    {
        public Shipyard()
        {
            Spaceships = new HashSet<Spaceship>();
        }

        public int Id { get; set; }
        public int Pipelines { get; set; }
        public int Staff { get; set; }
        public int PlanetId { get; set; }
        public string Name { get; set; }

        public virtual Planet Planet { get; set; }
        public virtual ICollection<Spaceship> Spaceships { get; set; }
    }
}
