using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Voluntari.Models;
using Voluntari.Services;
using Voluntari.Views;
using Xamarin.Forms;

namespace Voluntari.ViewModels
{
    public class LandingPageViewModel : BaseViewModel
    {
        ObservableCollection<Category> categories;

        public EventHandler CategoriesLoaded;
        public ObservableCollection<Category> Categories
        {
            get => categories;
            set => SetProperty(ref categories, value);
        }
        public Command LoadCategoriesCommand { get; set; }
        public Command TappedCommand { get; set; }

        public LandingPageViewModel()
        {
            Categories = new ObservableCollection<Category>();
            LoadCategoriesCommand = new Command(async () => await ExecuteLoadItemsCommand());
            TappedCommand = new Command<Request>(async (Request Template) => await GoToTemplateAsync(Template));
            
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var items = await DataStore.GetCategoriesAsync();
                Categories = new ObservableCollection<Category>(items);
                CategoriesLoaded?.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task GoToTemplateAsync(Request Template)
        {
            var newPage = new CreateRequestPage(Template);
            await Shell.Current.Navigation.PushAsync(newPage);
        }
    }
}
