using Microsoft.AspNetCore.Identity;

namespace FreelanceManager.Models
{
    public class Freelancer:IdentityUser
    {
        public int Id { get; set; }

        public string Phone { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Project> projects { get; set; }
    }
}
