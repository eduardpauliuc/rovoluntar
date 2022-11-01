using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Voluntari.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingPage : ContentPage
    {
        public RatingPage()
        {
            InitializeComponent();
        }

        private async void Button_Pressed(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            s1.Source = "stea1";
            s2.Source = "stea0";
            s3.Source = "stea0";
            s4.Source = "stea0";
            s5.Source = "stea0";
        }
        private void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            s1.Source = "stea1";
            s2.Source = "stea1";
            s3.Source = "stea0";
            s4.Source = "stea0";
            s5.Source = "stea0";
        }
        private void TapGestureRecognizer_Tapped3(object sender, EventArgs e)
        {
            s1.Source = "stea1";
            s2.Source = "stea1";
            s3.Source = "stea1";
            s4.Source = "stea0";
            s5.Source = "stea0";
        }
        private void TapGestureRecognizer_Tapped4(object sender, EventArgs e)
        {
            s1.Source = "stea1";
            s2.Source = "stea1";
            s3.Source = "stea1";
            s4.Source = "stea1";
            s5.Source = "stea0";
        }
        private void TapGestureRecognizer_Tapped5(object sender, EventArgs e)
        {
            s1.Source = "stea1";
            s2.Source = "stea1";
            s3.Source = "stea1";
            s4.Source = "stea1";
            s5.Source = "stea1";
        }
    }
}