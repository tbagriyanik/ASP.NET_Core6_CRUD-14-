using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Pages
{
    public class guncellemeModel : PageModel
    {
        private readonly ApplicationDbContext _veri;    //Kýrmýzý altçizgide Ctrl+. yapýnýz
        public guncellemeModel(ApplicationDbContext icerik)
        {
            _veri = icerik;
        }

        public string? mesaj;   
        public string? guncelIsim;
        public float guncelUcret;
        public int guncelID;

        public void OnGet(int? ID)
        {
            if (ID != null)
            {
                var tablo = _veri.birTablo.Find(ID);    //Kýrmýzý altçizgide Ctrl+. yapýnýz
                if (tablo != null)
                {
                    mesaj = tablo.isim.ToString() + " kiþisi bulundu...";
                    guncelIsim = tablo.isim;
                    guncelUcret = tablo.ucret;
                    guncelID = tablo.ID;
                }
                else
                    mesaj = ID + " numaralý kayýt bulunamadý!";
            }
            else
                mesaj = "Güncellenecek kiþinin ID'sini giriniz";
        }

        public void OnPostGuncel()
        {
            float sayisal;
            if (!String.IsNullOrEmpty(Request.Form["isim"]) &&
                float.TryParse(Request.Form["ucret"], out sayisal))
            {
                guncelID = Convert.ToInt32(Request.Form["ID"]);
                var tablo = _veri.birTablo.Find(guncelID);       //Kýrmýzý altçizgide Ctrl+. yapýnýz
                if (tablo != null)
                {
                    tablo.isim = Request.Form["isim"];
                    tablo.ucret = (float)Convert.ToDouble(Request.Form["ucret"]);
                    _veri.birTablo.Update(tablo);                   //güncelle
                    _veri.SaveChanges();                            //kaydet
                    mesaj = Request.Form["isim"] + " kiþisi güncellendi...";
                }else
                    mesaj = guncelID + " numaralý kayýt bulunamadý!";
            }
            else
            {
                mesaj = "Boþ giriþ veya sayý olmayan giriþ vardý!";
            }
        }
    }
}
