using EveryDose.Model;
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
    public partial class ProfileDetailPage : ContentPage
    {
        private ProfileViewModel profileViewModel;
        public bool isSaveBtnVisible { get; set; }
        private Employee selectedEmp { get; set; }
        private int count { get; set; }
        public ProfileDetailPage()
        {
            InitializeComponent();
        }

        public ProfileDetailPage(Employee employee)
        {
            InitializeComponent();

            isSaveBtnVisible = false;
            count = 0;
            selectedEmp = employee;

            profileViewModel = App.Current.Services.GetService<ProfileViewModel>();

            this.BindingContext = profileViewModel;

            profileViewModel.FirstName = employee.FirstName;
            profileViewModel.LastName = employee.LastName;
            profileViewModel.Dob = employee.Dob;
            profileViewModel.FullName= employee.FullName;

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            selectedEmp.FirstName = profileViewModel.FirstName;
            selectedEmp.LastName = profileViewModel.LastName;
            selectedEmp.Dob = profileViewModel.Dob;
            profileViewModel.UpdateEmployee(selectedEmp);
        }

        private async void BackButton_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            count++;

            if (isSaveBtnVisible && count > 3)
            {
                saveButton.IsVisible = true;
            }
            isSaveBtnVisible = true;
        }


    }
}