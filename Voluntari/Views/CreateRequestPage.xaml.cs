using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Voluntari.Models;
using Voluntari.ViewModels;
using Xamarin.Forms.Maps;

namespace Voluntari.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateRequestPage : ContentPage
    {

        public CreateRequestPage()
        {
            InitializeComponent();

            BindingContext = new CreateRequestViewModel();
        }

        public CreateRequestPage(Request template):this()
        {
            BindingContext = new CreateRequestViewModel(template);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(47.6415226190054, 26.2590884417295), Distance.FromMiles(1)));
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
        }

        private void Map_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            var map = (sender as Xamarin.Forms.Maps.Map);

            map.Pins.Clear();
            map.Pins.Add(new Pin()
            {
                Position = e.Position,
                Label = "Destinatie"
            });

        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            //TO-DO : Replace this. Add selected skills to the model

            var button = (sender as Button);

            button.BorderColor = Color.DarkBlue == button.BorderColor ? Color.LightGray : Color.DarkBlue;
            button.TextColor = Color.Black == button.TextColor ? Color.Gray : Color.Black;
        }
    }
}