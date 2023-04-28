using AutoPro.BL.BaseBL;
using AutoPro.Common.Entities;
using AutoPro.Common.Entities.DTO;
using AutoPro.Common.Entities.Param;
using AutoPro.DL.OrdersDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoPro.BL.OrdersBL
{
    public class OrdersBL : BaseBL<Orders>,IOrdersBL
    {
        private IOrdersDL _ordersDL;

        public OrdersBL(IOrdersDL ordersDL) : base(ordersDL)
        {
            _ordersDL = ordersDL;
        }

        public string CreateAutoOrderCode()
        {
            string newCode = "";
            Orders lastOrder = _ordersDL.GetLastestOrder();
            if (lastOrder != null)
            {
                string lastCode = lastOrder.orderCode;
                int codenumber = int.Parse(lastCode.Substring(2)) + 1;
                newCode = "DH" + codenumber.ToString();
            }
            else
            {
                newCode = "DH100001";
            }
            return newCode;
        }

        public object getOrderDetail(int entityId)
        {
            return _ordersDL.getOrderDetail(entityId);
        }

        public ServiceResult InsertOrderDetail(OrderDetailParam param)
        {
            Orders order = new Orders();
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            // Thoông tin user người dừng gửi lên
            order = JsonSerializer.Deserialize<Orders>(param.order);
            // Thoông tin sản phẩm người dùng mua gửi lên
            listOrderDetail = JsonSerializer.Deserialize<List<OrderDetail>>(param.orderdetail);
            // Thông tin sản phẩm trong database để kiểm tra số lương sản phẩm người dùng mua nhiều hơn số lượng sản phẩm trong db thfi bắn lỗi
            List<Product> listProduct = new List<Product>();
            foreach(var item in listOrderDetail)
            {
               var kqs = _ordersDL.GetListProductByListID(item.productID);
                if(kqs != null)
                {
                    listProduct.Add(kqs);
                }
                else
                {
                    return new ServiceResult
                    {
                        IsSuccess = false,
                        Data = new ErrorResult
                        {
                            ErrorCode = Common.Enum.ErrorCode.InvalidData,
                            UserMsg = "Sản phẩm không tồn tại trong hệ thống"
                        }
                    };
                }
            }
            // Kiểm tra số lượng sản phẩm trong db và số lượng gửi lên
            var kq = this.validateOrder(order, listOrderDetail, listProduct);
            if (!kq.IsSuccess)
            {
                return kq;
            }
            // Tạo mã đơn hàng tự động
            order.orderCode = CreateAutoOrderCode();

            var result = _ordersDL.InsertOrderDetail(order, listOrderDetail, listProduct);
            if (result == null)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = Common.Enum.ErrorCode.ServerError,
                        DevMsg = "Lỗi insert",
                        UserMsg = "Lỗi insert",
                        MoreInfo = "Lỗi insert"
                    }
                };
            }
            if (order != null)
            {
                // gửi mail
                return new ServiceResult
                {
                    IsSuccess = true
                };
            }
            return new ServiceResult { IsSuccess = true };
        }

        public ServiceResult UpdateOrderDetail(OrderDetailParam param)
        {
            ServiceResult serviceResult = new ServiceResult();
            Orders order = new Orders();
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            order = JsonSerializer.Deserialize<Orders>(param.order);
            listOrderDetail = JsonSerializer.Deserialize<List<OrderDetail>>(param.orderdetail);
            Orders? result = _ordersDL.UpdateOrderDetail(order, listOrderDetail);
            //serviceResult.Data = (Orders)result;
            return serviceResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order">Thông tin người dùng</param>
        /// <param name="orderDetail">Thông tin sản phầm người dùng mua</param>
        /// <param name="listProductDetail">Thông tin sản phẩm trong đb</param>
        /// <returns></returns>
        public ServiceResult validateOrder(Orders order, List<OrderDetail> orderDetail, List<Product> listProductDetail)
        {

            List<string> productcode = new List<string>();
            // Kiểm tra nếu có lõi thì bắn lên
            foreach (var item in orderDetail)
            {
                Product currentProduct = listProductDetail.Find(x => x.ProductID == item.productID);
                int inventory = currentProduct.Quantity - currentProduct.QuantitySell;
                if (item.quantitys > inventory)
                {
                    productcode.Add(item.productCode);
                }
            }

            // Bắn lỗi
            if (productcode.Count > 0)
            {
                return new ServiceResult
                {
                    IsSuccess = false,

                    Data = new ErrorResult
                    {
                        ErrorCode = Common.Enum.ErrorCode.InvalidData,
                        DevMsg = "Sản phẩm đặt vượt số lượng trong kho",
                        UserMsg = "Sản phẩm đặt vượt số lượng trong kho",
                        MoreInfo = $"{productcode}"
                    }
                };
            }

            // Trừ sản phẩm trong database
            foreach (var item in listProductDetail)
            {
                OrderDetail currentProduct = orderDetail.Find(x => x.productID == item.ProductID);
                int quantity = currentProduct != null ? currentProduct.quantitys : 0;
                item.Quantity -= quantity;
                item.QuantitySell += quantity;
            }
            return new ServiceResult
            {
                IsSuccess  = true
            };
        }

    }
}
