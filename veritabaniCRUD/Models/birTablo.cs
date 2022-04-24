using System.ComponentModel.DataAnnotations;

namespace veritabaniCRUD.Models
{
    public class birTablo
    {
        [Key]
        public int ID { get; set; }
        
        public string? isim { get; set; }
        public float ucret { get; set; }
    }
}   
