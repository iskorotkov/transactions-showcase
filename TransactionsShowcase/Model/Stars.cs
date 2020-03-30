﻿using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Stars
    {
        public Stars()
        {
            Planets = new HashSet<Planets>();
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public int Size { get; set; }
        public long Age { get; set; }
        public string Name { get; set; }

        public virtual StarTypes Type { get; set; }
        public virtual ICollection<Planets> Planets { get; set; }
    }
}
