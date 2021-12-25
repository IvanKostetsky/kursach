using kursovoi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kursovoi.ViewModel
{
    class ObjeSelectVM : EventPropertyChanged
    {
        public ObjeSelectVM(contract contract, DBCrud db, Window window)
        {
            Window = window;
            this.db = db;
            this.contract = contract;
            Objes = new ObservableCollection<obje>(db.getObjes().Where(i => !i.isSold));
        }
        DBCrud db;
        Window Window;
        contract contract;
        public obje ObjeSel
        {
            get => contract.obje;
            set
            {
                contract.obje = value;
                Window.Close();
                OnPropertyChanged(nameof(ObjeSel));
            }
        }

        ObservableCollection<obje> objes;
        public ObservableCollection<obje> Objes
        {
            get => objes;
            set
            {
                objes = value;
                OnPropertyChanged(nameof(Objes));
            }
        }
    }
}
