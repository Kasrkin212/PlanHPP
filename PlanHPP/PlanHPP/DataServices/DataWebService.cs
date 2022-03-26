using Newtonsoft.Json;
using PlanHPP.Models;
using PlanHPP.Models.Lists;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlanHPP.DataServices
{
    public class DataWebService : IDataWebService
    {
        HttpClient client;
        public List<Motor> Motors { get; private set; }

        public DataWebService()
        {
            client = new HttpClient();
        }
        public async Task<List<Motor>> GetDataAsync()
        {
            Motors = new List<Motor>();
            Uri uri = new Uri(string.Format(Constants.DataRestUrl, string.Empty));
            
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Motors = JsonConvert.DeserializeObject<List<Motor>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Motors;
            //return MotorList.motors;
        }
        public async Task ChangeMotor(Motor SelectedMotor)
        {
            Uri uri = new Uri(string.Format(Constants.DataRestUrl, string.Empty));

            try
            {
                string json = JsonConvert.SerializeObject(SelectedMotor);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PutAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
