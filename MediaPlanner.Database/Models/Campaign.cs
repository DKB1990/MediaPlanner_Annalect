using System;
using System.Collections.Generic;

namespace MediaPlanner.Database.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            CampaignDetail = new HashSet<CampaignDetail>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Budget { get; set; }
        public int? CountryId { get; set; }
        public int? ClientId { get; set; }

        public Client Client { get; set; }
        public Country Country { get; set; }
        public ICollection<CampaignDetail> CampaignDetail { get; set; }
    }
}
