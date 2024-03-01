using WebApplication5.Models.MVVM;

namespace WebApplication5.Models
{
    public class cls_Portfolio
    {
        UralAjansContext context = new UralAjansContext();
        public bool InsertPortfolio(Portfolio portfolio)
        {
            try
            {
                context.Add(portfolio);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePortfolio(Portfolio portfolio)
        {
            try
            {
                context.Update(portfolio);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePortfolio(int id)
        {
            try
            {
                Portfolio portfolio = context.Portfolio.FirstOrDefault(p => p.PortfolioID == id);
                portfolio.Active = false;
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
