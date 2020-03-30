﻿using System;
using System.Collections.Generic;

namespace TransactionsShowcase
{
    public partial class Statuses
    {
        public Statuses()
        {
            Fleets = new HashSet<Fleets>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Fleets> Fleets { get; set; }
    }
}
