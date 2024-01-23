using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CreditoGS.View;
using Capa_Entidad;
using Capa_Negocio;
using System.Windows;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Runtime;
using System.Diagnostics;


namespace CreditoGS.ViewModel
{
    internal class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username = "914120631";
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        Configuration AppConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        readonly CN_LoginUser loginUser = new CN_LoginUser();
        //Properties
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        MainViewModel mainviewModel = new MainViewModel();
        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        //Constructor
        public LoginViewModel()
        {

            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private async void ExecuteLoginCommand(object obj)
        {
            MainView mainView = new MainView(mainviewModel);
            var isValidUser = true;
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                 
                var ss = SecureStringToString(Password);
                Loader loadingWindow = new Loader();
                loadingWindow.Show();

                var result = await loginUser.Login(new CE_LoginUser() { Phone_number = Username, Password = ss });

                loadingWindow.Close();
                if (result != null)
                {
                    if (result.issuccess)
                    {
                        if (AppConfig.Sections["UISettings"] is null)
                        {
                            AppConfig.Sections.Add("UISettings", new UISettings());

                        }

                        App.Current.Properties["TokenAuth"] = result.data.token;
                        App.Current.Properties["TokenAuthRefresh"] = result.data.refresh_token;

                        mainviewModel.IsViewVisible = true;
                        //mainView.Show();

                        IsViewVisible = false;
                    }
                    else
                    {
                        MessageBox.Show(result.message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }

        String SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}
