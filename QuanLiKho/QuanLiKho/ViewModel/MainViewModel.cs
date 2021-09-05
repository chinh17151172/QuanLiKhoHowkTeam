using QuanLiKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

/// <summary>
/// Dùng làm DataContext cho MainWindow
/// </summary>
/// 

namespace QuanLiKho.ViewModel
{
   

    public class MainViewModel : BaseViewModel
    {

        //  ObservableCollection khác với List là cập nhật dữ liệu ngay lạp tức khi dữ liệu bị thay đổi ở database
        private ObservableCollection<Inventory> _InventoryList;
        public ObservableCollection<Inventory> InventoryList { get => _InventoryList; set { _InventoryList = value; OnPropertyChanged(); } }

        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand SupplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }

        // Mọi thứ xử lí nằm trong này     

        public MainViewModel()
        {
            // To process when MainWidow open, LoginWidow will open 
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; },
               (p) =>
               {
                   IsLoaded = true;

                   if (p == null)
                       return;

                   p.Hide();
                   LoginWindow f = new LoginWindow();
                   f.ShowDialog();    // When Login window Close, Main window will show.

                   if (f.DataContext == null)
                       return;

                   var loginVM = f.DataContext as LoginViewModel;

                   if(loginVM.IsLogin)
                   {
                       p.Show();
                       LoadInventoryData();
                   }
                   else
                   {
                       p.Close();
                   }
                   
               }
               );

            // Open Unit window
            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UnitWindow wd = new UnitWindow(); wd.ShowDialog(); });

            // Open Supplier window
            SupplierCommand = new RelayCommand<object>((p) => { return true; }, (p) => { SupplierWindow w = new SupplierWindow(); w.ShowDialog(); });

            // Open Customer window
            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CustomerWindow w = new CustomerWindow(); w.ShowDialog(); });

            // Open Objct window
            ObjectCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ObjectWindow w = new ObjectWindow(); w.ShowDialog(); });

            // Open User window
            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UserWindow w = new UserWindow(); w.ShowDialog(); });

            // Open Input window
            InputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { InputWindow w = new InputWindow(); w.ShowDialog(); });

            // Open Output window
            OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { OutputWindow w = new OutputWindow(); w.ShowDialog(); });

            var a = DataProvider.Ins.DB.Users.ToList();
        }

        void LoadInventoryData()
        {
            InventoryList = new ObservableCollection<Inventory>();

            var objectList = DataProvider.Ins.DB.Objects;

            int i = 1;
            foreach (var item in objectList)
            {
                var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                var outputList = DataProvider.Ins.DB.OutputInfoes.Where(p => p.IdObject == item.Id);

                int sumInput = 0;
                int sumOutput = 0;

                if(inputList != null && inputList.Count()>0)
                {
                    sumInput = (int)inputList.Sum(p => p.Count);
                }
                if (outputList != null && outputList.Count() > 0)
                {
                    sumOutput = (int)outputList.Sum(p => p.Count);
                }

                Inventory inventory = new Inventory();
                inventory.STT = i;
                inventory.Count = sumInput - sumOutput;
                inventory.Object = item;

                InventoryList.Add(inventory);

                i++; // Cho nhiều Object. Nếu không có i++ thì chỉ xử lí có 1 Object
            }
        }

    }
}
