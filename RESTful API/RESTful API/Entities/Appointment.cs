namespace RESTful_API.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateOnly Date { get; set; }
    }
}
