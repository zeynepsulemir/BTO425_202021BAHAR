using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BTO425.Pages
{
    public class ogrencilerModel : PageModel
    {
        public void OnGet()
        {
            KayitListele();
        }

        public List<string> Ogrenciler = new List<string>();

        private void KayitListele()
        {

            int kayitSayisi = 0;

            StreamReader sr = new StreamReader("Ogrenci.csv");

            sr.ReadLine();

            while (sr.EndOfStream == false)
            {
                string kayit = sr.ReadLine();

                Ogrenciler.Add(kayit);

                kayitSayisi++;
            }

            sr.Close();
        }
    }
}
