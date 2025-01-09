using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    /// <summary>
    ///    Represents the tickets table of the database.
    /// </summary>
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public required DateTime ExitTime { get; set; }
        public Ticket() { }
    }
}
