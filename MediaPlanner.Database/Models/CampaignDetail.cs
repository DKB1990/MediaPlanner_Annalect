using System;
using System.Collections.Generic;

namespace MediaPlanner.Database.Models
{
    public partial class CampaignDetail
    {
        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public int? SupplierId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Budget { get; set; }

        public Campaign Campaign { get; set; }
        public Supplier Supplier { get; set; }
    }
}
