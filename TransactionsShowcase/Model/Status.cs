using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Status
    {
        public Status()
        {
            Fleets = new HashSet<Fleet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Fleet> Fleets { get; set; }
    }
}
