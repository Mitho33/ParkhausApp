using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfAppDispatcher
{
    class Fahrrad : Pkw
    {
        //Bildpimsel und Container für Bilder werden aus den entsprechenden Klassen erzeugt
        private ImageBrush bikeBild = new ImageBrush();//Bilder müssen in Ordner bin/debug sein für Uri
        string gebuehrRad;

        public ImageBrush BikeBild//Variable für Image wird deklariert
        {
            get { return this.bikeBild; }
            set { this.bikeBild = value; }
        }

        public string GebuehrRad
        {
            get { return this.gebuehrRad; }
            set { this.gebuehrRad = value; }
        }

        public Fahrrad(string kennzeichen)//Neuer Konstruktor
        : base(kennzeichen)//Konstrukitonsaufgabe wird an Basisklasse abgegeben
        {
            bikeBild.ImageSource = new BitmapImage(new Uri(@"rad_paint.png", UriKind.Relative));
            //neues Bild wird zugewiesen, muss und bin/debug abgespeichert sein
            //Deshalb  sind hier keine Attribute notwendig, es sind ja bereits welche in der Basisklassen
            //hier werden neue eingesetzt
        }

 
        //public override void Berechnung(int parkDauer)
        //{
        //    this.FahrradBerechnen(8);//neue Methode
        //    base.Berechnung(8);//
      //    //Override überschreibt Methode, die ist dann auch für Pkw überschrieben oder wie
        //}

        public void FahrradBerechnen(int parkDauer)
        {
            if (parkDauer ==8)
            {
               gebuehrRad   =  0 + " Euro";//
            }

        }

    }
}
