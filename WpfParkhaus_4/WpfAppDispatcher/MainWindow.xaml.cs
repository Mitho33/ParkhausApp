using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
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

namespace WpfAppDispatcher
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Im Image Canvas Background werden alle anderen Canvas eingefügt, entweder mit dem Designer
            //mit XAML oder C# über Children.Add
            //Die Autoteile werden mit Ellipse oder Rectangle erzeugt und in ein Canvas gepackt und mit Alt verbunden
            //oder mit XAML
            InitializeComponent();
            timerAuto = new DispatcherTimer();//Timer-Objekt wird erzeugt
            timerAuto.Interval = TimeSpan.FromMilliseconds(1);//Intervall wird festgelegt
            timerAuto.Tick += TimerAuto_Tick;//
            timerRad = new DispatcherTimer();//Timer-Objekt wird erzeugt
            timerRad.Interval = TimeSpan.FromMilliseconds(1);//Intervall wird festgelegt
            timerRad.Tick += TimerRad_Tick;//Methode, die beschreibt, was bei jedem Tick passiert
                                           //Bike.Visibility = Visibility.Collapsed;
                                           //Auto.Visibility = Visibility.Collapsed;
            Button EinfahrtAuto = new Button();
            EinfahrtAuto.Click += EinfahrtAuto_Click;


        }
        DispatcherTimer timerAuto;//muss außerhalb einer Methode deklariert werden, damit er in allen
        //Methoden zur Verfügung steht
        DispatcherTimer timerRad;
        int counter = 0;
        int counterRad;
        int counterAuto;
        int counterAutoBauen=0;//
        double speedTor = 1;
        double speedAuto = 0;
        double speedFahrrad = 0;
        double linkeSeiteAuto;
        double torHoehe;
        double linkeSeiteBike;

        FensterParkGebuehren fensterParkGebuehren;//Projekt/Fester hinzufügen/Fester(WPF), Achtung richtig benennen!
       // SpeechSynthesizer speechSynthesizer;//Über den Projektexplorer/RMT/Hinzufügen/System.Speech, anschließend Using Anweisung hinzufügen
        Pkw pkw;
        Fahrrad fahrrad;
        public int Counter
        {
            get { return this.counter; }
            set { this.counter = value; }
        }
        //Methode. die Anweisungen enthät, was der Timer macht
        private void TimerAuto_Tick(object sender, EventArgs e)

        {   //Tickanzeige
            counter++;
            LabelTime.Content = counter;

            //Anweisungen für das Tor und Ampel
            torHoehe = Tor.ActualHeight;
            Tor.Height = torHoehe - speedTor;
            if (torHoehe <= 5)//wird nicht genau 5, deshalb <=
            {
                Ampel.Fill = new SolidColorBrush(Colors.Green);
                Tor.Height = 2;
            }

            //Anweisungen zur Positonsbestimmung und Veränderung des Canvas Auto
            linkeSeiteAuto = (double)Auto.GetValue(Canvas.LeftProperty);
            Auto.SetValue(Canvas.LeftProperty, linkeSeiteAuto - speedAuto);


            //Verzweigung mit Anweisungen, wenn Canvas links aus dem  Bild rausgeht
            if ((double)Auto.GetValue(Canvas.LeftProperty) < 200)
            {
                counterAuto++;//Startet bei 0 und jedes Auto, dass in das Parkhaus fährt, führt zu +1
                Bike.Visibility = Visibility.Collapsed;
                Auto.Visibility = Visibility.Collapsed;
                timerAuto.Stop();
                Pause(800);
                Begruessung.Visibility = Visibility.Visible;
                //speechSynthesizer = new SpeechSynthesizer();
                //speechSynthesizer.Speak(" Herzlich Willkommen im Parkhaus Paleet");
                Pause(2000);
                Auto.Visibility = Visibility.Visible;
                Begruessung.Visibility = Visibility.Collapsed;
                Ampel.Fill = new SolidColorBrush(Colors.Red);//Ampel wird rot
                Tor.Height = 160;// und erhält alte Höhe
                Auto.SetValue(Canvas.LeftProperty, linkeSeiteAuto = 532);//Auto geht auf alte Position zurück
                fensterParkGebuehren = new FensterParkGebuehren();
                fensterParkGebuehren.ShowDialog();

            }
            if (counterAuto < 2)
            {
                //Listbox führt alle Items auf, Label überschreibt deshalb Label für Parkhausanzeige
                Belegung.Content = "Frei";
                AnzahlPlaetze.Content = 2 - counterAuto;//startet mit 2 Plätzen
            }

            else
            {
                Belegung.Content = "Belegt";
                AnzahlPlaetze.Content = 2 - counterAuto;
                timerAuto.Stop();

            }
        }

        private void TimerRad_Tick(object sender, EventArgs e)
        {
            counter++;
            LabelTime.Content = counter;

            torHoehe = Tor.ActualHeight;
            Tor.Height = torHoehe - speedTor;
            if (torHoehe <= 5)//wird nicht genau 5, deshalb <=
            {
                Ampel.Fill = new SolidColorBrush(Colors.Green);
                Tor.Height = 2;//Tor bleibt oben, also klein
            }

          
            //Bike.SetValue(Canvas.LeftProperty, linkeSeiteBike = 535);
            linkeSeiteBike = (double)Bike.GetValue(Canvas.LeftProperty);
            Bike.SetValue(Canvas.LeftProperty, linkeSeiteBike - speedFahrrad);

            if ((double)Bike.GetValue(Canvas.LeftProperty) < 225)
            {

                Bike.Visibility = Visibility.Collapsed;
                timerRad.Stop();
                Pause(800);
                Begruessung.Visibility = Visibility.Visible;
                //speechSynthesizer = new SpeechSynthesizer();
                //speechSynthesizer.Speak(" Herzlich Willkommen im Parkhaus Paleet");
                Pause(2000);
                Auto.Visibility = Visibility.Visible;
                Begruessung.Visibility = Visibility.Collapsed;
                Ampel.Fill = new SolidColorBrush(Colors.Red);
                Tor.Height = 160;
                Bike.SetValue(Canvas.LeftProperty, linkeSeiteBike = 555);
                fensterParkGebuehren = new FensterParkGebuehren();
                fensterParkGebuehren.ShowDialog();

            }

        }

        public void Pause(double zeit)//Methode für die Pause, damit die Explosion zu sehen ist
        {
            double zeit1 = System.Environment.TickCount;
            double zeit2;
            do
            {
                zeit2 = System.Environment.TickCount;
                System.Windows.Forms.Application.DoEvents(); //Verweis für System.Windows.Forms hinzufügen, rechte Maustaste Projektexplorer WpfFlappy,
                //Hinzufügen, Verweis, Assemblys, System.Windows.Forms, Häkchen nicht vergessen!
            } while (zeit2 - zeit1 < zeit);
        }

        private void EinfahrtAuto_Click(object sender, RoutedEventArgs e)
        {
            counterAutoBauen++;
            timerAuto.Start();
            AutoBauen();
        }

        private void AutoBauen()

        {
            Bike.Visibility = Visibility.Collapsed;
            Auto.Visibility = Visibility.Visible;


            {
                if (counterAutoBauen == 1)
                {
                    speedAuto = 1;
                    pkw = new Pkw("Oslo");
                    Auto.Children.Add(pkw.Auto6);
                    Auto.Children.Add(pkw.Auto7);
                    Auto.Children.Add(pkw.Auto8);
                    Auto.Children.Add(pkw.Auto9);


                }
                if (counterAutoBauen == 2)
                {

                    speedAuto = 1;
                    pkw = new Pkw("Rudi");
                    Auto.Children.Add(pkw.Auto6);
                    pkw.Auto6.Fill = new SolidColorBrush(Colors.Violet);
                    Auto.Children.Add(pkw.Auto7);
                    pkw.Auto7.Fill = new SolidColorBrush(Colors.Violet);
                    Auto.Children.Add(pkw.Auto8);
                    Auto.Children.Add(pkw.Auto9);

                }
                if (counterAutoBauen == 3)
                {

                    speedAuto = 1;
                    pkw = new Pkw("Rudi");
                    Auto.Children.Add(pkw.Auto6);
                    pkw.Auto6.Fill = new SolidColorBrush(Colors.Yellow);
                    Auto.Children.Add(pkw.Auto7);
                    pkw.Auto7.Fill = new SolidColorBrush(Colors.Yellow);
                    Auto.Children.Add(pkw.Auto8);
                    Auto.Children.Add(pkw.Auto9);
                    counterAutoBauen = 0;

                }
            }
        }
        private void EinFahrt_Click(object sender, RoutedEventArgs e)
        {
           
            timerRad.Start();
            BikeBauen();
        }

        private void BikeBauen()
        {
            speedFahrrad = 1;
            Auto.Visibility = Visibility.Collapsed;
            Bike.Visibility = Visibility.Visible;
            fahrrad = new Fahrrad("hk");
            Bike.Background = fahrrad.BikeBild;
        }



    }
            
        }
    

