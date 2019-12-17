using System;
using System.Collections.Generic;

namespace MediaPlanner.Database.Models
{
    public partial class Channel
    {
        public Channel()
        {
            Supplier = new HashSet<Supplier>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Supplier> Supplier { get; set; }
    }
}
