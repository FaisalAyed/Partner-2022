using System.ComponentModel;

namespace Project2.Models
{
    public class OrderState
    {
        public int Id { get; set; }

        [DisplayName("حالة الطلب ")]
        public string Name { get; set; }
    }
}
