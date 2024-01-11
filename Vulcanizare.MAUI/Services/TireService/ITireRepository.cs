using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI.Services.TireService
{
    public interface ITireRepository
    {
        Task<bool> AddUpdateTireAsync(Tire tire);
        Task<bool> DeleteTireAsync(int id);
        Task<Tire> GetTireAsync(int id);
        Task<IEnumerable<Tire>> GetTireAsync();
    }
}
