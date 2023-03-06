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
        string text = String.Empty;
        public WindowKpd()
        {
            InitializeComponent();
            //[ !#$%&'()*+,-/:;<=>?^_]
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


            int h;
            int w;
            for (int i = 0; i < text.Length; i++)
            {
                int margin = 40;
                int v = rnd.Next(3);
                if (v == 0)
                {
                    int font = rnd.Next(16, 25);
                    // h = rnd.Next((int)canv.Height - 70);
                    // w = rnd.Next((int)canv.Width - 70);
                    TextBlock textBlock = new TextBlock()
                    {
                        Text = text[i].ToString(),
                        FontSize = font,
                        FontStyle = FontStyles.Italic,
                        Margin = new Thickness(i * 25, rnd.Next(50), rnd.Next(50), 0),
                        //Padding = new Thickness(i * 20, rnd.Next(70), rnd.Next(150), 0),
                    };
                    canv.Children.Add(textBlock);
                }
                else if (v == 1)
                {
                    int font = rnd.Next(16, 30);
                    //h = rnd.Next((int)canv.Height - 10);
                    //w = rnd.Next((int)canv.Width - 10);
                    TextBlock textBlock = new TextBlock()
                    {
                        Text = text[i].ToString(),
                        FontSize = font,
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(i * 25, rnd.Next(50), rnd.Next(50), 0),
                        //Padding = new Thickness(i * 20, rnd.Next(70), rnd.Next(150), 0),
                    };
                    canv.Children.Add(textBlock);
                }
                else if (v == 2)
                {
                    int font = rnd.Next(16, 30);
                    // h = rnd.Next((int)canv.Height - 10);
                    //w = rnd.Next((int)canv.Width - 10);
                    TextBlock textBlock = new TextBlock()
                    {
                        Text = text[i].ToString(),
                        FontSize = font,
                        FontWeight = FontWeights.Bold,
                        FontStyle = FontStyles.Italic,
                        Margin = new Thickness(i*25, rnd.Next(50), rnd.Next(50), 0),
                        //Padding = new Thickness(i * 20, rnd.Next(70), rnd.Next(150), 0),
                    };
                    canv.Children.Add(textBlock);
                }

            }

        }

        private void buttonCaptcha_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
