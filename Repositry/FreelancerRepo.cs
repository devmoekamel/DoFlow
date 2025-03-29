using FreelanceManager.Interfaces;
using FreelanceManager.Models;

namespace FreelanceManager.Repositry
{
    public class FreelancerRepo:GenericRepo<Freelancer>,IFreelancerRepo
    {
        ITIContext context;
        public FreelancerRepo(ITIContext context) : base(context)
        {
            this.context = context;
        }
    }
}
