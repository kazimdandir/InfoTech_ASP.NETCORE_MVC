namespace InfoTechMVCCoreTemplate26052024.Models
{
    public class Repository
    {
        private static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        
        public static List<Ogrenci> OgrenciListe()
        {
            return ogrenciler; 
        }

        public static void OgrenciEkle(Ogrenci ogrenci)
        {
            ogrenciler.Add(ogrenci);
        }

        public static List<Ogrenci> Ogrenciler { get { return ogrenciler; } }
    }
}
