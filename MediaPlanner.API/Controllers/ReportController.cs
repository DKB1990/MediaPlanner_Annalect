using MediaPlanner.Database;
using MediaPlanner.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaPlanner.API.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private readonly DataStore _dataStore = null;
        public ReportController(DataStore dataStore) => _dataStore = dataStore;


        [HttpGet]
        public async Task<IActionResult> GetCampaigns()
        {
            try
            {
                IEnumerable<Campaign> campaigns = await _dataStore.GetAllAsync();
                return Json(campaigns);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}