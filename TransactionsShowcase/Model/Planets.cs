using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Planets
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public int Habitability { get; set; }
        public long Population { get; set; }
        public int? Approval { get; set; }
        public int? EmpireId { get; set; }
        public int StarId { get; set; }
        public string Name { get; set; }

        public virtual Empires Empire { get; set; }
        public virtual Stars Star { get; set; }
        public virtual Shipyards Shipyards { get; set; }
    }
}
