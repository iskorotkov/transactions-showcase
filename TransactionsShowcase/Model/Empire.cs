using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Empire
    {
        public Empire()
        {
            AlliancesEntries = new HashSet<AlliancesEntry>();
            Planets = new HashSet<Planet>();
        }

        public int Id { get; set; }
        public int GovernmentTypeId { get; set; }
        public string Ruler { get; set; }
        public int Power { get; set; }
        public string Name { get; set; }

        public virtual GovernmentType GovernmentType { get; set; }
        public virtual ICollection<AlliancesEntry> AlliancesEntries { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }

        public override string ToString() => Name;
    }
}
