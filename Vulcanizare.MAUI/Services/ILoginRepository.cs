using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI.Services
{
    internal interface ILoginRepository
    {
        Task<UserInfo> Login(string userName, string password);
    }
}
