using QuanLiKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLiKho.ViewModel
{
    public class SupplierViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        private ObservableCollection<Supplier> _List;
        public ObservableCollection<Supplier> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Supplier _SelectedItem;
        public Supplier SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    Address = SelectedItem.Address;
                    Phone = SelectedItem.Phone;
                    Email = SelectedItem.Email;
                    MoreInfo = SelectedItem.MoreInfo;
                    ContractDate = SelectedItem.ContractDate;
                }
            }
        }


        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }

        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }



        public SupplierViewModel()
        {
            List = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Suppliers);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (z) =>
            {
                var Supplier = new Supplier() { DisplayName = DisplayName, Address = Address, Phone = Phone, Email = Email, MoreInfo = MoreInfo, ContractDate = ContractDate };

                DataProvider.Ins.DB.Suppliers.Add(Supplier);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Supplier);
            });


            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Suppliers.Where(z => z.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;
            }, (z) =>
            {
                var Supplier = DataProvider.Ins.DB.Suppliers.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();

                Supplier.DisplayName = DisplayName;
                Supplier.Address = Address;
                Supplier.Phone = Phone;
                Supplier.Email = Email;
                Supplier.MoreInfo = MoreInfo;
                Supplier.ContractDate = ContractDate;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.DisplayName = DisplayName;
            });
        }

    }
}
