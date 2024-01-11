using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulcanizare.MAUI.Views;
using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI.ViewModels
{
    public partial class TirePageViewModel : BaseTireViewModel
    {
        public ObservableCollection<Tire> tireList { get; }
        public TirePageViewModel(INavigation navigation)
        {
            tireList = new ObservableCollection<Tire>();
            Navigation = navigation;
        }

        [ICommand]
        private async void OnAddTire()
        {
            await Shell.Current.GoToAsync(nameof(AddTirePage));
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        [ICommand]
        private async Task LoadTire()
        {
        IsBusy = true;

            try
            {
                tireList.Clear();
                var tires = await App.TireService.GetTireAsync();
                foreach (var item in tires)
                {
                    tireList.Add(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        [ICommand]
        private async void TireTappedDelete(Tire tire)
        {
            if (tire == null)
                return;
            await App.TireService.DeleteTireAsync(tire.Id);
            await LoadTire();
            OnAppearing();
            
        }

        [ICommand]
        private async void TireTappedEdit(Tire tire)
        {
            if (tire == null)
                return;
            await Navigation.PushAsync(new AddTirePage(tire));

        }
    }
}
