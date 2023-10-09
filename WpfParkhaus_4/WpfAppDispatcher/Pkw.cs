using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfAppDispatcher
{
    class Pkw
    {
        //jedes Auto hat die Attribute/Eigenschaften:
        private string parkGebuehr;
        Rectangle auto6;//Boden
        Rectangle auto7;//Dach
      Ellipse auto8;//Reifen vorne
     Ellipse auto9;//Reifen hinten
        public Rectangle Auto6
        {
            get { return this.auto6; }
            set { this.auto6 = value; }
        }
        public Rectangle Auto7
        {
            get { return this.auto7; }
            set { this.auto7 = value; }
        }
        public Ellipse Auto8
        {
            get { return this.auto8; }
            set { this.auto8 = value; }
        }
        public Ellipse Auto9
        {
            get { return this.auto9; }
            set { this.auto9 = value; }
        }
        public string Parkgebuehr
        {
            get { return this.parkGebuehr; }
            set { this.parkGebuehr = value; }
        }


        public Pkw(string kennzeichen)//virual notwendig, damit bei Vererbung override funktioniert
        //Konstruktor der Klasse Auto,mit dem Übergabeparameter Kennzeichen
        {
           
                    Auto6 = new Rectangle();
                    Auto6.Height = 34;
                    Auto6.Width = 158;
                    Auto6.Fill = new SolidColorBrush(Colors.Red);
                    Canvas.SetTop(Auto6, 42);


                    Auto7 = new Rectangle();
                    Auto7.Height = 34;
                    Auto7.Width = 59;
                    Auto7.Fill = new SolidColorBrush(Colors.Red);
                    Canvas.SetTop(Auto7, 8);
                    Canvas.SetLeft(Auto7, 43);

                    Auto8 = new Ellipse();
                    Auto8.Height = 28;
                    Auto8.Width = 28;
                    Auto8.Fill = new SolidColorBrush(Colors.Black);
                    Canvas.SetTop(Auto8, 62);
                    Canvas.SetLeft(Auto8, 22);

                    Auto9 = new Ellipse();
                    Auto9.Height = 28;
                    Auto9.Width = 28;
                    Auto9.Fill = new SolidColorBrush(Colors.Black);
                    Canvas.SetTop(Auto9, 62);
                    Canvas.SetLeft(Auto9, 106);
                }
    public virtual void Berechnung(int parkDauer)//Virtual notwendig für override bei Fahhrad
        {          
            if (parkDauer < 10)
            {
                parkGebuehr = "park and kiss " + 0 + " Euro";
            }

            else if (parkDauer > 10 && parkDauer < 61)

            {
                parkGebuehr = 10 + " Euro";

            }
            else if (parkDauer > 60 && parkDauer < 121)
            {
                parkGebuehr = 15 + " Euro";
            }

            else if(parkDauer>120)
            {
                parkGebuehr = 35 + " Euro";
            }
        }
    }
}

