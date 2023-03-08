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
using System.Windows.Threading;

namespace YP.Pages
{
    //код 123
    //пароль 12345678

    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public int kk2 = 0;
        private int timer = 10;
        public int kk;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public PageAuthorization()
        {
            InitializeComponent();
          
        }
        

        public PageAuthorization(int kk)
        {
            InitializeComponent();
            if (kk != 0)
            {
                textboxKod.IsEnabled = true;
                textboxPassword.IsEnabled = false;
                textboxNomer.IsEnabled = false;

                textboxKod.Focus();
              
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += new EventHandler(Back);
                dispatcherTimer.Start();
                kk2 = kk;
            }
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
                    textboxNomer.IsEnabled = false;
                    textboxPassword.Focus();
                }
                else
                {
                    MessageBox.Show("Данного сотрудника нет в базе", "Сообщение");
                }
               
            }

        }

        private void textboxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                int p = textboxPassword.Password.GetHashCode();
                //MessageBox.Show($"{p}", "Сообщение"); 
                Employees employees = Classes.ClassBase.entities.Employees.FirstOrDefault(x => x.password == p);
                if(employees != null)
                {
                    Windows.WindowKpd windowKpd = new Windows.WindowKpd();
                    windowKpd.ShowDialog();
                    kk = employees.id_role;
                    Classes.ClassFrame.frame.Navigate(new PageAuthorization(kk));
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    dispatcherTimer.Tick += new EventHandler(Back);
                    dispatcherTimer.Start();
                 
                }
                else
                {
                    MessageBox.Show("Введен неверный пароль", "Сообщение");
                }
            }

        }

        private void Back(object sender, EventArgs e)
        {
            if (timer == -1)
            {
                dispatcherTimer.Stop();
                TextClue.Text = "Вы не успели ввести код\nДля повторной отправки кода нажмите кнопку";
                textboxKod.IsEnabled = false;
                textboxPassword.IsEnabled = false;
                textboxNomer.IsEnabled = false;
               
                    btnRepeat.IsEnabled = true;
                
            } 
            else
            {
                TextClue.Text = "Таймер: " + timer;
            }
            timer--;
        }

        private void textboxKod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Roles roles = Classes.ClassBase.entities.Roles.FirstOrDefault(x => x.id_role == kk2);
                Windows.WindowKpd windowKpd = new Windows.WindowKpd();
                MessageBox.Show($"{kk2}", "Сообщение");
                if (textboxKod.Text == windowKpd.text)
                {
                    
                    MessageBox.Show($"Поздравляю вы авторизировались!\nВаша роль {roles.role}", "Сообщение");
                    textboxKod.IsEnabled = false;
                    textboxPassword.IsEnabled = false;
                    textboxNomer.IsEnabled = false;
                    dispatcherTimer.Stop();
                    TextClue.Text = "";
                }
                else
                {
                    textboxPassword.IsEnabled = false;
                    textboxNomer.IsEnabled = false;
                    MessageBox.Show("Неверный код", "Сообщение");
                }
                // pF0Jbd$@
            }
        }
    
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            textboxNomer.Clear();
            textboxPassword.Clear();
            textboxKod.Clear();
            textboxKod.IsEnabled = false;
            textboxPassword.IsEnabled = false;
            textboxNomer.IsEnabled = true;
            dispatcherTimer.Stop();
            btnRepeat.IsEnabled = false;
            TextClue.Text = "";
        }
        public int v;
        private void btnRepeat_Click(object sender, RoutedEventArgs e)
        {
            
            Windows.WindowKpd windowKpd = new Windows.WindowKpd();
            windowKpd.ShowDialog();
            v = 1;
            //kk = employees.id_role;
            Classes.ClassFrame.frame.Navigate(new PageAuthorization(kk2));
          
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(Back);
            dispatcherTimer.Start();
            
        }
    } 
}

