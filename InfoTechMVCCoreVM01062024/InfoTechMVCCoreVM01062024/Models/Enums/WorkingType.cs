using System.ComponentModel.DataAnnotations;

namespace InfoTechMVCCoreVM01062024.Models.Enums
{
    public enum WorkingType
    {
        [Display(Name = "Tam Zamanlı")]
        FullTime = 1,

        [Display(Name = "Yarı Zamanlı")]
        PartTime = 2,

        [Display(Name = "Proje Bazlı")]
        ProjectBased = 3,

        [Display(Name = "Serbest Zamanlı")]
        Freelance = 4
    }
}
