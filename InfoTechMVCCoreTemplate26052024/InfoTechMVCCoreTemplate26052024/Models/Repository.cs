namespace InfoTechMVCCoreTemplate26052024.Models
{
    public class Repository
    {
        public static List<Ogrenci> ogrenciler;

        static Repository()
        {
            ogrenciler = new List<Ogrenci>
            {   new Ogrenci { ID = 1, Ad = "Ali", Soyad = "Veli", Eposta = "ali.veli@mail.com", Katilim = true, Telefon = "05555555555" },
                new Ogrenci { ID = 2, Ad = "Ayşe", Soyad = "Fatma", Eposta = "ayse.fatma@mail.com", Katilim = false, Telefon = "05444444444" },
                new Ogrenci { ID = 3, Ad = "John", Soyad = "Doe" , Eposta = "john.doe@mail.com", Katilim = true, Telefon = "05333333333"},
                new Ogrenci { ID = 4, Ad = "Mehmet", Soyad = "Yılmaz", Eposta = "mehmet.yilmaz@mail.com", Katilim = false, Telefon = "05666666666" },
                new Ogrenci { ID = 5 ,Ad = "Fatma", Soyad = "Kaya", Eposta = "fatma.kaya@mail.com", Katilim = true, Telefon = "05777777777" },
                new Ogrenci { ID = 6, Ad = "Ahmet", Soyad = "Demir", Eposta = "ahmet.demir@mail.com", Katilim = false, Telefon = "05888888888" }
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

        public static void OgrenciSil(int ID)
        {
            var selected = ogrenciler.FirstOrDefault(x => x.ID == ID);

            if (selected != null)
            {
                ogrenciler.Remove(selected);
            }
        }

        public static void OgrenciDuzenle(int ID, Ogrenci ogr)
        {
            var selected = ogrenciler.FirstOrDefault(x => x.ID == ID);

            if(selected != null)
            {
                OgrenciEkle(ogr);
                ogrenciler.Remove(selected);
            }
        }

    }
}
