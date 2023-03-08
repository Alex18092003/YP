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
        public int v;
        public int v2;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Windows.WindowKpd windowKpd = new Windows.WindowKpd();
        string kod;
        string kod1;
        bool ss = false;

        public PageAuthorization()
        {
            InitializeComponent();
          
        }
        

        public PageAuthorization(int kk, string kod)
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
                kod1 = kod;
                v2 = v;
            }
        }

        public PageAuthorization(int kk, string kod, int v)
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
                kod1 = kod;
                v2 = v;
                v2++;
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
                   
                    windowKpd.ShowDialog();
                    kk = employees.id_role;
                    kod = windowKpd.text;

                    Classes.ClassFrame.frame.Navigate(new PageAuthorization(kk, kod));
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
                textboxKod.Text = "";
                btnRepeat.IsEnabled = true;
                burronEntrance.IsEnabled = false;
                
            } 
            else
            {
                TextClue.Text = "Таймер: " + timer;
                burronEntrance.IsEnabled = true;
            }
            timer--;
        }

        private void textboxKod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Roles roles = Classes.ClassBase.entities.Roles.FirstOrDefault(x => x.id_role == kk2);
                //MessageBox.Show($"{kod1}", "Сообщение");
                if (textboxKod.Text == kod1)
                {
                    MessageBox.Show($"Поздравляю вы авторизировались!\nВаша роль {roles.role}", "Сообщение");
                    textboxKod.IsEnabled = false;
                    textboxPassword.IsEnabled = false;
                    textboxNomer.IsEnabled = false;
                    btnRepeat.IsEnabled = false;
                    buttonCancel.IsEnabled = false;
                    burronEntrance.IsEnabled = false;
                    dispatcherTimer.Stop();
                    TextClue.Text = "";
                    textboxKod.Text = "";
                }
                else
                {
                    textboxPassword.IsEnabled = false;
                    textboxNomer.IsEnabled = false;
                    burronEntrance.IsEnabled = false;
                    MessageBox.Show("Неверный код", "Сообщение");
                }
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
            TextClue.Text = "";
        }

        
        private void btnRepeat_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (v2 != 1)
            {
                Windows.WindowKpd windowKpd = new Windows.WindowKpd();
            windowKpd.ShowDialog();
            v = windowKpd.v;
                //kk = employees.id_role;
                kod = windowKpd.text;
                Classes.ClassFrame.frame.Navigate(new PageAuthorization(kk2, kod, v2));
          
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(Back);
            dispatcherTimer.Start();
            }
            else
            {
                MessageBox.Show("Закончились попытки", "Сообщение");
                textboxKod.IsEnabled = false;
                btnRepeat.IsEnabled = false;
                buttonCancel.IsEnabled = false;
                burronEntrance.IsEnabled = false;
            }
        }


        private void burronEntrance_Click(object sender, RoutedEventArgs e)
        {
            Roles roles = Classes.ClassBase.entities.Roles.FirstOrDefault(x => x.id_role == kk2);
            if (textboxKod.Text == kod1)
            {
                MessageBox.Show($"Поздравляю вы авторизировались!\nВаша роль {roles.role}", "Сообщение");
                textboxKod.IsEnabled = false;
                textboxPassword.IsEnabled = false;
                textboxNomer.IsEnabled = false;
                dispatcherTimer.Stop();
                TextClue.Text = "";
                textboxKod.Text = "";
            }
            else
            {
                textboxPassword.IsEnabled = false;
                textboxNomer.IsEnabled = false;
                MessageBox.Show("Неверный код", "Сообщение");
            }
        }
    } 
}
