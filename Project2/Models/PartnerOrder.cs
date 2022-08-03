using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class PartnerOrder
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("الجهة")]
        public string Dept { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("نوع الشراكة")]
        public string TypeOfOreder { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("المدينة")]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("مدة الشراكة")]
        public string Duration { get; set; }

  

        public int userid { get; set; }

    }
}
