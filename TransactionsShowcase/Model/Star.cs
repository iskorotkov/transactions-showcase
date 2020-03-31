using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Star
    {
        public Star()
        {
            Planets = new HashSet<Planet>();
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public int Size { get; set; }
        public long Age { get; set; }
        public string Name { get; set; }

        public virtual StarType Type { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
    }
}
