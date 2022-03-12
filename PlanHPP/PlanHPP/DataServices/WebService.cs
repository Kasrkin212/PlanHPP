﻿using Newtonsoft.Json;
using PlanHPP.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlanHPP.DataServices
{
    public class WebService : IWebService
    {
        HttpClient client;
        public List<Motor> Motors { get; private set; }

        public WebService()
        {
            client = new HttpClient();
        }
        public async Task<List<Motor>> GetDataAsync()
        {
            Motors = new List<Motor>();
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            HttpResponseMessage response = await client.GetAsync(uri);
            string content = await response.Content.ReadAsStringAsync();
            Motors = JsonConvert.DeserializeObject<List<Motor>>(content);
            return Motors;
        }
    }
}