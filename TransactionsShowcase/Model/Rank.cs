using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Rank
    {
        public Rank()
        {
            Commanders = new HashSet<Commander>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Commander> Commanders { get; set; }
    }
}
