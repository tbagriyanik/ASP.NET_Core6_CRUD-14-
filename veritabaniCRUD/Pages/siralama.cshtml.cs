using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Pages
{
    public class siralamaModel : PageModel
    {
        private readonly ApplicationDbContext _veri;     //Kýrmýzý altçizgide Ctrl+. yapýnýz
        public IList<birTablo>? _tablo { get; set; }     //Kýrmýzý altçizgide Ctrl+. yapýnýz

        public siralamaModel(ApplicationDbContext icerik)
        {
            _veri = icerik;
        }
        public string? mesaj { get; set; }

        public void OnGet(string? sirala = null, string? yon = null)
        {
            if (sirala != null && yon != null)
            {
                switch (sirala)
                {
                    case "ID":
                        if (yon == "az")
                            _tablo = _veri.birTablo.OrderBy(x => x.ID).ToList();
                        else
                            _tablo = _veri.birTablo.OrderByDescending(x => x.ID).ToList();
                        mesaj = "Sýralama yapýldý";
                        break;
                    case "isim":
                        if (yon == "az")
                            _tablo = _veri.birTablo.OrderBy(x => x.isim).ToList();
                        else
                            _tablo = _veri.birTablo.OrderByDescending(x => x.isim).ToList();
                        mesaj = "Sýralama yapýldý";
                        break;
                    case "ucret":
                        if (yon == "az")
                            _tablo = _veri.birTablo.OrderBy(x => x.ucret).ToList();
                        else
                            _tablo = _veri.birTablo.OrderByDescending(x => x.ucret).ToList();
                        mesaj = "Sýralama yapýldý";
                        break;
                    default:
                        mesaj = "Sýralama doðru olarak seçilmedi.";
                        break;
                }

            }
            else
                mesaj = "Sýralama seçiniz.";
        }
    }
}
