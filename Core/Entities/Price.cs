using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    /// <summary>
    ///    Represents the price table of the database.
    /// </summary>
    public class Price
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public Price() { }
    }
}
