using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230402_1_GenelAlistirma
{
    public static class Metodlar
    {
        public static string GetString(string metin, int min = 2, int max = 20)
        {
            string txt = string.Empty;
            bool hata = false;
            do
            {
                Console.Write(metin);
                txt = Console.ReadLine();
                if (string.IsNullOrEmpty(txt))
                {
                    Console.WriteLine("Boş bir değer giremezsiniz");
                    hata = true;
                }
                else
                {
                    if (txt.Length < min || txt.Length > max)
                    {
                        Console.WriteLine("Lütfen min. {0}, max. {1} uzunlukta metin giriniz",min,max);
                        hata = true;
                    }
                    else
                    {
                        int sayac = 0;
                        foreach (var item in txt) // Ahm3t
                        {
                            try
                            {
                                int.Parse(Char.ToString(item));
                                // Convert.ToInt32(Char.ToString(item));
                                sayac++;
                            }
                            catch
                            {
                            }
                        }
                        if (sayac > 0)
                        {
                            Console.WriteLine("Lütfen sayısal bir değer kullanmayınız");
                            hata = true;
                        }
                        else
                        {
                            hata = false;
                        }
                    }
                }
            } while (hata);
            return txt; 
        }

        
        public static int GetInt(string metin, int min = int.MinValue, int max = int.MaxValue)
        {
            int sayi = 0;
            bool hata = false;
            do
            {
                Console.Write(metin);
                try
                {
                    sayi = int.Parse(Console.ReadLine());
                    if (sayi >= min && sayi <= max)
                    {
                        hata = false;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen {0} ile {1} arasında bir değer giriniz", min,max);
                        hata = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    hata = true;
                }
            } while (hata);
            return sayi;
        }

        public static double GetDouble(string metin, double min = double.MinValue, double max = double.MaxValue)
        {
            double sayi = 0;
            bool hata = false;
            do
            {
                Console.Write(metin);
                try
                {
                    sayi = double.Parse(Console.ReadLine());
                    if (sayi >= min && sayi <= max)
                    {
                        hata = false;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen {0} ile {1} arasında bir değer giriniz", min,max);
                        hata = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    hata = true;
                }
            } while (hata);
            return sayi;
        }

        public static DateTime GetDateTime (string metin, int minYear, int maxYear)
        {
            DateTime date = DateTime.Now;
            bool hata = false;
            do
            {
                Console.Write(metin); 
                try
                {
                    date = DateTime.Parse(Console.ReadLine());
                    if (date.Year <= maxYear && date.Year >= minYear)
                    {
                        hata = false;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen {0} ile {1} yılları arasında bir tarih giriniz", minYear,maxYear);
                        hata = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    hata = true;
                }
            } while (hata);
            return date;
        }

        public static bool ListedeEleman(List<Ogrenci> ogrenci)
        {
            // Koleksiyonlar içerisinde bulunan Any() metodu koleksiyon içerisinde öğe var mı? yok mu? sorgulamasını yapar. Geriye bool tipinde değer döndürür. Var ise "true" yok ise "false" değeri döner.
            if (ogrenci.Any())
                return true;
            else
                return false;
        }
    }
}
