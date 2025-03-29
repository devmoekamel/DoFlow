using FreelanceManager.Interfaces;
using FreelanceManager.Models;

namespace FreelanceManager.Repositry
{
    public class InvoiceRepo:GenericRepo<Invoice>,IInvoiceRepo
    {
        ITIContext context;
        public InvoiceRepo(ITIContext context) : base(context)
        {
            this.context = context;
        }
    }
}
