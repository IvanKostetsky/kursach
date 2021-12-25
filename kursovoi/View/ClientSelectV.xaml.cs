using kursovoi.Model;
using kursovoi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kursovoi.View
{
    /// <summary>
    /// Логика взаимодействия для ClientSelectV.xaml
    /// </summary>
    public partial class ClientSelectV : Window
    {
        public ClientSelectV(contract contract, DBCrud db)
        {
            InitializeComponent();
            DataContext = new ClientSelectVM(contract, db, this);
        }
    }
}
