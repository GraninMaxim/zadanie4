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

namespace zadanie4
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        user04Entities db = user04Entities.GetContext();
        Agent p1 = new Agent();
        public Add()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            p1.ID = Convert.ToInt32(id.Text);
            p1.AgentTypeID = (string)Atype.SelectedItem.ToString();
            p1.Title = Name.Text;
            p1.Phone = phone.Text;
            p1.Priority = Convert.ToInt32(prior.Text);
            p1.INN = INN.Text;

            db.Agents.Add(p1);
            db.SaveChanges();
            this.Close();

        }
    }
}
