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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YP.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
        }

        private void textboxNomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int nom = Convert.ToInt32(textboxNomer.Text);
                Employees employees = Classes.ClassBase.entities.Employees.FirstOrDefault(x => x.nomer == nom);
                
                if(employees != null)
                {
                    textboxPassword.IsEnabled = true;
                    textboxPassword.CaretIndex = textboxPassword.Text.Length;
                }
                else
                {
                    MessageBox.Show("csc", "Сообщение");
                }
               
            }

        }
    }
}
