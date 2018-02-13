using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TD1_Xamarin.Models;

namespace TD1_Xamarin.Services
{
    class DeviseService
    {
        private const string API_ENDPOINT = "http://localhost:52071/api/Devise";

        private readonly HttpClient client = new HttpClient();

        private static DeviseService instance;
        public async Task<List<Devise>> getAllDevisesAsync()
        {
            List<Devise> model = null;

            var task = await client.GetAsync(DeviseService.API_ENDPOINT);
            var jsonString = await task.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<List<Devise>>(jsonString);

            return model;
        }

        public static DeviseService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DeviseService();
                }
                return instance;
            }
        }
    }
}
