using k.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace k.ViewModel
{
    class ClientVM : EventPropertyChanged
    {
        public ClientVM(client client, Window window)
        {
            Window = window;
            Client = client;
            Individual = true;
            legalEntity = true;
            if (client.Individual == null && client.legalEntity == null)
            {
                client.Individual = new Individual();
                client.legalEntity = new legalEntity();
            }
            else
            {
                if (client.Individual == null)
                {
                    Individual = false;
                    Selectindex = 1;
                }
                else
                {
                    legalEntity = false;
                    Selectindex = 0;
                }
            }
                
        }
        bool individual;
        public bool Individual
        {
            get => individual;
            set
            {
                individual = value;
                OnPropertyChanged(nameof(Individual));
            }
        }
        bool legalEntity1;
        public bool legalEntity
        {
            get => legalEntity1;
            set
            {
                legalEntity1 = value;
                OnPropertyChanged(nameof(legalEntity));
            }
        }

        Window Window;
        client client;
        public client Client
        {
            get => client;
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
            }
        }
        int selectindex;
        public int  Selectindex
        {
            get => selectindex;
            set
            {
                selectindex = value;
                OnPropertyChanged(nameof(Selectindex));
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
                      if (selectindex == 0)
                      {
                          if (Client.Individual.FIO != null && Client.Individual.FIO.Length > 0)
                          {
                              if (Client.Individual.INN != null && Client.Individual.INN.Length == 12)
                              {
                                  if (Client.Individual.birthday != null)
                                  {
                                      if (Client.Individual.passport != null && Client.Individual.passport.Length > 0)
                                      {
                                          client.legalEntity = null;
                                          client.id = 1;
                                          Window.DialogResult = true;
                                          Window.Close();
                                      }
                                      else
                                          MessageBox.Show("Введите паспортные данные", "Ошибка");
                                  }
                                  else
                                      MessageBox.Show("Введите дату рождения", "Ошибка");
                              }
                              else
                                  MessageBox.Show("ИНН состоит из 12 цифр", "Ошибка");
                          }
                          else
                              MessageBox.Show("Введите ФИО", "Ошибка");
                      }
                      else
                      {
                          if (Client.legalEntity.name != null && Client.legalEntity.name.Length > 0)
                          {
                              if (Client.legalEntity.adress != null && Client.legalEntity.adress.Length > 0)
                              {
                                  if (Client.legalEntity.director != null && Client.legalEntity.director.Length > 0)
                                  {
                                      if (Client.legalEntity.INN != null && Client.legalEntity.INN.Length == 12)
                                      {
                                          if (Client.legalEntity.KPP != null && Client.legalEntity.KPP.Length == 9)
                                          {
                                              client.Individual = null;
                                              client.id = 1;
                                              Window.DialogResult = true;
                                              Window.Close();
                                          }
                                          else
                                              MessageBox.Show("КПП состоит из 9 цифр", "Ошибка");
                                      }
                                      else
                                          MessageBox.Show("ИНН состоит из 12 цифр", "Ошибка");
                                  }
                                  else
                                      MessageBox.Show("Введите ФИО директора", "Ошибка");
                              }
                              else
                                  MessageBox.Show("Введите адрес", "Ошибка");
                          }
                          else
                              MessageBox.Show("Введите название", "Ошибка");
                      }

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
