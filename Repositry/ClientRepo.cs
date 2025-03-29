using FreelanceManager.Interfaces;
using FreelanceManager.Models;

namespace FreelanceManager.Repositry
{
    public class ClientRepo:GenericRepo<Client>,IClientRepo
    {
        ITIContext context;
        public ClientRepo(ITIContext context) : base(context)
        {
            this.context = context;
        }
    }
}
