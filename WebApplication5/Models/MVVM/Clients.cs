using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models.MVVM
{
    public class Clients
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientID { get; set; }
        public string? ClientName { get; set; }
        public string? ClientAddress { get; set; }
        public string? ClientPhoto { get; set; }
        public bool Active { get; set; }

    }
}
