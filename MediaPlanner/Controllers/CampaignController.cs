using MediaPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using System.Text;

namespace MediaPlanner.Controllers
{
    public class CampaignController : Controller
    {
        private readonly string _apiUrl;
        private readonly IConfiguration _configuration;
        public CampaignController(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiUrl = _configuration["ApiUrl"];
        }

        public IActionResult Index()
        {
            CampaignModel model = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                HttpResponseMessage response = client.GetAsync("campaign").Result;
                if (response.IsSuccessStatusCode)
                {
                    model = model ?? new CampaignModel();
                    var selectLists = JsonConvert.DeserializeObject<Dictionary<string, SelectList>>(response.Content.ReadAsStringAsync().Result);

                    model.Clients = new List<SelectListItem>(selectLists["CLIENT"].Items.Cast<SelectListItem>());
                    model.Suppliers = new List<SelectListItem>(selectLists["SUPPLIER"].Items.Cast<SelectListItem>());
                    model.Countries = new List<SelectListItem>(selectLists["COUNTRY"].Items.Cast<SelectListItem>());
                    model.Channels = new List<SelectListItem>(selectLists["CHANNEL"].Items.Cast<SelectListItem>());
                }
            }

            return View(model ?? new CampaignModel());
        }

        [HttpPost]
        public IActionResult Save(CampaignModel model)
        {
            try
            {
                if (model != null && !string.IsNullOrWhiteSpace(model.Title))
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(_apiUrl);
                        var postTask = client.PostAsync("campaign", new StringContent(JsonConvert.SerializeObject(model),
                            Encoding.UTF8,
                            "application/json"));
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index", "Report");
                        }
                    }
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
