namespace InfoTechMVCCoreTemplate26052024.Models
{
    public class Repository
    {
        public static List<Ogrenci> ogrenciler;

        static Repository()
        {
            ogrenciler = new List<Ogrenci>
            {
                new Ogrenci { Ad = "Ali", Soyad = "Veli", Eposta = "ali.veli@mail.com", Katilim = true, Telefon = "05555555555" },
                new Ogrenci { Ad = "Ayşe", Soyad = "Fatma", Eposta = "ayse.fatma@mail.com", Katilim = false, Telefon = "05444444444" },
                new Ogrenci { Ad = "John", Soyad = "Doe" , Eposta = "john.doe@mail.com", Katilim = true, Telefon = "05333333333"}
            };
        }   

        public static List<Ogrenci> OgrenciListe()
        {
            return ogrenciler;
        }

        public static void OgrenciEkle(Ogrenci ogrenci)
        {
            ogrenciler.Add(ogrenci);
        }

        public static void OgrenciSil(string ad)
        {
            var selected = ogrenciler.FirstOrDefault(x => x.Ad == ad);

            if (selected != null)
            {
                ogrenciler.Remove(selected);
            }
        }
    }
}
