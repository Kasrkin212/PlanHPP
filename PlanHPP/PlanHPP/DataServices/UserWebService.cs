using Newtonsoft.Json;
using PlanHPP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlanHPP.DataServices
{
    public class UserWebService : IUserWebService
    {
        
        HttpClient client;
        public UserWebService()
        {
            client = new HttpClient();
        }
        public async Task<T> LoginUserAsync<T>(string url, T user)
        {
            T RecivedUser = default(T);
            Uri uri = new Uri(string.Format(url, string.Empty));

            try
            {
                string json = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                string Getcontent = await response.Content.ReadAsStringAsync();
                RecivedUser = JsonConvert.DeserializeObject<T>(Getcontent);
                OnWork(Getcontent);
            }
            catch (Exception ex)
            {
                OnError(ex.ToString());
            }
            return RecivedUser;

        }
        private async Task<T> HttpPostAsync<T>(string url, T user)
        {
            
            T result = default(T); 

            try
            {
                string json = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = await client.PostAsync(new Uri(url), content);

                if (response.IsSuccessStatusCode)
                {
                    
                }
                else
                {
                    throw new Exception(((int)response.StatusCode).ToString() + " - " + response.ReasonPhrase);
                }
                return result;
            }
            catch (Exception ex)
            {
                OnError(ex.ToString());
                return result;
            }
        }
        private void OnError(string error)
        {
            Console.WriteLine("[WEBSERVICE ERRORrrrrrr] " + error);
        }
        private void OnWork(string work)
        {
            Console.WriteLine("[WEBSERVICE Work] " + work);
        }

        public async Task SendUser(User user)
        {
            Uri uri = new Uri(string.Format(Constants.UserRegistrationRestUrl, string.Empty));

            try
            {
                string json = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
