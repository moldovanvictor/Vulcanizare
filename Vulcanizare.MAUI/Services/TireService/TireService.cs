using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI.Services.TireService
{
    public class TireService : ITireRepository
    {
        //public SQLiteAsyncConnection _database;
        public static readonly string baseUrl = "https://192.168.108.1:45455/api";

        public TireService(string dbPath)
        {
            //_database = new SQLiteAsyncConnection(dbPath);
            //_database.CreateTableAsync<Tire>().Wait();
        }

        public async Task<bool> AddUpdateTireAsync(Tire tire)
        {
            //if(tire.Id > 0)
            // {
            //     await _database.UpdateAsync(tire);
            // }
            // else
            // {
            //     await _database.InsertAsync(tire);
            // }
            //return await Task.FromResult(true);

            string json = JsonConvert.SerializeObject(tire);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            if (tire.Id == 0)
            {
                string url = baseUrl + "/Tires/AddTire"+tire.Id;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.PostAsync("",content);

                if(responseMessage.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            else
            {
                string url = baseUrl + "/Tires/UpdateTire"+tire.Id;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.PutAsync("", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteTireAsync(int Id)
        {
            //await _database.DeleteAsync<Tire>(id);
            //return await Task.FromResult(true);

            HttpClient client = new HttpClient();
            string url = baseUrl + "/Tires/DeleteTire" + Id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.DeleteAsync("");

            if (responseMessage.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Tire> GetTireAsync(int Id)
        {
            //return await _database.Table<Tire>().Where(p => p.Id == id).FirstOrDefaultAsync();
        
            var tire = new Tire();
            HttpClient client = new HttpClient();
            string url = baseUrl + "/Tires/" + Id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync("");

            if (responseMessage.IsSuccessStatusCode)
            {
                tire = await responseMessage.Content.ReadFromJsonAsync<Tire>();
            }

            return await Task.FromResult(tire);
        }

        public async Task<IEnumerable<Tire>> GetTireAsync()
        {
           //return await Task.FromResult(await _database.Table<Tire>().ToListAsync());
            
            var tireList = new List<Tire>();
            HttpClient client = new HttpClient();
            string url = baseUrl + "/Tires";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync("");

            if (responseMessage.IsSuccessStatusCode)
            {
                tireList = await responseMessage.Content.ReadFromJsonAsync<List<Tire>>();
            }

            return await Task.FromResult(tireList);
        }
    }
}
