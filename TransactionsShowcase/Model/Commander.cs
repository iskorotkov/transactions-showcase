using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Commander
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Skill { get; set; }
        public int RankId { get; set; }

        public virtual Rank Rank { get; set; }
        public virtual Fleet Fleets { get; set; }
    }
}
