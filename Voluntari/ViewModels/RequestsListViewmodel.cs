using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Voluntari.Models;
using Voluntari.Views;

namespace Voluntari.ViewModels
{
    public class RequestsListViewmodel : BaseViewModel
    {
        ObservableCollection<Request> requests = new ObservableCollection<Request>();
        public ObservableCollection<Request> Requests
        {
            get => requests;
            set => SetProperty(ref requests, value);
        }
        public Command LoadItemsCommand { get; set; }

        public RequestsListViewmodel()
        {
            Title = "Browse";
            Requests = new ObservableCollection<Request>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Requests.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Requests = new ObservableCollection<Request>(items);
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
    }
}