using System;
using Voluntari.Models;
using Voluntari.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Voluntari.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestsListPage : ContentPage
    {
        RequestsListViewmodel viewModel;

        public RequestsListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RequestsListViewmodel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new RequestDetailsPage(new ViewModels.RequestDetailsViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CreateRequestPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            (BindingContext as RequestsListViewmodel).LoadItemsCommand.Execute(null);
            if (viewModel.Requests.Count == 0)
                viewModel.IsBusy = true;
        }

        private async void ItemsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsCollectionView.SelectedItem == null)
                return;

            var req = ItemsCollectionView.SelectedItem as Request;

            ItemsCollectionView.SelectedItem = null;


            if(req.Status == StatusKind.Acceptat)
            {
                var result = await DisplayAlert("Confirmare finalizare", "Doriti sa confirmati finalizarea cererii?", "Da", "Nu");
                if (result)
                {
                    await (BindingContext as RequestsListViewmodel).DataStore.FinishRequestAsync(req);

                    await Navigation.PushModalAsync(new RatingPage());
                }
            }
        }
    }
}