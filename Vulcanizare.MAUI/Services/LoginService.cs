using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI.Services
{
    internal class LoginService : ILoginRepository
    {
        public async Task<UserInfo> Login(string username, string password)
        {
            {
                var userInfo = new List<UserInfo>();
                var client = new HttpClient();

                string url = "https://192.168.108.1:45455/api/UserInfoes/LoginUser/"+username+"/"+password;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    userInfo = JsonConvert.DeserializeObject<List<UserInfo>>(content);

                    return await Task.FromResult(userInfo.FirstOrDefault());
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
