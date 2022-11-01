using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Voluntari.Models;
using Voluntari.ViewModels;

namespace Voluntari.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestDetailsPage : ContentPage
    {
        ViewModels.RequestDetailsViewModel viewModel;

        public RequestDetailsPage(ViewModels.RequestDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public RequestDetailsPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ViewModels.RequestDetailsViewModel(item);
            BindingContext = viewModel;
        }
    }
}