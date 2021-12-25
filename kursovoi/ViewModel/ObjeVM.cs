using kursovoi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kursovoi.ViewModel
{
    class ObjeVM : EventPropertyChanged
    {
        public ObjeVM(obje obje, Window window)
        {
            Window = window;
            Obje = obje;
            if (obje.houses == null)
                obje.houses = new houses();
            if (obje.flat == null)
                obje.flat = new flat();
            Flat = true;
        }
        Window Window;
        obje obje;
        public obje Obje
        {
            get => obje;
            set
            {

                obje = value;
                OnPropertyChanged(nameof(Obje));
            }
        }

        bool flat;
        public bool Flat
        {
            get => flat;
            set
            {
                flat = value;
                OnPropertyChanged(nameof(Flat));
                OnPropertyChanged(nameof(Houses));
            }
        }
        public bool Houses
        {
            get => !flat;
            set
            {
                flat = !value;
                OnPropertyChanged(nameof(Houses));
                OnPropertyChanged(nameof(Flat));
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
                      if (Obje.name != null && Obje.name.Length > 0)
                      {
                          if (Obje.priceBuy > 0)
                          {
                              if (Obje.priceRent > 0)
                              {
                                  if (Obje.area > 0)
                                  {
                                      if (Obje.adress != null && Obje.adress.Length > 0)
                                      {
                                          if (Flat)
                                          {
                                              obje.houses = null;
                                              Window.DialogResult = true;
                                              Window.Close();
                                          }
                                          else
                                          {
                                              obje.flat = null;
                                              Window.DialogResult = true;
                                              Window.Close();
                                          }
                                      }
                                      else
                                          MessageBox.Show("Введите адрес", "Ошибка");
                                  }
                                  else
                                      MessageBox.Show("Введите площадь", "Ошибка");

                              }
                              else
                                  MessageBox.Show("Введите стоимость аренды", "Ошибка");
                          }
                          else
                              MessageBox.Show("Введите стоимость покупки", "Ошибка");
                      }
                      else
                          MessageBox.Show("Введите название", "Ошибка");
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
