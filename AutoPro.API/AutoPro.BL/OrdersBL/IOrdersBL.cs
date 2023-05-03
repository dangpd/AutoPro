using AutoPro.BL.BaseBL;
using AutoPro.Common.Entities;
using AutoPro.Common.Entities.DTO;
using AutoPro.Common.Entities.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPro.BL.OrdersBL
{
    public interface IOrdersBL : IBaseBL<Orders>
    {
        /// <summary>
        /// Thêm mới product
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ServiceResult InsertOrderDetail(OrderDetailParam param);


        /// <summary>
        /// Xem chi tiết sản phẩm
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>

        public object getOrderDetail(int entityId);

        public object getByUserID(int userId);
        /// <summary>
        /// Cập nhật đơn hàng
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ServiceResult UpdateOrderDetail(OrderDetailParam param);

        /// <summary>
        /// Tạo mã đơn hàng tự động
        /// </summary>
        /// <returns></returns>
        public string CreateAutoOrderCode();

        public object Filter(string? textSearch, long pageSize, long pageNumber,int status);
        ///// <summary>
        ///// lấy báo cáo doanh thu theo chi nhánh từng năm
        ///// </summary>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //public List<double> getReportRevenueByYear(ReportRevenueByYearParam param);

        ///// <summary>
        ///// lấy báo cáo doanh thu theo chi nhánh từng năm
        ///// </summary>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //public List<double> getReportRevenueByBranch(TimeParam param);

        ///// <summary>
        ///// báo cáo hàng hóa được mua nhiều nhất ( top 10)
        ///// </summary>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //public List<ReportProductBestSell> getReportProductBestSell(TimeParam param);
    }
}
