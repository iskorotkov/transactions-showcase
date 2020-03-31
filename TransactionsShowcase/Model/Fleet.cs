using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Fleet
    {
        public Fleet()
        {
            Spaceships = new HashSet<Spaceship>();
        }

        public int Id { get; set; }
        public int StatusId { get; set; }
        public int CommanderId { get; set; }
        public string Name { get; set; }

        public virtual Commander Commander { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Spaceship> Spaceships { get; set; }
    }
}
