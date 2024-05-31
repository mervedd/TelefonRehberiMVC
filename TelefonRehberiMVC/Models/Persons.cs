using System.Drawing;

namespace TelefonRehberiMVC.Models
{
    public class Persons
    {
        public  int Id  { get; set; }
        public string Ad  { get; set; }
        public  int PhoneId  { get; set; }
        public Phone Phones{ get; set; }
        public string Departman { get; set; }
        public string Birim { get; set; }
        public string Adres { get; set; }
        public string Mail { get; set; }
        public string  Resim { get; set; }
    }
}
