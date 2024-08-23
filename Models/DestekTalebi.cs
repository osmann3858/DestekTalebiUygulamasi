namespace DestekTalebiUygulamasi.Models
{
   public enum Durum
    {
        Yeni=0,
        Beklemede=1,
        İptalEdildi=2,
        Tamamlandi=3,
    }


    public class DestekTalebi
    {
        public int ID { get; set; }
        public DateTime Tarih { get; set; }
        public string Konu { get; set; }
        public string? Durum { get; set; }
        public string Mesaj { get; set; }
        public string IslemYapan { get; set; }
        public string Oncelik { get; set; }
        public string Tipi { get; set; }
    }

}
