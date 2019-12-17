using MediaPlanner.Database;
using MediaPlanner.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaPlanner.API.Controllers
{
    [Route("api/[controller]")]
    public class CampaignController : Controller
    {
        private readonly DataStore _dataStore = null;
        public CampaignController(DataStore dataStore) => _dataStore = dataStore;

        // GET api/campaign
        [HttpGet]
        public IActionResult GetMasterData()
        {
            try
            {
                Dictionary<string, SelectList> data = new Dictionary<string, SelectList>();
                data.Add("CLIENT", new SelectList((IList<Client>)_dataStore.GetMasterDataByKey("CLIENT"), "Id", "Name"));
                data.Add("COUNTRY", new SelectList((IList<Country>)_dataStore.GetMasterDataByKey("COUNTRY"), "Id", "Name"));
                data.Add("SUPPLIER", new SelectList((IList<Supplier>)_dataStore.GetMasterDataByKey("SUPPLIER"), "Id", "Name"));
                data.Add("CHANNEL", new SelectList((IList<Channel>)_dataStore.GetMasterDataByKey("CHANNEL"), "Id", "Name"));

                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<bool> Post([FromBody]CampaignModel model)
        {
            try
            {
                if (model != null)
                {
                    Campaign campaign = new Campaign()
                    {
                        Title = model.Title,
                        StartDate = Convert.ToDateTime(model.StartDate).ToUniversalTime(),
                        EndDate = Convert.ToDateTime(model.EndDate).ToUniversalTime(),
                        ClientId = model.ClientId,
                        CountryId = model.CountryId,
                        Budget = model.Budget,
                        CampaignDetail = new List<CampaignDetail>()
                    };

                    foreach (var campaignDetail in model.CampaignDetails)
                    {
                        campaign.CampaignDetail.Add(new CampaignDetail()
                        {
                            CampaignId = model.Id,
                            SupplierId = campaignDetail.SupplierId,
                            StartDate = Convert.ToDateTime(campaignDetail.StartDate).ToUniversalTime(),
                            EndDate = Convert.ToDateTime(campaignDetail.EndDate).ToUniversalTime(),
                            Budget = campaignDetail.Budget,
                        });
                    }

                    return await _dataStore.Save(campaign);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
