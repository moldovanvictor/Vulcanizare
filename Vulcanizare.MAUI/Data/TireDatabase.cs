using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI.Data
{
    public class TireDatabase
    {
        IRestService restService;
        public TireDatabase(IRestService service)
        {
            restService = service;
        }
        public Task<List<Tire>> GetTiresAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTireAsync(Tire item, bool isNewItem = true)
        {
            return restService.SaveTireAsync(item, isNewItem);
        }
        public Task DeleteTireAsync(Tire item)
        {
            return restService.DeleteTireAsync(item.Id);
        }

    }
}
