using System.ComponentModel;

namespace Project2.ModelView
{
    public class MyUser
    {
        public string id { get; set; }
        [DisplayName("الاسم الأول")]
        public string firstName  { get; set; }
        [DisplayName("الاسم الأخير")]
        public string lastName { get; set; }
    }
}
