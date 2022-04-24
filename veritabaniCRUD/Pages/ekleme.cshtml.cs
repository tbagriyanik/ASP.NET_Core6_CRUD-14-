using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Pages
{
    public class eklemeModel : PageModel
    {
        private readonly ApplicationDbContext _veri;    //Kýrmýzý altçizgide Ctrl+. yapýnýz
        public eklemeModel(ApplicationDbContext icerik)
        {
            _veri = icerik;
        }

        public string? mesaj;
        public void OnPostYeni()
        {
            float sayisal;
            if (!String.IsNullOrEmpty(Request.Form["isim"]) &&
                float.TryParse(Request.Form["ucret"], out sayisal))
            {
                birTablo tablo = new birTablo();        //Kýrmýzý altçizgide Ctrl+. yapýnýz
                tablo.isim = Request.Form["isim"];
                tablo.ucret = (float)Convert.ToDouble(Request.Form["ucret"]);
                _veri.birTablo.Add(tablo);              //ekle
                _veri.SaveChanges();                    //kaydet
                mesaj = Request.Form["isim"] + " kiþisi baþarýyla eklendi...";
            }
            else
            {
                mesaj = "Boþ giriþ veya sayý olmayan giriþ vardý!";
            }
        }
        public void OnGet()
        {
            mesaj = "Ekleme formunu doldurunuz";
        }
    }
}
