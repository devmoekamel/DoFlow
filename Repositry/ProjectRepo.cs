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
			throw new NotImplementedException();
		}

		public IEnumerable<Project> GetAll()
		{
			throw new NotImplementedException();
		}

		public Project GetById(int Id)
		{
			throw new NotImplementedException();
		}

		public void Remove(Project obj)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public void Update(Project obj)
		{
			throw new NotImplementedException();
		}
	}
}
