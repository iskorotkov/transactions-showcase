using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Planet
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public int Habitability { get; set; }
        public long Population { get; set; }
        public int? Approval { get; set; }
        public int? EmpireId { get; set; }
        public int StarId { get; set; }
        public string Name { get; set; }

        public virtual Empire Empire { get; set; }
        public virtual Star Star { get; set; }
        public virtual Shipyard Shipyards { get; set; }
    }
}
