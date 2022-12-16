namespace PortfolioApplication.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string? contactName { get; set;}
        public string? contactEmail { get; set; }
        public string? contactSubject { get; set;}
        public string? contactMessage { get; set; }

        public ContactInfo() {
        
        }
    }
}
