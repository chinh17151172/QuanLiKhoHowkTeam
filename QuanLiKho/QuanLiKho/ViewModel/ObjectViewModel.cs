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
    public class ObjectViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        private ObservableCollection<Model.Object> _List;
        public ObservableCollection<Model.Object> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.Unit> _Unit;
        public ObservableCollection<Model.Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.Supplier> _Supplier;
        public ObservableCollection<Model.Supplier> Supplier { get => _Supplier; set { _Supplier = value; OnPropertyChanged(); } }

        private Model.Object _SelectedItem;
        public Model.Object SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    {
                        DisplayName = SelectedItem.DisplayName;
                        QRCode = SelectedItem.QRCode;
                        BarCode = SelectedItem.BarCode;
                        SelectedUint = _SelectedItem.Unit;
                        SelectedSupplier = _SelectedItem.Supplier;
                    }
                }
            }
        }

        private Model.Unit _SelectedUint;
        public Model.Unit SelectedUint
        {
            get => _SelectedUint; set
            {
                _SelectedUint = value;
                OnPropertyChanged();                
            }
        }

        private Model.Supplier _SelectedSupplier;
        public Model.Supplier SelectedSupplier
        {
            get => _SelectedSupplier; set
            {
                _SelectedSupplier = value;
                OnPropertyChanged();
            }
        }


        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _QRCode;
        public string QRCode { get => _QRCode; set { _QRCode = value; OnPropertyChanged(); } }

        private string _BarCode;
        public string BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }

        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }



        public ObjectViewModel()
        {
            List = new ObservableCollection<Model.Object>(DataProvider.Ins.DB.Objects);
            Unit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
            Supplier = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Suppliers);

            AddCommand = new RelayCommand<object>((p) =>
            {
                //if (SelectedSupplier == null || SelectedUint == null)
                //    return false;
                return true;
            }, (z) =>
            {
                var Object = new Model.Object() { DisplayName = DisplayName, BarCode = BarCode, QRCode = QRCode, IdSuplier = SelectedSupplier.Id, IdUnit = SelectedUint.Id, Id= Guid.NewGuid().ToString()};

                DataProvider.Ins.DB.Objects.Add(Object);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Object);
            });


            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName) || SelectedItem == null || SelectedSupplier == null || SelectedUint == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Objects.Where(z => z.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;
            }, (z) =>
            {
                var Object = DataProvider.Ins.DB.Objects.Where(t => t.Id == SelectedItem.Id).SingleOrDefault();

                Object.DisplayName = DisplayName;
                Object.BarCode = BarCode;
                Object.QRCode = QRCode;
                Object.IdSuplier = SelectedSupplier.Id;
                Object.IdUnit = SelectedUint.Id;


                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.DisplayName = DisplayName;
            });
        }

    }
}
