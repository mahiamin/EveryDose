using EveryDose.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EveryDose.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewProfilePage : ContentPage
    {
        private ProfileViewModel profileViewModel;
        public NewProfilePage()
        {
            InitializeComponent();
            profileViewModel = App.Current.Services.GetService<ProfileViewModel>();

            this.BindingContext = profileViewModel;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(); 
        }
    }
}