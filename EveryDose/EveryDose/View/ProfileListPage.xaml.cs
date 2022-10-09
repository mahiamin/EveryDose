using EveryDose.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EveryDose.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileListPage : ContentPage
    {
        private ProfileViewModel profileViewModel;

        public ProfileListPage()
        {
            InitializeComponent();

            profileViewModel = App.Current.Services.GetService<ProfileViewModel>();

            this.BindingContext = profileViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            profileViewModel.GetEmployees();
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            try
            {
               await Navigation.PushModalAsync(new NavigationPage( new NewProfilePage()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}