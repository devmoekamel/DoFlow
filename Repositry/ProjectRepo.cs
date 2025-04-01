using FreelanceManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using FreelanceManager.Repositry;
using FreelanceManager.Models;

namespace FreelanceManager.Repositry
{
    public class ProjectRepo:IProjectRepo
    {
        ITIContext context;

        public ProjectRepo(ITIContext context) 
        {
            this.context = context;
        }

		public void Add(Project obj)
		{
	
			context.projects.Add(obj);
		}

		public IEnumerable<Project> GetAll()
		{
			
			return context.projects;
		}

		public Project GetById(int Id)
		{
			Project project = context.projects.FirstOrDefault(p=>p.Id==Id);

			return project;
		}

		public void Remove(Project obj)
		{
			context.projects.Remove(obj);
		}

		public void Save()
		{
			context.SaveChanges();
		}

		public void Update(Project obj)
		{

			context.projects.Update(obj);
		}
	}
}
