using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Pages
{
    public class listelemeModel : PageModel
    {
        private readonly ApplicationDbContext _veri;     //Kýrmýzý altçizgide Ctrl+. yapýnýz
        public IList<birTablo>? _tablo { get; set; }     //Kýrmýzý altçizgide Ctrl+. yapýnýz

        public listelemeModel(ApplicationDbContext icerik)
        {
            _veri = icerik;
        }

        public void OnGet()
        {
            _tablo = _veri.birTablo.ToList();
        }
    }
}
