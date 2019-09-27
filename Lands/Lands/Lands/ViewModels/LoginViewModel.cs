using GalaSoft.MvvmLight.Command;
using Lands.Helpers;
using Lands.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Events
       
        #endregion

        #region Attirbutes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }
        public string Password
        {
            get  {  return password; }
            set { SetValue(ref password, value); }
        }
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }
        public bool IsRemembered { get; set; }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
            
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;

            this.Email = "admin@gmail.com";
            this.Password = "admin";
        }
        #endregion
        
        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }

        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Your must enter an password",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.Email != "admin@gmail.com" || this.Password != "admin")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or Password incorrect",
                    "Accept");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion
    }
}
