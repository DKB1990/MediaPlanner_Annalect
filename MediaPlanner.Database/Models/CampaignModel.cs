using System;
using System.Collections.Generic;

namespace MediaPlanner.Database.Models
{
    public class CampaignModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<Country> Countries { get; set; }
        public IList<Client> Clients { get; set; }
        public IList<Supplier> Suppliers { get; set; }
        public IList<Channel> Channels { get; set; }
        public IList<int> ChannelIds { get; set; }
        public int CountryId { get; set; }
        public int ClientId { get; set; }
        public Decimal Budget { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IList<CampaignDetailModel> CampaignDetails { get; set; }
        public CampaignModel()
        {
            StartDate = DateTime.UtcNow.ToShortDateString();
            EndDate = DateTime.UtcNow.ToShortDateString();
        }
    }

    public class CampaignDetailModel
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int SupplierId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Decimal Budget { get; set; }
        public CampaignDetailModel()
        {
            StartDate = DateTime.UtcNow.ToShortDateString();
            EndDate = DateTime.UtcNow.ToShortDateString();
        }
    }
}
