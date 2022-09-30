using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_ecommerce_db
{
    [Table("payment")]
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public bool status { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
