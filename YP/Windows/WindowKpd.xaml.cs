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

namespace YP.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowKpd.xaml
    /// </summary>
    public partial class WindowKpd : Window
    {
        public string text = String.Empty;
        public int v =0;

        public WindowKpd()
        {
            InitializeComponent();  
            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                Line line = new Line()
                {
                    X1 = rnd.Next((int)canv.Width),
                    Y1 = rnd.Next((int)canv.Height),
                    X2 = rnd.Next((int)canv.Width),
                    Y2 = rnd.Next((int)canv.Height),
                    Stroke = brush,
                };
                canv.Children.Add(line);
            }

           
            text = String.Empty;
            string chars = "abcdefghijklmnopqrstuvwxyzQWERTYUIOPASDFGHJKLZXCVBNM0123456789[]!@#$%^&*()_-=+№;:?";
            for (int i = 0; i < 8; i++)
            {
                text += chars[rnd.Next(chars.Length)];

            }

            for (int i = 0; i < text.Length; i++)
            {
                int margin = 40;
                int v = rnd.Next(3);
                if (v == 0)
                {
                    int font = rnd.Next(16, 20);
                    
                    TextBlock textBlock = new TextBlock()
                    {
                        Text = text[i].ToString(),
                        FontSize = font,
                        FontStyle = FontStyles.Italic,
                        Margin = new Thickness(i * 35, rnd.Next(50), rnd.Next(50), 0),
                       
                    };
                    canv.Children.Add(textBlock);
                }
                else if (v == 1)
                {
                    int font = rnd.Next(16, 25);
                   
                    TextBlock textBlock = new TextBlock()
                    {
                        Text = text[i].ToString(),
                        FontSize = font,
                     
                        Margin = new Thickness(i * 35, rnd.Next(50), rnd.Next(50), 0),
                      
                    };
                    canv.Children.Add(textBlock);
                }
                else if (v == 2)
                {
                    int font = rnd.Next(16, 25);
                   
                    TextBlock textBlock = new TextBlock()
                    {
                        Text = text[i].ToString(),
                        FontSize = font,
                        FontWeight = FontWeights.Bold,
                        FontStyle = FontStyles.Italic,
                        Margin = new Thickness(i*35, rnd.Next(50), rnd.Next(50), 0),
                       
                    };
                    canv.Children.Add(textBlock);
                }

            }

        }

        private void buttonCaptcha_Click(object sender, RoutedEventArgs e)
        {
            v = 1;
            //MessageBox.Show($"{text}", "Сообщение");
            this.Close();
        }
    }
}
