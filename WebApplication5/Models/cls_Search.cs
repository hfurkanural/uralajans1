using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class cls_Search
    {
        UralAjansContext context = new UralAjansContext();
        public List<sp_Search> sp_Searches(string id)
        {
            var services = context.sp_Searches.FromSqlRaw($"sp_arama {id}").ToList();
            return services;
        }
    }
}
