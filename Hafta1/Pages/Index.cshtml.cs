using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BTO425.Pages
{
    public class IndexModel : PageModel
    {
        //public string id = "";
        //public string id1 = "";

        public int sayi = 0;
        Random rnd;

        public void OnGet()
        {
            //string a = "";
            //id = HttpContext.Request.Query["id"];
            //id1 = HttpContext.Request.Query["id1"];            
            //rnd = new Random();
            //sayi = rnd.Next(1111, 9999);

            KayitListele();

            //return RedirectToPage("test");
        }

        public string mesaj { get; set; }
        public List<string> Kayitlar = new List<string>();

        [BindProperty]
        public string ad { get; set; }

        [BindProperty]
        public string soyad { get; set; }

        public void OnPost() {

            if (ad is null || soyad is null)
            {
                mesaj = "Eksik bilgileri tamamlayınız!";
            }
            else
            {
                StreamWriter sw = new StreamWriter("user.dat", true);

                    sw.WriteLine(ad + ";" + soyad);

                sw.Close();

                KayitListele();
            }
        }

        private void KayitListele() {

            int kayitSayisi = 0;

            StreamReader sr = new StreamReader("user.dat");

            while (sr.EndOfStream == false)
            {
                string kayit = sr.ReadLine();

                Kayitlar.Add(kayit);

                kayitSayisi++;
            }

            sr.Close();

            mesaj = "Kayıt başarılı! Mevcut kayıt sayısı: " + kayitSayisi;

        }
    }
}