using k.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace k.ViewModel
{
    class WorkerVM : EventPropertyChanged
    {
        public WorkerVM(worker worker, Window window)
        {
            Window = window;
            Worker = worker;            
        }
        Window Window;
        worker worker;
        public worker Worker
        {
            get => worker;
            set
            {

                worker = value;
                OnPropertyChanged(nameof(Worker));
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
                      if (Worker.FIO != null && Worker.FIO.Length > 0)
                      {
                          if (Worker.post != null && Worker.post.Length > 0)
                          {
                              if (Worker.Birthdate != null)
                              {
                                  worker.workerID = 1;
                                  Window.DialogResult = true;
                                  Window.Close();
                              }
                              else
                                  MessageBox.Show("Введите дату рождения", "Ошибка");
                          }
                          else
                              MessageBox.Show("Введите должность", "Ошибка");
                      }
                      else
                          MessageBox.Show("Введите ФИО", "Ошибка");
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
    }
}
