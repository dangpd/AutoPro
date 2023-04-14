using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPro.Common.Entities
{
    public class Orders : BaseEntity
    {
        [Key]
        public int OrderID { get; set; }

        public string? OrderCode { get; set; }

        public string? OrderDate { get; set; }

        public int Status { get; set; }

        public int Delivery { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int UserID { get; set; }
    }
}
