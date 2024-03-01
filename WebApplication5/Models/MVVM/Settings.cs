using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models.MVVM
{
    public class Settings
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SettingID { get; set; }


        [DisplayName("Telefon Numarası"), Required, StringLength(50)]
        public string PhoneNumber { get; set; }


        [DisplayName("E-posta"),Required, StringLength(50)]
        public string Email { get; set; }


        [Required, StringLength(200)]
        public string Facebook { get; set; }


        [Required, StringLength(200)]
        public string Twitter { get; set; }


        [Required, StringLength(200)]
        public string LinkedIn { get; set; }


        [Required, StringLength(200)]
        public string Instagram { get; set; }


        [DisplayName("Adres"), Required, StringLength(500)]
        public string Address { get; set; }
    }
}
