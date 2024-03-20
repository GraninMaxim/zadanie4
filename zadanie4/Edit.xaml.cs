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
using System.Windows.Shapes;

namespace zadanie4
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        user04Entities db = user04Entities.GetContext();
        Agent p1;
        public Edit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            p1 = db.Agents.Find(Data.Id);

            Name.Text = p1.Title;
            Atype.Text = p1.AgentTypeID.ToString();
            INN.Text = p1.INN;
            phone.Text = p1.Phone;
            prior.Text = p1.Priority.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            p1.Title = Name.Text;
            p1.AgentTypeID = (string)Atype.SelectedItem.ToString();
            p1.INN = INN.Text;
            p1.Phone = phone.Text;
            p1.Priority = int.Parse(prior.Text);

            db.SaveChanges();
            this.Close();

        }

      
    }
}
