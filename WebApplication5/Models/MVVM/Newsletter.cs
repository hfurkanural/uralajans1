using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models.MVVM
{
    public class Newsletter
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MailID { get; set; }
        public string? Email { get; set; }
        public bool Active { get; set; }
    }
}
