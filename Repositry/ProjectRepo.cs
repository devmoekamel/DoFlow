using FreelanceManager.Interfaces;
using FreelanceManager.Models;
using Microsoft.EntityFrameworkCore;
using FreelanceManager.Repositry;

namespace FreelanceManager.Repositry
{
    public class ProjectRepo:GenericRepo<Project>,IProjectRepo
    {
        ITIContext context;

        public ProjectRepo(ITIContext context) : base(context)
        {
            this.context = context;
        }
    }
}
