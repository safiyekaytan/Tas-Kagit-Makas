using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace WinFormsApp4
{



    //ana class nesneler olusturuldu
    abstract class Nesneler
    {
        public double dayaniklilik;
        public int seviye_puani;
        public Nesneler(double dayaniklilik, int seviye_puani)
        {
            this.Dayaniklilik = dayaniklilik;
            this.Seviye_puani = seviye_puani;
        }

        public double Dayaniklilik { get => dayaniklilik; set => dayaniklilik = value; }

        public int Seviye_puani { get => seviye_puani; set => seviye_puani = value; }

        public double getDayaniklik()
        {
            return dayaniklilik;
        }

        public int getSeviye_puani()
        {
            return seviye_puani;
        }

        public abstract double etkiHesapla(string a, double b, double c);

        public abstract void durumGuncelle(double hit, int win);




    }

    //ikinci class makas
    class Makas : Nesneler
    {
        public double keskinlik;
        public double etki;
        public string tur;

        public Makas(double keskinlik, double dayaniklilik, int seviye_puani, string tur) : base(dayaniklilik, seviye_puani)
        {
            this.Keskinlik = keskinlik;
            this.tur = tur;
        }

        public double Keskinlik { get => keskinlik; set => keskinlik = value; }
        public double getKeskinlik()
        {
            return keskinlik;
        }

        public double getGuc()
        {
            return keskinlik;
        }

        public double getOzelguc()
        {
            return 1.0;
        }

        public string Tur { get => tur; set => tur = value; }

        public string getTur()
        {
            return tur;
        }
        public override double etkiHesapla(string tur, double guc, double ozelguc)
        {

            if (tur == "tas")
            {
                etki = (keskinlik) / (0.8 * guc);
            }
            else if (tur == "kagit")
            {
                etki = (keskinlik) / (0.2 * guc);
            }
            else if (tur == "makas")
            {
                etki = (keskinlik) / (0.8 * guc);

            }
            else if (tur == "agirtas")
            {
                etki = (keskinlik) /( 0.8 * guc * ozelguc);
            }
            else if (tur == "ozelkagit")
            {
                etki = (keskinlik) / (0.2 * guc * ozelguc);
            }
            else if (tur == "keskinmakas")
            {
                etki = (keskinlik) / (0.2 * guc * ozelguc);

            }


            return etki;



        }

        public override void durumGuncelle(double hit, int win)
        {
            dayaniklilik -= hit;

            if (dayaniklilik < 0)
            {
                dayaniklilik = 0;
            }

            if (win == 1)
            {
                seviye_puani += 20;
            }

        }
    }

    class Usta_makas : Makas
    {
        public double direnc;


        public Usta_makas(double direnc, double keskinlik, double dayaniklilik, int seviye_puani, string tur) : base(keskinlik, dayaniklilik, seviye_puani, tur)
        {
            this.Direnc = direnc;
        }

        public double Direnc { get => direnc; set => direnc = value; }

        public double getDirenc()
        {
            return direnc;
        }

        public new double getOzelguc()
        {
            return direnc;
        }


        public override double etkiHesapla(string tur, double guc, double ozelguc)
        {

            if (tur == "tas")
            {
                etki = (keskinlik * direnc) /( 0.8 * guc);
            }
            else if (tur == "kagit")
            {
                etki = (keskinlik * direnc) / (0.2 * guc);
            }
            else if (tur == "makas")
            {
                etki = (keskinlik * direnc) / (0.2 * guc);
            }
            else if (tur == "agirtas")
            {
                etki = (keskinlik * direnc) / (0.8 * guc * ozelguc);
            }
            else if (tur == "ozelkagit")
            {
                etki = (keskinlik * direnc) / (0.2 * guc * ozelguc);
            }
            else if (tur == "keskinmakas")
            {
                etki = (keskinlik * direnc) / (0.8 * guc * ozelguc);
            }

            return etki;

        }


        public override void durumGuncelle(double hit, int win)
        {
            dayaniklilik -= hit;
            if (dayaniklilik < 0)
            {
                dayaniklilik = 0;
            }

           

            if (win == 1)
            {
                seviye_puani += 20;
            }

        }
    }

    //ucuncu class kagit

    class Kagit : Nesneler
    {

        public double nufuz;
        public string tur;
        public Kagit(double nufuz, double dayaniklilik, int seviye_puani, string tur) : base(dayaniklilik, seviye_puani)
        {
            this.Nufuz = nufuz;
            this.tur = tur;
        }

        public double Nufuz { get => nufuz; set => nufuz = value; }
        public string Tur { get => tur; set => tur = value; }

        public double getNufuz()
        {
            return nufuz;
        }

        public double getGuc()
        {
            return nufuz;
        }

        public double getOzelguc()
        {
            return 1.0;
        }

        public string getTur()
        {
            return tur;
        }

        public double etki;
        public override double etkiHesapla(string tur, double guc, double ozelguc)
        {

            if (tur == "tas")
            {
                etki = (nufuz) / (0.2 * guc);
            }
            else if (tur == "kagit" )
            {
                etki = (nufuz) / (0.8 * guc );
            }
            else if (tur == "makas" )
            {
                etki = (nufuz) / (0.8 * guc);

            }
            else if(tur == "agirtas")
            {
                etki = (nufuz) / (0.2 * guc * ozelguc);
            }
            else if(tur == "ozelkagit")
            {
                etki = (nufuz) / (0.2 * guc * ozelguc);
            }
            else if(tur == "keskinmakas")
            {
                etki = (nufuz) / (0.8 * guc * ozelguc);
            }
            return etki;

        }

        public override void durumGuncelle(double hit, int win)
        {
            dayaniklilik -= hit;
            if (dayaniklilik < 0)
            {
                dayaniklilik = 0;
            }

           

            if (win == 1)
            {
                seviye_puani += 20;
            }

        }
    }

    class Ozel_kagit : Kagit
    {
        public double kalinlik;
        public Ozel_kagit(double kalinlik, double nufuz, double dayaniklilik, int seviye_puani, string tur) : base(nufuz, dayaniklilik, seviye_puani, tur)
        {
            this.Kalinlik = kalinlik;
        }

        public double Kalinlik { get => kalinlik; set => kalinlik = value; }

        public double getKalinlik()
        {
            return kalinlik;
        }

        public new double getOzelguc()
        {
            return kalinlik;
        }

        public override double etkiHesapla(string tur, double guc, double ozelguc)
        {

            if (tur == "tas" )
            {
                etki = (nufuz * kalinlik) / (0.2 * guc );
            }
            else if (tur == "kagit")
            {
                etki = (nufuz * kalinlik) / (0.2 * guc);
            }
            else if (tur == "makas" )
            {
                etki = (nufuz * kalinlik) / (0.8 * guc );

            }
            else if(tur == "agirtas")
            {
                etki = (nufuz * kalinlik) / (0.2 * guc * ozelguc);
            }
            else if (tur == "ozelkagit")
            {
                etki = (nufuz * kalinlik) / (0.8 * guc * ozelguc);

            }
            else if (tur == "keskinmakas")
            {
                etki = (nufuz * kalinlik) / (0.8 * guc * ozelguc);

            }
            return etki;

        }
        public override void durumGuncelle(double hit, int win)
        {
            dayaniklilik -= hit;
            if (dayaniklilik < 0)
            {
                dayaniklilik = 0;
            }



            if (win == 1)
            {
                seviye_puani += 20;
            }

        }
    }

    //dorduncu class tas
    class Tas : Nesneler
    {

        public double katilik;
        public string tur;
        public Tas(double katilik, double dayaniklilik, int seviye_puani, string tur) : base(dayaniklilik, seviye_puani)
        {
            this.Katilik = katilik;
            this.tur = tur;

        }

        public double Katilik { get => katilik; set => katilik = value; }
        public string Tur { get => tur; set => tur = value; }
        public double getKatilik()
        {
            return katilik;
        }

        public double getGuc()
        {
            return katilik;
        }
        public double getOzelguc()
        {
            return 1.0;
        }
        public string getTur()
        {
            return tur;
        }

        public double etki;
        public override double etkiHesapla(string tur, double guc, double ozelguc)
        {

            if (tur == "tas" )
            {
                etki = (katilik) / (0.8 * guc );
            }
            else if (tur == "kagit" )
            {
                etki = (katilik) / (0.8 * guc );
            }
            else if (tur == "makas" )
            {
                etki = (katilik) / (0.2 * guc);

            }
            else if (tur == "agirtas" )
            {
                etki = (katilik) / (0.2 * guc * ozelguc);

            }
            else if (tur == "ozelkagit")
            {
                etki = (katilik) / (0.8 * guc * ozelguc);

            }
            else if (tur == "keskinmakas")
            {
                etki = (katilik) / (0.2 * guc * ozelguc);

            }

            return etki;

        }

        public override void durumGuncelle(double hit, int win)
        {
            dayaniklilik -= hit;
            if (dayaniklilik < 0)
            {
                dayaniklilik = 0;
            }

      
            if (win == 1)
            {
                seviye_puani += 20;
            }

        }
    }

    class Agir_tas : Tas
    {
        public double sicaklik;
        public Agir_tas(double sicaklik, double katilik, double dayaniklilik, int seviye_puani, string tur) : base(katilik, dayaniklilik, seviye_puani, tur)
        {
            this.Sicaklik = sicaklik;

        }

        public double Sicaklik { get => sicaklik; set => sicaklik = value; }

        public double getSicaklik()
        {
            return sicaklik;
        }
        public new double getOzelguc()
        {
            return sicaklik;
        }

        public override double etkiHesapla(string tur, double guc, double ozelguc)
        {

            if (tur == "tas")
            {
                etki = (katilik*sicaklik) / (0.8 * guc);
            }
            else if (tur == "kagit")
            {
                etki = (katilik * sicaklik) / (0.8 * guc);
            }
            else if (tur == "makas")
            {
                etki = (katilik * sicaklik) / (0.2 * guc);

            }
            else if (tur == "agirtas")
            {
                etki = (katilik * sicaklik) / (0.8 * guc * ozelguc);

            }
            else if (tur == "ozelkagit")
            {
                etki = (katilik * sicaklik) / (0.8 * guc * ozelguc);

            }
            else if (tur == "keskinmakas")
            {
                etki = (katilik * sicaklik) / (0.2 * guc * ozelguc);

            }

            return etki;

        }
        public override void durumGuncelle(double hit, int win)
        {
            dayaniklilik -= hit;
            if (dayaniklilik < 0)
            {
                dayaniklilik = 0;
            }



            if (win == 1)
            {
                seviye_puani += 20;
            }

        }
    }

    abstract public class Oyuncu
    {
        public string oyuncuID;
        public string oyuncuAdi;
        public int skor;
        
         public string OyuncuID { get => oyuncuID; set => oyuncuID = value; }
        public string OyuncuAdi { get => oyuncuAdi; set => oyuncuAdi = value; }
        public int Skor { get => skor; set => skor = value; }

        public Oyuncu(string oyuncuID, string oyuncuAdi,int skor)
        {
            this.OyuncuID = oyuncuID;
            this.OyuncuAdi = oyuncuAdi;
            this.Skor = skor;
        }
       

       
        public int skor_goster()
        {
            return skor;
        }

        public abstract void nesneSec();

    }


    public class Bilgisayar : Oyuncu
    {
        public Bilgisayar(string oyuncuID, string oyuncuAdi, int skor) : base(oyuncuID, oyuncuAdi, skor)
        {

        }
        public override void nesneSec()
        {

        }

        public static void SkorGoster()
        {

        }
    }

    public class Kullanici : Oyuncu
    {
        public Kullanici(string oyuncuID, string oyuncuAdi, int skor) : base(oyuncuID, oyuncuAdi, skor)
        {

        }

        public override void nesneSec()
        {
            Form5 form5 = new Form5();
            form5.Show();

        }
    }


    internal static class App
    {


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }

    }



}







