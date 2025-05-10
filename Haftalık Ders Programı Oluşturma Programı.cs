using System;

namespace ConsoleApp1
{
    class String
    {
        public static int KelimeSayisi(string s)
        {
            int sayi = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    sayi++;
                }
            }
            return sayi + 1;
        }

        public static string InciKelime(string s, int x)
        {
            int sayi = 0;
            string s1 = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    sayi++;
                }
                else if (sayi == x - 1)
                {
                    s1 += s[i];
                }
            }
            return s1;
        }
    }
    class Tablo
    {
        static int satir = 30, sutun = 99;
        static char[,] tablo = new char[satir, sutun];

        static bool Ifkosuluolustur(params int[] a) //a[0] for sayacının değeri,a[1] aralarındaki katlı oran, 
        {                                              //a[2] başlangıç sayısı,a[3] bitiş

            for (int i = 0; i < ((a[3] - a[1]) / a[1]) + 1; i++)
            {
                if ((a[0]) == a[2] + (a[1] * i) - 1)
                {
                    return true;
                }
            }
            return false;
        }

        public void Tabloyazdir()
        {
            for (int i = 0; i < tablo.GetLength(0); i++)
            {
                for (int j = 0; j < tablo.GetLength(1); j++)
                {
                    Console.Write(tablo[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Yazdir(string yazi, int i, int j)
        {


            for (int k = 0; k < yazi.Length; k++)
            {
                tablo[i, j + k] = yazi[k];
            }
        }

        static int Hizala(string s, int a)
        {
            int hiza = 9 + 18 * a + (18 - s.Length) / 2;
            return hiza;
        }

        public void TabloOlusturma()
        {

            // kullanılacak şekiller:  ╔ ╦ ╗  ╠ ╬ ╣  ╚ ╩ ╝  ═ ║ 
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {

                    if (i == 0)
                    {
                        if (j == 0)
                            tablo[i, j] = '╔';

                        else if (j == (sutun - 1))
                            tablo[i, j] = '╗';

                        else
                            tablo[i, j] = '═';

                    }

                    else if (i == (satir - 1))
                    {
                        if (j == 0)
                            tablo[i, j] = '╚';

                        else if (j == (sutun - 1))
                            tablo[i, j] = '╝';

                        else
                            tablo[i, j] = '═';
                    }

                    else
                    {
                        if (j == 0)
                            tablo[i, j] = '║';

                        else if (j == (sutun - 1))
                            tablo[i, j] = '║';

                        else
                        {
                            tablo[i, j] = ' ';
                        }

                    }

                    if (Ifkosuluolustur(i, 3, 3, 27))
                    {
                        if (j == 0)
                            tablo[i, j] = '╠';

                        else if (j == (sutun - 1))
                            tablo[i, j] = '╣';

                        else
                            tablo[i, j] = '═';
                    }

                    if (Ifkosuluolustur(j, 18, 9, 99))
                    {

                        if (i == 0)
                            tablo[i, j] = '╦';

                        else if (i == (satir - 1))
                            tablo[i, j] = '╩';

                        else
                            tablo[i, j] = '║';


                        if (Ifkosuluolustur(i, 3, 3, 27))
                            tablo[i, j] = '╬';

                    }
                }
            }

            int saat = 8;
            for (int i = 0; i < satir; i++)
            {
                if (Ifkosuluolustur(i, 3, 4, 28))
                {
                    if (saat < 18)
                    {
                        Yazdir(Convert.ToString(saat++), i, 2);
                        Yazdir(Convert.ToString(saat), i + 1, 2);
                        Yazdir(":30", i, 4);
                        Yazdir(":20", i + 1, 4);
                    }

                }

            }
            string[] gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" };
            for (int i = 0; i < gunler.Length; i++)
            {
                Yazdir(gunler[i], 1, Hizala(gunler[i], i));
            }

        }

        public void Bilgialma()
        {
            Console.Write("Kaç ders var?: ");
            int dersSayisi = Convert.ToInt32(Console.ReadLine());
            int[,,] ders = new int[dersSayisi, 2, 3]; // ders kodu, ders günü, ders başlanıgıç ve bitiş saati
            string[] dersIsim = new string[dersSayisi];
            for (int i = 0; i < dersSayisi; i++)
            {
                Console.Write("{0}. dersin adı: ", (i + 1));
                do
                {
                    dersIsim[i] = Console.ReadLine();
                    if (dersIsim[i].Length > 34)
                    {
                        Console.WriteLine("Dersin ismini kısaltınız");
                    }
                } while ((dersIsim[i].Length > 34));

                Console.Write("{0} dersi hangi gün ? (Pzt:1, Sal:2, Çar:3, Per:4, Cum:5): ", dersIsim[i]);
                do
                {

                    ders[i, 1, 0] = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (!(ders[i, 1, 0] >= (1 - 1) && ders[i, 1, 0] <= (5 - 1)))
                    {
                        Console.WriteLine("1-5 arası");
                    }
                } while (!(ders[i, 1, 0] >= (1 - 1) && ders[i, 1, 0] <= (5 - 1)));

                Console.Write("{0} dersi hangi saatte başlıyor ?(Sadece saat): ", dersIsim[i]);
                do
                {

                    do
                    {
                        ders[i, 0, 1] = Convert.ToInt32(Console.ReadLine());
                        if (!(ders[i, 0, 1] >= 8 && ders[i, 0, 1] <= 16))
                        {
                            Console.WriteLine("8-16 arası");
                        }
                    } while (!(ders[i, 0, 1] >= 8 && ders[i, 0, 1] <= 16));

                    Console.Write("{0} dersi hangi saatte bitiyor ?(Sadece saat): ", dersIsim[i]);
                    do
                    {
                        ders[i, 0, 2] = Convert.ToInt32(Console.ReadLine());
                        if (!(ders[i, 0, 2] >= 10 && ders[i, 0, 1] <= 17))
                        {
                            Console.WriteLine("10-17 arası");
                        }
                    } while (!(ders[i, 0, 2] >= 10 && ders[i, 0, 2] <= 17));
                    if (ders[i, 0, 2] - ders[i, 0, 1] < 2)
                    {
                        Console.WriteLine("Minimum 2 saat");
                    }
                } while (ders[i, 0, 2] - ders[i, 0, 1] < 2);
            }
            Bilgitablolama(ders, dersIsim);
        }
        public void Bilgitablolama(int[,,] ders, string[] dersIsim)
        {
            //8,26,44,62,80,98
            int dersSaati, dersSaatiHizala;
            for (int i = 0; i < ders.GetLength(0); i++)
            {
                dersSaati = (ders[i, 0, 2] - ders[i, 0, 1] - 1);
                dersSaatiHizala = 3 * (ders[i, 0, 1] - 8);
                for (int k = 0; k < dersSaati + 1; k++)
                {
                    if (dersIsim[i].Length <= 17)
                    {
                        Yazdir(dersIsim[i], 3 + dersSaatiHizala + 3 * k, Hizala(dersIsim[i], ders[i, 1, 0]));
                    }
                    else if (String.KelimeSayisi(dersIsim[i]) == 2)
                    {
                        Yazdir(String.InciKelime(dersIsim[i], 1), 3 + dersSaatiHizala + 3 * k, Hizala(String.InciKelime(dersIsim[i], 1), ders[i, 1, 0]));
                        Yazdir(String.InciKelime(dersIsim[i], 2), 4 + dersSaatiHizala + 3 * k, Hizala(String.InciKelime(dersIsim[i], 2), ders[i, 1, 0]));
                    }
                    else if (String.KelimeSayisi(dersIsim[i]) == 3)
                    {
                        if (String.InciKelime(dersIsim[i], 1).Length + String.InciKelime(dersIsim[i], 2).Length + 1 <= 17)
                        {
                            Yazdir(String.InciKelime(dersIsim[i], 1) + " " + String.InciKelime(dersIsim[i], 2), 3 + dersSaatiHizala + 3 * k,
                                Hizala(String.InciKelime(dersIsim[i], 1) + " " + String.InciKelime(dersIsim[i], 2), ders[i, 1, 0]));
                            Yazdir(String.InciKelime(dersIsim[i], 3), 4 + dersSaatiHizala + 3 * k, Hizala(String.InciKelime(dersIsim[i], 3), ders[i, 1, 0]));
                        }
                        else if (String.InciKelime(dersIsim[i], 1).Length + String.InciKelime(dersIsim[i], 2).Length + 1 > 17)
                        {
                            Yazdir(String.InciKelime(dersIsim[i], 1), 3 + dersSaatiHizala + 3 * k, Hizala(String.InciKelime(dersIsim[i], 1), ders[i, 1, 0]));
                            Yazdir(String.InciKelime(dersIsim[i], 2) + " " + String.InciKelime(dersIsim[i], 3), 4 + dersSaatiHizala + 3 * k,
                                Hizala(String.InciKelime(dersIsim[i], 2) + " " + String.InciKelime(dersIsim[i], 3), ders[i, 1, 0]));

                        }
                    }
                    else if (String.KelimeSayisi(dersIsim[i]) == 4)
                    {
                        if (String.InciKelime(dersIsim[i], 1).Length + String.InciKelime(dersIsim[i], 2).Length + 1 <= 17 &&
                            String.InciKelime(dersIsim[i], 2).Length + String.InciKelime(dersIsim[i], 4).Length + 1 <= 17)
                        {
                            Yazdir(String.InciKelime(dersIsim[i], 1) + " " + String.InciKelime(dersIsim[i], 2), 3 + dersSaatiHizala + 3 * k,
                               Hizala(String.InciKelime(dersIsim[i], 1) + " " + String.InciKelime(dersIsim[i], 2), ders[i, 1, 0]));
                            Yazdir(String.InciKelime(dersIsim[i], 3) + " " + String.InciKelime(dersIsim[i], 4), 4 + dersSaatiHizala + 3 * k,
                               Hizala(String.InciKelime(dersIsim[i], 3) + " " + String.InciKelime(dersIsim[i], 4), ders[i, 1, 0]));
                        }
                    }
                }
            }
        }

    }



    class Program
    {
        static void Main()
        {
            Tablo program = new Tablo();
            program.TabloOlusturma();
            program.Bilgialma();
            program.Tabloyazdir();



        }

    }
}
