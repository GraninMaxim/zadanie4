using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zadanie4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        user04Entities db = user04Entities.GetContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Agents.Load();
            listview1.ItemsSource = db.Agents.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add f = new Add();
            f.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Agent row = (Agent)listview1.SelectedValue;
                db.Agents.Remove(row);
                db.SaveChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Выберите запись");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
             int indexRow = listview1.SelectedIndex;
             if(indexRow != -1) 
            {
                Agent row = (Agent)listview1.Items[indexRow];
                  Data.Id = row.ID;
                  Edit a = new Edit();
                 a.ShowDialog();

                listview1.Items.Refresh();
            }

            
        }
    }
}
