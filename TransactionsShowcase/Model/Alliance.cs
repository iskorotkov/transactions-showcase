using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Alliance
    {
        public Alliance()
        {
            AlliancesEntries = new HashSet<AlliancesEntry>();
        }

        public int Id { get; set; }
        public int Power { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AlliancesEntry> AlliancesEntries { get; set; }
    }
}
