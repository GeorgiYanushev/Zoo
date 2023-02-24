using System.Windows;
using Menu = Zoo.View.Menu;
using ZooDB.DataBase;

namespace Zoo.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {

        public Command LoginCommand { get; private set;}

        private string _username;
        private string _password;
        public string Username
             {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
             }
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            Username = "User";
            Password = "123";

        }
        public void Login(object message)
        {
            if(DBService.Login(Username,Password)==true)
            {
                Menu menu = new Menu();
                menu.Show();
                Window loginWindow = (Window)message;
                loginWindow.Close();
            }
            else
            {
                MessageBox.Show("username or password is incorrect");
            }
        }
    }
}
