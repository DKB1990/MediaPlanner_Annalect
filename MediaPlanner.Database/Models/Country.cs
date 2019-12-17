using System;
using System.Collections.Generic;

namespace MediaPlanner.Database.Models
{
    public partial class Country
    {
        public Country()
        {
            Campaign = new HashSet<Campaign>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<Campaign> Campaign { get; set; }
    }
}
