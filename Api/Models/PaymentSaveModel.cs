namespace Api.Models
{
    public class PaymentSaveModel
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
