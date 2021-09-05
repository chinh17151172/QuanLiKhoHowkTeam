using QuanLiKho.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLiKho.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }


        public ICommand CloseCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        // Mọi thứ xử lí nằm trong này     

        public LoginViewModel()
        {
            IsLogin = false;
            UserName = "";
            Password = "";

            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });

            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
        }

        void Login(Window p)
        {
            if (p == null)
                return;

            // Mã hóa Password -> Base64 -> MD5 (tăng tính bảo mật cho mật khẩu)
            string passEncode = MD5Hash(Base64Encode(Password));
            var accCount = DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName && x.Password == passEncode).Count();

            if(accCount > 0)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu. Vui lòng đăng nhập lại !!");
            }           

        }

        // String to Base64
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        // String to MD5
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

    }
}
