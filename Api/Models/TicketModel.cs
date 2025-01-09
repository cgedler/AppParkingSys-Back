namespace Api.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public required DateTime? ExitTime { get; set; }
    }
}
