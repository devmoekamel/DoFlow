using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceManager.Models
{
    public class Project
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public double Budget { get; set; }

        public double HourlyRate { get; set; }
        public string Company {  get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }

        public DateTime  StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public int InvoiceId { get; set; }
        [ForeignKey(nameof(InvoiceId))]
        public Invoice? Invoice {  get; set; } 

        public List<Mission>? missions { get; set; }

    }
}
