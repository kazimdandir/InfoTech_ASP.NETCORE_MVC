namespace InfoTechCoreMVCCodeFirstFluent09062024.Models.Entities
{
    public class Ogrenci
    {
        public int OgrenciID { get; set; }
        public string OgrenciAdi { get; set; }
        public string OgrenciSoyadi { get; set; }

        public virtual ICollection<Egitmen> Egitmen { get; set; }
    }
}
