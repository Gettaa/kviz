using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

namespace kviz
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public string lang = "hu";
        public Page1()
        {
            InitializeComponent();
        }

        private void methbutton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void biobutton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void infobutton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void nextbutton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void langbutton_Click(object sender, RoutedEventArgs e)
        {
            switch (lang)
            {
                case "hu":
                    lang = "en";
                    Uri eflag = new Uri("pics/enflag.jpeg", UriKind.Relative);
                    ImageBrush Englishflag = new ImageBrush(new BitmapImage(eflag));
                    langbutton.Background = Englishflag;
                    break;
                case "en":
                    Uri dflag = new Uri("pics/deflag.jpeg", UriKind.Relative);
                    ImageBrush Deutschflag = new ImageBrush(new BitmapImage(dflag));
                    langbutton.Background = Deutschflag;
                    lang = "de"; break;
                case "de":
                    Uri hflag = new Uri("pics/huflag.jpeg", UriKind.Relative);
                    ImageBrush Hungflag = new ImageBrush(new BitmapImage(hflag));
                    langbutton.Background = Hungflag;
                    lang = "hu"; break;
            }
        }
    }
}
