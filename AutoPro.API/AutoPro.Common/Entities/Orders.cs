using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoPro.Common.Enum.Enumration;

namespace AutoPro.Common.Entities
{
    public class Orders : BaseEntity
    {
        [Key]
        public int OrderID { get; set; }

        public string? OrderCode { get; set; }

        public string? OrderDate { get; set; }

        public int Delivery { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int UserID { get; set; }

        public string? FullName { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Trạng thái đơn hàng
        /// </summary>
        public int StatusOrders { get; set; }

        public string? StatusOrdersName { get; set; }   

        /// <summary>
        /// Trạng thái thanh toán
        /// </summary>
        public int CheckOutStatusID { get; set; }
        public string? CheckoutStatusName { get; set; }

        /// <summary>
        /// HÌnh thức thanh toán
        /// </summary>
        public int CheckOutTypeID { get; set; }

        public string? CheckOutTypeName { get; set; }

    }
}
