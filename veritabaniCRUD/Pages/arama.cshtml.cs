using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Pages
{
    public class aramaModel : PageModel
    {
        private readonly ApplicationDbContext _veri;     //Kýrmýzý altçizgide Ctrl+. yapýnýz
        public IList<birTablo>? _tablo { get; set; }     //Kýrmýzý altçizgide Ctrl+. yapýnýz

        public aramaModel(ApplicationDbContext icerik)
        {
            _veri = icerik;
        }
        public string? mesaj { get; set; }

        public void OnGet(string? aranan = null)
        {
            if (aranan != null)
            {
                _tablo = _veri.birTablo.Where(x => x.isim.Contains(aranan)).ToList();
                if (_tablo.Count > 0)
                {
                    mesaj = aranan + ", " + _tablo.Count + " adet bulundu";
                }
                else
                    mesaj = aranan + " bulunamadý...";
            }
            else
                mesaj = "Aranan kiþinin adýný giriniz.";
        }
    }
}
