using FreelanceManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using FreelanceManager.Repositry;
using FreelanceManager.Models;

namespace FreelanceManager.Repositry
{ّ
    public class ProjectRepo:GenericRepo<Project>,IProjectRepo
    {
        ITIContext context;

        public ProjectRepo(ITIContext context) : base(context)
        {
            this.context = context;
        }
    }
}
