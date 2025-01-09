namespace Api.Models
{
    public class TicketSaveModel
    {
        public DateTime EntryTime { get; set; }
        public required DateTime? ExitTime { get; set; }
    }
}
