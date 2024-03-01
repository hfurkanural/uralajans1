using WebApplication5.Models.MVVM;

namespace WebApplication5.Models
{
    public class cls_Contact
    {
        UralAjansContext context = new UralAjansContext();
        public bool AddMessage(Contact contact)
        {
            try
            {
                contact.DateTime = DateTime.Now.ToString("ddd,MMM,yyyy,HH,mm,ss");
                context.Add(contact);
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
