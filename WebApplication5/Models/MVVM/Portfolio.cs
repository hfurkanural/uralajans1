using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models.MVVM
{
    public class Portfolio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PortfolioID { get; set; }
        public string PortfolioName { get; set; }
        public string WebAddress { get; set; }
        public string Date { get; set; }
        public string Photo { get; set; }
        public bool Active { get; set; }
    }
}
