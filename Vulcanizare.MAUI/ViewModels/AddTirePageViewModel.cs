using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI.ViewModels
{
    public partial class AddTirePageViewModel : BaseTireViewModel
    {
        public AddTirePageViewModel()
        {
            Tire = new Tire();
        }

        [ICommand]
        public async void SaveTire()
        {
            var tire = Tire;
            await App.TireService.AddUpdateTireAsync(tire);

            await Shell.Current.GoToAsync("..");
        }

        [ICommand]
        public async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
