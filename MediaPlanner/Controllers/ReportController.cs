using MediaPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MediaPlanner.Controllers
{
    public class ReportController : Controller
    {
        private readonly string _apiUrl;
        private readonly IConfiguration _configuration;
        public ReportController(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiUrl = _configuration["ApiUrl"];
        }

        public IActionResult Index()
        {
            IEnumerable<CampaignModel> model = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                HttpResponseMessage response = client.GetAsync("report").Result;
                if (response.IsSuccessStatusCode)
                {

                }
            }

            return View(model);
        }
    }
}
