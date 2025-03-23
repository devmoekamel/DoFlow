namespace FreelanceManager.Models
{
    public class Project
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public double budget { get; set; }

        public double HourlyRate { get; set; }
        public string Company {  get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }

        public DateTime  StartDate { get; set; }
        public DateTime EndDate { get; set; }

        


    }
}
