using System;
using System.Collections.Generic;

namespace MediaPlanner.Database.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            CampaignDetail = new HashSet<CampaignDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ChannelId { get; set; }

        public Channel Channel { get; set; }
        public ICollection<CampaignDetail> CampaignDetail { get; set; }
    }
}
