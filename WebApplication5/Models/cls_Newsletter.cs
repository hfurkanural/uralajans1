using Microsoft.EntityFrameworkCore;
using WebApplication5.Models.MVVM;

namespace WebApplication5.Models
{
    public class cls_Newsletter
    {
        UralAjansContext context = new UralAjansContext();
        public async Task<List<Newsletter>> NewsletterSelect()
        {
            List<Newsletter> newsletter = await context.Newsletter.ToListAsync();
            return newsletter;
        }

        public bool EmailInsert(Newsletter news)
        {
            try
            {
                context.Add(news);
                news.Active = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EmailDelete(int id)
        {
            try
            {
                Newsletter? newsletter = context.Newsletter.FirstOrDefault(c => c.MailID == id);
                newsletter.Active = false;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
