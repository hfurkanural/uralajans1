using Microsoft.EntityFrameworkCore;
using WebApplication5.Models.MVVM;

namespace WebApplication5.Models
{
    public class cls_Clients
    {
        UralAjansContext context = new UralAjansContext();
        public async Task<List<Clients>> ClientSelect()
        {
            List<Clients> clients = await context.Clients.ToListAsync();
            return clients;
        }
        public bool ClientInsert(Clients client)
        {
            try
            {
                context.Add(client);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<Clients> ClientDetails(int? id)
        {
            Clients? client = await context.Clients.FindAsync(id);
            return client;
        }
        public bool ClientUpdate(Clients client)
        {
            try
            {
                context.Update(client);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ClientDelete(int id)
        {
            try
            {
                Clients? client = context.Clients.FirstOrDefault(c => c.ClientID == id);
                client.Active = false;
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
