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
    public class ClientSelectVM : EventPropertyChanged
    {
        public ClientSelectVM(contract contract, DBCrud db, Window window)
        {
            Window = window;
            this.db = db;
            this.contract = contract;
            Clients = new ObservableCollection<client>(db.getClients());
        }
        DBCrud db;
        Window Window;
        contract contract;
        public client ClientSel
        {
            get => contract.client;
            set
            {
                contract.client = value;
                Window.Close();
                OnPropertyChanged(nameof(ClientSel));
            }
        }

        ObservableCollection<client> clients;
        public ObservableCollection<client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }
    }
}
