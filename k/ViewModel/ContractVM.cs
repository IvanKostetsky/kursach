using k.Model;
using k.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace k.ViewModel
{
    class ContractVM : EventPropertyChanged
    {
        DBCrud db;
        public ContractVM(contract contract, DBCrud db, Window window)
        {
            this.db = db;
            Window = window;
            Contract = contract;
            Tipecontracts = new ObservableCollection<tipecontract>(db.getTipes());
            TipeSelect = Tipecontracts.First();
            Workers = new ObservableCollection<worker>(db.getWorkers());
        }
        ObservableCollection<worker> workers;
        public ObservableCollection<worker> Workers
        {
            get => workers;
            set
            {
                workers = value;
                OnPropertyChanged(nameof(Workers));
            }
        }

        ObservableCollection<tipecontract> tipecontracts;
        public ObservableCollection<tipecontract> Tipecontracts
        {
            get => tipecontracts;
            set
            {
                tipecontracts = value;
                OnPropertyChanged(nameof(Tipecontracts));
            }
        }

        public tipecontract TipeSelect
        {
            get => contract.tipecontract;
            set
            {
                contract.tipecontract = value;
                if (value.id == 1)
                    Rent = true;
                else
                    Rent = false;
                OnPropertyChanged(nameof(TipeSelect));
            }
        }

        bool rent;
        public bool Rent
        {
            get => rent;
            set
            {
                rent = value;
                OnPropertyChanged(nameof(Rent));
            }
        }

        Window Window;
        contract contract;
        public contract Contract
        {
            get => contract;
            set
            {
                contract = value;
                OnPropertyChanged(nameof(Contract));
            }
        }
        
        private DelegateCommand ok;
        public DelegateCommand OK
        {
            get
            {
                return ok ??
                  (ok = new DelegateCommand(obj =>
                  {
                      if (contract.obje != null)
                      {
                          if (contract.worker != null)
                          {
                              if (contract.client != null)
                              {
                                  if ((contract.tipecontract.id == 1 && contract.beginRent != null && contract.endRent != null) || (contract.tipecontract.id == 0))
                                  {
                                      if ((contract.tipecontract.id == 1 && contract.beginRent <= contract.endRent) || (contract.tipecontract.id == 0))
                                      {
                                          if(contract.beginRent.Value.Date >= DateTime.Today.Date)
                                          {
                                              if (db.getContracts().Where(i => i.objeFK == contract.objeFK &&  ((i.beginRent >= contract.beginRent && i.beginRent <= contract.endRent)||(i.endRent >= contract.beginRent && i.endRent <= contract.endRent)) ).Count() == 0)
                                              {
                                                  contract.contractID = 1;
                                                  contract.contract_type = contract.tipecontract.id;
                                                  contract.objeFK = contract.objeFK;
                                                  contract.clientFK = contract.client.id;
                                                  contract.workerFK = contract.worker.workerID;
                                                  Window.DialogResult = true;
                                                  Window.Close();
                                              }
                                              else
                                                  MessageBox.Show("Даты аренды не должны пересекаться", "Ошибка");
                                          }
                                          else
                                              MessageBox.Show("Начало аренды не может быть раньше сегодняшней даты", "Ошибка");
                                      }
                                      else
                                          MessageBox.Show("Дата начала аренды должна быть раньше окончания аренды", "Ошибка");
                                  }
                                  else
                                      MessageBox.Show("Введите дату аренды", "Ошибка");
                              }
                              else
                                  MessageBox.Show("Выберите клиента", "Ошибка");
                          }
                          else
                              MessageBox.Show("Выберите сотрудника", "Ошибка");
                      }
                      else
                          MessageBox.Show("Выберите объект", "Ошибка");

                  }));
            }
        }

        private DelegateCommand cansel;
        public DelegateCommand Cansel
        {
            get
            {
                return cansel ??
                  (cansel = new DelegateCommand(obj =>
                  {
                      Window.DialogResult = false;
                      Window.Close();
                  }));
            }
        }


        private DelegateCommand openClient;
        public DelegateCommand OpenClient
        {
            get
            {
                return openClient ??
                  (openClient = new DelegateCommand(obj =>
                  {
                      ClientSelectV win = new ClientSelectV(Contract, db);
                      win.ShowDialog();
                  }));
            }
        }


        private DelegateCommand openObje;
        public DelegateCommand OpenObje
        {
            get
            {
                return openObje ??
                  (openObje = new DelegateCommand(obj =>
                  {
                      ObjeSelectV win = new ObjeSelectV(Contract, db);
                      win.ShowDialog();
                  }));
            }
        }
    }
}
