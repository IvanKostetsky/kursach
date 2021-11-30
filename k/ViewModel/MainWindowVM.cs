using k.Model;
using k.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k.ViewModel
{
    class MainWindowVM : EventPropertyChanged
    {
        DBCrud db;
        public MainWindowVM()
        {
            db = new DBCrud();
            Objes = new ObservableCollection<obje>(db.getObjes());
            Contracts = new ObservableCollection<contract>(db.getContracts());
            Clients = new ObservableCollection<client>(db.getClients());
            Workers = new ObservableCollection<worker>(db.getWorkers());

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

        ObservableCollection<contract> contracts;
        public ObservableCollection<contract> Contracts
        {
            get => contracts;
            set
            {
                contracts = value;
                OnPropertyChanged(nameof(Contracts));
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

        obje objeSel;
        public obje ObjeSel { get => objeSel;
            set { objeSel = value;
                OnPropertyChanged(nameof(ObjeSel));
            }
        }

        contract contractSel;
        public contract ContractSel
        {
            get => contractSel;
            set
            {
                contractSel = value;
                OnPropertyChanged(nameof(ContractSel));
            }
        }

        client clientSel;
        public client ClientSel
        {
            get => clientSel;
            set
            {
                clientSel = value;
                OnPropertyChanged(nameof(ClientSel));
            }
        }

        worker workerSel;
        public worker WorkerSel
        {
            get => workerSel;
            set
            {
                workerSel = value;
                OnPropertyChanged(nameof(WorkerSel));
            }
        }


        private DelegateCommand newObje;
        public DelegateCommand NewObje
        {
            get
            {
                return newObje ??
                  (newObje = new DelegateCommand(obj =>
                  {
                      obje obje = new obje();
                      obje.id = 1;
                      ObjeV win = new ObjeV(obje);
                      if (win.ShowDialog() == true)
                      {
                          db.addObje(obje);
                          Objes.Add(obje);
                      }
                  }));
            }
        }

        private DelegateCommand editObje;
        public DelegateCommand EditObje
        {
            get
            {
                return editObje ??
                  (editObje = new DelegateCommand(obj =>
                  {
                      if (ObjeSel != null && ObjeSel.isEditable)
                      {
                          obje obje = new obje(ObjeSel);
                          ObjeV win = new ObjeV(obje);
                          if (win.ShowDialog() == true)
                          {
                              db.editObje(obje);
                          }
                      }
                  }));
            }
        }


        private DelegateCommand newclient;
        public DelegateCommand NewClient
        {
            get
            {
                return newclient ??
                  (newclient = new DelegateCommand(obj =>
                  {
                      client client = new client();
                      client.id = 1;
                      ClientV win = new ClientV(client);
                      if (win.ShowDialog() == true)
                      {
                          db.addClient(client);
                          Clients.Add(client);
                      }
                  }));
            }
        }

        private DelegateCommand editclient;
        public DelegateCommand EditClient
        {
            get
            {
                return editclient ??
                  (editclient = new DelegateCommand(obj =>
                  {
                      if (ClientSel != null)
                      {
                          client client = new client(ClientSel);
                          ClientV win = new ClientV(client);
                          if (win.ShowDialog() == true)
                          {
                              db.editClient(client);
                          }
                      }
                  }));
            }
        }


        private DelegateCommand newworkers;
        public DelegateCommand NewWorker
        {
            get
            {
                return newworkers ??
                  (newworkers = new DelegateCommand(obj =>
                  {
                      worker worker = new worker();
                      worker.workerID = 1;
                      WorkerV win = new WorkerV(worker);
                      if (win.ShowDialog() == true)
                      {
                          db.addWorker(worker);
                          Workers.Add(worker);
                      }
                  }));
            }
        }

        private DelegateCommand editWorker;
        public DelegateCommand EditWorker
        {
            get
            {
                return editWorker ??
                  (editWorker = new DelegateCommand(obj =>
                  {
                      if (WorkerSel != null)
                      {
                          worker worker = new worker(WorkerSel);
                          WorkerV win = new WorkerV(worker);
                          if (win.ShowDialog() == true)
                          {
                              db.editWorker(worker);
                          }
                      }
                  }));
            }
        }
        private DelegateCommand newContract;
        public DelegateCommand NewContract
        {
            get
            {
                return newContract ??
                  (newContract = new DelegateCommand(obj =>
                  {
                      contract contract = new contract();
                      contract.contractID = 1;
                      ContractV win = new ContractV(contract, db);
                      if (win.ShowDialog() == true)
                      {
                          db.addContract(contract);
                          Contracts.Add(contract);
                      }
                  })); 
            }
        }

        private DelegateCommand openContract;
        public DelegateCommand OpenContract
        {
            get
            {
                return openContract ??
                  (openContract = new DelegateCommand(obj =>
                  {
                      if (contractSel != null)
                      {
                          ContractOpenV win = new ContractOpenV(contractSel);
                          win.ShowDialog();
                      }
                  })); 
            }
        }
    }
}
