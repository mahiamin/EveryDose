using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EveryDose.Database.DBInterface;
using EveryDose.Model;
using EveryDose.View;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace EveryDose.ViewModel
{
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly IDatabaseOperation databaseOperation;

        public ProfileViewModel(IDatabaseOperation dbOperation)
        {
            databaseOperation = dbOperation;
        }

        #region Properties

        [ObservableProperty]
        private ObservableCollection<Employee> _profileList;

        [ObservableProperty]
        private string _firstName;

        [ObservableProperty]
        private string _lastName;

        [ObservableProperty]
        private string _dob;

        [ObservableProperty]
        private string _fullName;

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private bool _isRefreshing;

        #endregion

        #region Methods

        /// <summary>
        /// Add new employee record to database
        /// </summary>
        [RelayCommand]
        public void AddEmployee()
        {
            try
            {
                Employee employee = new Employee()
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    Dob = this.Dob
                };

                int res = databaseOperation.Addemployee(employee);

                if (res == 1)
                {
                    Application.Current.MainPage.Navigation.PopModalAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Navigate to Profile details page
        /// </summary>
        /// <param name="emp"></param>
        [RelayCommand]
        public void SelectedEmployee(Employee emp)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new ProfileDetailPage(emp)));
        }

        /// <summary>
        /// Update an employee
        /// </summary>
        /// <param name="emp"></param>
        [RelayCommand]
        public void UpdateEmployee(Employee emp)
        {
            try
            {
                Employee employee = new Employee()
                {
                    id = emp.id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Dob = emp.Dob
                };

                int res = databaseOperation.UpdateEmployee(employee);

                if (res == 1)
                {
                    Application.Current.MainPage.Navigation.PopModalAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [RelayCommand]
        public void RefreshEmployeeList()
        {
            try
            {
                IsRefreshing = true;
                var empList = databaseOperation.GetEmployees();

                if(empList != null)
                {
                    ProfileList = new ObservableCollection<Employee>(empList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        /// <summary>
        /// Select all employees from database
        /// </summary>
        public void GetEmployees()
        {
            try
            {
                var empList = databaseOperation.GetEmployees();
                ProfileList = new ObservableCollection<Employee>(empList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
