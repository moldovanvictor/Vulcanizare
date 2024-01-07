using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        //se va modifica ulterior cu ip-ul si portul corespunzator
        string RestUrl = "https://192.168.108.1:45455/api/Tires/{0}";
        public List<Tire> Items { get; private set; }
        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);
        }
        public async Task<List<Tire>> RefreshDataAsync()
        {
            Items = new List<Tire>();
            Uri uri = new Uri(string.Format(RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Tire>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Items;
        }
        public async Task SaveTireAsync(Tire item, bool isNewItem = true)
        {
            Uri uri = new Uri(string.Format(RestUrl, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8,
               "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"\tTodoItem successfully saved.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
        public async Task DeleteTireAsync(int id)
        {
            Uri uri = new Uri(string.Format(RestUrl, id));
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"\tTodoItem successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
