using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BTO425.Pages
{
    public class testModel : PageModel
    {
        public void OnGet(string ID)
        {
            KayitListele(ID);
        }

        public string[] OgrenciDetay { get; set; }

        private void KayitListele(string ID)
        {
            StreamReader sr = new StreamReader("Ogrenci.csv");

            sr.ReadLine(); //Başlık satırını geçmek için

            string satirOku = "";

            while (sr.EndOfStream == false)
            {
                satirOku = sr.ReadLine();

                if (satirOku.Split(';')[0] == ID)
                {
                    OgrenciDetay = satirOku.Split(';');
                }
            }

            sr.Close();
        }
    }
}
