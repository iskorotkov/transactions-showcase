using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class GovernmentType
    {
        public GovernmentType()
        {
            Empires = new HashSet<Empire>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Empire> Empires { get; set; }
    }
}
