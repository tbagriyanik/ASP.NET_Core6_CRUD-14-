using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Pages
{
    public class silmeModel : PageModel
    {
        private readonly ApplicationDbContext _veri;    //Kýrmýzý altçizgide Ctrl+. yapýnýz
        public silmeModel(ApplicationDbContext icerik)
        {
            _veri = icerik;
        }

        public string? mesaj;
        public void OnPostSil()
        {
            int sayisal;
            if (int.TryParse(Request.Form["ID"], out sayisal))
            {
                var tablo = _veri.birTablo.Find(sayisal);    //Kýrmýzý altçizgide Ctrl+. yapýnýz
                if (tablo != null)
                {
                    mesaj = tablo.isim.ToString() + " kiþisi silindi...";
                    _veri.birTablo.Remove(tablo);           //sil
                    _veri.SaveChanges();                    //kaydet
                }
                else
                    mesaj = sayisal + " numaralý silinecek kayýt bulunamadý!";
            }
            else
                mesaj = "Boþ giriþ veya sayý olmayan giriþ vardý!";
        }
        public void OnGet()
        {
            mesaj = "Silinecek ID'yi giriniz";
        }
    }
}
