using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğrenci_kayıt_uygulaması
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste ogrenciler = new Liste();  //tydl yapısı
              int numara;
              string ad, soyad, dersAdi;
              float vize, final;
        
        int secim = menu();
            while(secim !=0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("numara : ");
                        numara=int.Parse(Console.ReadLine());
                        Console.Write("ad : ");
                        ad = (Console.ReadLine());
                        Console.Write("soyad : ");
                        soyad = (Console.ReadLine());
                        Console.Write("ders adı : ");
                       dersAdi = (Console.ReadLine());
                        Console.Write("vize : ");
                       vize = float.Parse(Console.ReadLine());
                        Console.Write("final : ");
                        final = float.Parse(Console.ReadLine());
                        ogrenciler.ekle(numara,ad,soyad,dersAdi,vize,final);
                       
                        break;
                    case 2:
                    
                        Console.Write("numara : ");
                        numara = int.Parse(Console.ReadLine());
                        ogrenciler.sil(numara);
                        break;
                    case 3:
                        Console.Clear();
                        ogrenciler.yazdir();
                        break;
                        case 4:
                        Console.Clear();
                        ogrenciler.enBasariliOgrenci();
                        break;
                    case 0:break;
                    default:
                        Console.WriteLine("Hatalı Seçim Yaptınız !");
                        break;

                }
                secim = menu();
            }
            Console.WriteLine("Program Kapatılıyor...");
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("\n1) Öğrenci Ekle");
            Console.WriteLine("2) Öğrenci Sil");
            Console.WriteLine("3) Öğrencileri Yazdır");
            Console.WriteLine("4) En Başarılı Öğrenciyi Göster");
            Console.WriteLine("0) ÇIKIŞ");
            Console.Write("SEÇİMİNİZ : ");
            secim =int.Parse(Console.ReadLine());
            return secim;
        }
    }

    class Ogrenci
    {
        public int numara;
       public  string ad, soyad, dersAdi;
       public float vize, final, ort;
      public  string durum;

        public Ogrenci next;
        public Ogrenci(int n, string a, string s, string d, float v, float f)
        {
            this.numara = n;
            this.ad = a;
            this.soyad = s;
            this.dersAdi = d;
            this.vize = v;
            this.final = f;

            this.ort = this.vize * 40 / 100 + this.final * 60 / 100;
            this.durum=this.ort <50? "Kaldı": "Geçti";
            next = null;
         }       
          
    }
    class Liste
    {
        Ogrenci head;
        public Liste()
        {
            head = null;
        }
        public void ekle(int n, string a, string s, string d, float v, float f)
        {
            Ogrenci ogr = new Ogrenci(n,a,s,d,v,f);
            if(head == null)
            {
                head = ogr;
                Console.WriteLine(n + " numaralı öğrenci listeye eklendi");
            }
            else
            {
                ogr.next = head;
                head= ogr;
                Console.WriteLine(n + " numaralı öğrenci eklendi");
            }

        }

        public void sil(int numara)
        {
           bool sonuc = false;

            if (head == null)
            {
               sonuc = true;
                Console.WriteLine("Listede Kayıtlı Öğrenci Yok !");
            }
           else if (head.next == null && head.numara==numara)
            {
                sonuc= true;
                head = null;
                Console.WriteLine(numara + " numaralı öğrenci silindi, listede hiç öğrenci kalmadı");
            }
            else if (head.next != null && head.numara == numara)
            {
                sonuc= true;

                head = head.next;
                Console.WriteLine(numara + " numaralı öğrenci silindi, listede hiç öğrenci kalmadı");
            }
            else
            {
                Ogrenci temp= head;
                Ogrenci temp2 = temp;

                while (temp.next != null)
                {
                    if(numara==temp.numara)
                    {
                        sonuc= true;
                        temp2.next = temp.next;
                        Console.WriteLine(numara + " numaralı öğrenci silindi");
                        temp2 = temp;
                        
                    }
                    temp2 = temp;
                    temp=temp.next;

                }
                if (numara == temp.numara)
                {
                    sonuc= true;
                    temp2.next = null;
                    Console.WriteLine(numara + " numaralı öğrenci silindi");
                  
                }
            }
            if(sonuc==false)
            {
                Console.WriteLine(numara + " numaralı öğrenci kaydı yok");
            }

        }

        public void yazdir()
        {
            if(head==null)
            {
                Console.WriteLine("Listede Kayıtlı Öğrenci Yok !");
            }
            else
            {
                Ogrenci temp = head;

                Console.WriteLine("Numara \tAd \tSoyad \tDersAdi \tOrtalam \tDurum\n");
                while (temp.next != null)
                {
                    Console.WriteLine(temp.numara + "\t" +   temp.ad + "\t" +   temp.soyad + "\t" +  temp.dersAdi + "\t" +  temp.ort + "\t" +  temp.durum );
                    temp = temp.next;
                }
                Console.WriteLine(temp.numara + "\t" + temp.ad + "\t" + temp.soyad + "\t" + temp.dersAdi + "\t" + temp.ort + "\t" + temp.durum);
            }


        }

        public void enBasariliOgrenci()
        {
            if (head == null)
            {
                Console.WriteLine("Listede Kayıtlı Öğrenci Yok !");
            }
            else
            {
                Ogrenci temp = head;
                Ogrenci yuksekOgr = head;
                float enYuksekOrt = head.ort;

              
                while (temp.next != null)
                {
                   if(enYuksekOrt<temp.ort)
                    {
                        enYuksekOrt=temp.ort;
                        yuksekOgr = temp;
                    }
                    temp = temp.next;
                }
                if (enYuksekOrt < temp.ort)
                {
                    enYuksekOrt = temp.ort;
                    yuksekOgr = temp;
                }

                Console.WriteLine("En Yüksek Ortalamalı Öğrenci Bilgileri : ");

                Console.WriteLine("Numara \tAd \tSoyad \tDersAdi \tOrtalam \tDurum\n");

                Console.WriteLine(yuksekOgr.numara + "\t" + yuksekOgr.ad + "\t" + yuksekOgr.soyad + "\t" + yuksekOgr.dersAdi + "\t" + yuksekOgr.ort + "\t" + yuksekOgr.durum);
            }


        }
    }
}
