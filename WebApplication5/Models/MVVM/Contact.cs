using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication5.Models.MVVM
{
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageID { get; set; }




        [DisplayName("Adınız"), Required, StringLength(100)]
        public string? SenderName { get; set; }



        [DisplayName("Eposta"), Required, StringLength(100)]
        public string? Email { get; set; }




        [DisplayName("Firma Adı"), StringLength(100)]
        public string? CompanyName { get; set; }




        [DisplayName("Telefon"), Required, StringLength(50)]
        public string? Phone { get; set; }




        [DisplayName("Mesajınız"), Required, StringLength(4000)]
        public string? Message { get; set; }



        public string? DateTime { get; set; }

    }
}
