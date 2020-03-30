using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Ranks
    {
        public Ranks()
        {
            Commanders = new HashSet<Commanders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Commanders> Commanders { get; set; }
    }
}
