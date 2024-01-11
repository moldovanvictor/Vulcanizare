using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI.ViewModels
{
    public partial class BaseTireViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Tire _tire; 

        public INavigation Navigation { get; set; }
    }
}
