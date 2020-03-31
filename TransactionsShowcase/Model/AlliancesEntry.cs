using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class AlliancesEntry
    {
        public int Id { get; set; }
        public int AllianceId { get; set; }
        public int EmpireId { get; set; }
        public int EntryYear { get; set; }

        public virtual Alliance Alliance { get; set; }
        public virtual Empire Empire { get; set; }
    }
}
