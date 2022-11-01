
using System;
using Voluntari.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Voluntari.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();

            var context = new LandingPageViewModel();
            context.CategoriesLoaded += CategoriesLoaded;
            BindingContext = context;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var context = BindingContext as LandingPageViewModel;

            context.LoadCategoriesCommand.Execute(null);
            CategoriesLoaded(this, new EventArgs());

            /*context.LoadData().ContinueWith(t =>
            {
                if (t.IsFaulted)
                    ExceptionHandler.HandleException(t.Exception);
            });*/
        }

        private void CategoriesLoaded(object sender, EventArgs args)
        {
            carousel.Position = 1;
        }

    }
}