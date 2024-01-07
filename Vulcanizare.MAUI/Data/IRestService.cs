using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI.Data
{
    public interface IRestService
    {
        Task<List<Tire>> RefreshDataAsync();
        Task SaveTireAsync(Tire item, bool isNewItem);
        Task DeleteTireAsync(int id);
    }

}
