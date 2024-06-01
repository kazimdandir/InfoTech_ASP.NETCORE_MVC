using InfoTechMVCCoreVM01062024.Models.Enums;

namespace InfoTechMVCCoreVM01062024.Models
{
    public class Personel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public DateTime BirthDate { get; set; }
        public WorkingType WorkingType { get; set; }
    }
}
