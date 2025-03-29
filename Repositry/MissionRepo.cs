using FreelanceManager.Interfaces;
using FreelanceManager.Models;

namespace FreelanceManager.Repositry
{
    public class MissionRepo:GenericRepo<Mission>,IMissionRepo
    {
        ITIContext context;
        public MissionRepo(ITIContext context) : base(context)
        {
            this.context = context;
        }
    }
}
