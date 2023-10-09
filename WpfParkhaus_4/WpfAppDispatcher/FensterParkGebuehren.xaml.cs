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

namespace WpfAppDispatcher
{
    /// <summary>
    /// Interaktionslogik für FensterParkGebuehren.xaml
    /// </summary>
    public partial class FensterParkGebuehren : Window
    {
        public FensterParkGebuehren()
        {
            InitializeComponent();

        }

        Pkw pkw;
        Fahrrad fahrrad;
        int zeit;
        MainWindow mainWindow;//Variable für Objekt aus MainWindow, nämlich Pause wird erzeugt

        private void Ticket_Click(object sender, RoutedEventArgs e)

        {if (RbBike.IsChecked==true)

            {
                zeit = 8;
                fahrrad = new Fahrrad(TxtKennzeichen.Text);
                fahrrad.FahrradBerechnen(zeit);
                Parkticket.Items.Add(TxtKennzeichen.Text);
                Parkticket.Items.Add(fahrrad.GebuehrRad);
                mainWindow = new MainWindow();
                mainWindow.Pause(1800);
                this.Close();
            }

                if (Kiss.IsChecked == true)

                {
                    zeit = 9;
                }

                if (Sixty.IsChecked == true)

                {
                    zeit = 60;
                }

                if (HundertAndTwenty.IsChecked == true)

                {
                    zeit = 120;
                }

                if (Day.IsChecked == true)

                {
                    zeit = 121;
                }

                
                pkw = new Pkw(TxtKennzeichen.Text);               
                pkw.Berechnung(zeit);
            Parkticket.Items.Add(TxtKennzeichen.Text);
            Parkticket.Items.Add(pkw.Parkgebuehr);
                mainWindow = new MainWindow();
             mainWindow.Pause(1800);
                this.Close();
        }
    }
}
