using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230402_1_GenelAlistirma
{
    public static class Menu
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        public static void Islemler(ConsoleKey key)
        {
            bool elemanVar = Metodlar.ListedeEleman(ogrenciler);
            Console.Clear();
            if (elemanVar || key == ConsoleKey.D0 || key == ConsoleKey.NumPad0 || key == ConsoleKey.NumPad1 || key == ConsoleKey.D1)
            {
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Ekle("Öğrenci Ekle");   
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Listele("Öğrencileri Listele");
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Sil("Öğrenci Sil");
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        NotOrtalamasi("Öğrencilerin Genel Not Ortalaması");
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        YasOrtalamasi("Öğrencilerin Yaş Ortalaması");
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        BaslikYazdir("Toplam Öğrenci Sayısı");
                        AnaMenuyeDon(string.Format("Toplam {0} adet öğrenci kayıtlıdır.", ogrenciler.Count));
                        break;
                }
            }
            else
            {
                AnaMenuyeDon("Tuşladığınız sayıya dair bir menü yok...");
            }
        }

        private static void YasOrtalamasi(string v)
        {
            BaslikYazdir(v);
            int toplamYas = 0;
            foreach (var ogrenci in ogrenciler)
            {
                toplamYas += ogrenci.Yas;
            }
            double yasOrtalamasi = toplamYas / ogrenciler.Count;
            AnaMenuyeDon(string.Format("{0} öğrencinin yaş ortalaması: {1}", ogrenciler.Count, Math.Round(yasOrtalamasi, 2)));
        }

        private static void NotOrtalamasi(string v)
        {
            BaslikYazdir(v);
            double genelToplam = 0;
            foreach (var ogrenci in ogrenciler)
            {
                genelToplam += ogrenci.Ortalama;
            }
            double genelNotOrtalamasi = genelToplam / ogrenciler.Count;
            AnaMenuyeDon(string.Format("{0} adet öğrencinin genel not ortalaması: {1}", ogrenciler.Count, Math.Round(genelNotOrtalamasi, 2)));
        }

        private static void Sil(string v)
        {
            BaslikYazdir(v);
            for (int i = 0; i < ogrenciler.Count; i++)
            {
                ogrenciler[i].Yazdir(i + 1);
            }
            Console.WriteLine();
            int siraNo = Metodlar.GetInt("Silmek istediğiniz öğrencinin sıra numarasını giriniz.\nAna menüye dönmek için 0'a basınız: ", 0, ogrenciler.Count);
            if (siraNo == 0)
            {
                AnaMenuyeDon("Silme işlemi iptal edildi");
            }
            else
            {
                int indexNo = siraNo- 1;
                Console.Write(ogrenciler[indexNo].TamAd + " öğrencisini silmek istediğinize emin misiniz?(e): ");
                if (Console.ReadKey().Key == ConsoleKey.E)
                {
                    string silinen = ogrenciler[indexNo].TamAd;
                    ogrenciler.RemoveAt(indexNo);
                    AnaMenuyeDon(string.Format("{0} isimli öğrenci başarı ile silindi", silinen));
                }
                else
                {
                    AnaMenuyeDon("Silme işlemi iptal edildi");
                }
            }
        }

        private static void Listele(string v)
        {
            BaslikYazdir(v);
            for (int i = 0; i < ogrenciler.Count; i++)
            {
                ogrenciler[i].Yazdir(i + 1);
            }
            AnaMenuyeDon(string.Format("Toplam {0} adet öğrenci listelenmiştir.", ogrenciler.Count));
        }

        private static void Ekle(string v)
        {
            BaslikYazdir(v); 
            Ogrenci o = new Ogrenci();
            o.Ad = Metodlar.GetString("Öğrenci Adı: "); 
            o.Soyad = Metodlar.GetString("Öğrenci Soyadı: ", 2, 15);
            o.N1 = Metodlar.GetDouble("1. Not: ", 0,100);
            o.N2 = Metodlar.GetDouble("2. Not: ", 0, 100);
            o.DogumTarihi = Metodlar.GetDateTime("Doğum Tarihi: ", 1973, 2013);
            ogrenciler.Add(o);
            AnaMenuyeDon(string.Format("{0} öğrencisi başarı ile listeye eklendi", o.TamAd));
        }

        private static void AnaMenuyeDon(string v)
        {
            Console.WriteLine();
            Console.WriteLine(v);
            Console.WriteLine("Ana menüye dönmek için bir tuşa basınız");
            Console.ReadKey();
        }

        private static void BaslikYazdir(string v)
        {
            Console.WriteLine(v);
            Console.WriteLine("-------------------------");
            Console.WriteLine();
        }
    }
}
