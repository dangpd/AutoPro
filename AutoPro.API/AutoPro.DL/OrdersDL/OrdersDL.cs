using AutoPro.Common.Entities;
using AutoPro.Common.Entities.DTO;
using AutoPro.Common.Entities.Param;
using AutoPro.Common.ProceduceName;
using AutoPro.DL.BaseDL;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoPro.DL.OrdersDL
{
    public class OrdersDL : BaseDL<Orders>, IOrdersDL
    {
        // Khởi tạo lấy kết nối đường dẫn database
        string connectionString = DatabaseContext.ConnectionString;

        public object Filter(string? textSearch, long pageSize, long pageNumber,int status)
        {
            // Chuẩn bị tên stored proceduce
            string queryFilter = "Proc_Orders_FilterByStatus";

            // Tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("p_TextSearch", textSearch);
            parameters.Add("p_PageSize", pageSize);
            parameters.Add("p_PageNumber", pageNumber);
            parameters.Add("p_StatusOrders", status);

            // Kết nối db
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                var multiResults = mySqlConnection.QueryMultiple(queryFilter, parameters, commandType: System.Data.CommandType.StoredProcedure);
                var data = multiResults.Read<Orders>().ToList();
                var totalCount = multiResults.Read<long>().Single();
                //if(data.Count == 0)
                //{
                //    return null;
                //}
                // Return kêt quả
                return new PagingData<Orders>
                {
                    TotalRecord = totalCount,
                    TotalPage = (totalCount % pageSize) > 0 ? ((totalCount / pageSize) + 1) : (totalCount / pageSize),
                    Data = data,
                };
            }
        }
        public Orders GetLastestOrder()
        {
            // Chuẩn bị tên store procedure
            string sql = "Proc_Orders_GetMaxCode";
            var parameters = new DynamicParameters();
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Query
                var record = mySqlConnection.QueryFirstOrDefault<Orders>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return record;
            }
        }

        public object getOrderDetail(int entityId)
        {
            string sql = "Proc_OrderDetail_GetByID";
            DynamicParameters param = new DynamicParameters();
            param.Add("v_OrderID", entityId);
            string sql2 = "Proc_Orders_GetByID";
            DynamicParameters param2 = new DynamicParameters();
            param2.Add("v_OrderID", entityId);
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            Orders orders = new Orders();
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Query
                listOrderDetail = mySqlConnection.Query<OrderDetail>(sql, param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                orders = mySqlConnection.QueryFirstOrDefault<Orders>(sql2, param2, commandType: System.Data.CommandType.StoredProcedure);
            }
            return new
            {
                Orders = orders,
                OrderDetail = listOrderDetail
            };
        }

        public object InsertOrder(Orders orders)
        {
            // Chuẩn bị tên store procedure
            string insertStoreProcedureName = String.Format(ProceduceName.Insert, typeof(Orders).Name);
            // Chuẩn bị tham số cho procedure
            var parameters = new DynamicParameters();

            var properties = typeof(Orders).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = $"v_{property.Name}";
                var propertyValue = property.GetValue(orders);
                parameters.Add(propertyName, propertyValue);
            }

            parameters.Add("v_CreatedDate", DateTime.Now);
            parameters.Add("v_CreatedBy", "DangPD");
            parameters.Add("v_ModifiedDate", DateTime.Now);
            parameters.Add("v_ModifiedBy", "DangPD");
            // Gọi vào db và trả về số bản ghi bị ảnh hưởng
            int numberOfAffectedRows = 0;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                numberOfAffectedRows = mySqlConnection.Execute(insertStoreProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            if (numberOfAffectedRows > 0)
            {
                return orders;
            }
            else
            {
                return null;
            }
        }
        // Insert Orderdetail
        public object InsertOrdersDetail(OrderDetail record)
        {
            // Chuẩn bị tên store procedure
            string insertStoreProcedureName = String.Format(ProceduceName.Insert, typeof(Orders).Name);
            // Chuẩn bị tham số cho procedure
            var parameters = new DynamicParameters();

            var properties = typeof(Orders).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = $"v_{property.Name}";
                var propertyValue = property.GetValue(record);
                parameters.Add(propertyName, propertyValue);
            }

            parameters.Add("v_CreatedDate", DateTime.Now);
            parameters.Add("v_CreatedBy", "DangPD");
            parameters.Add("v_ModifiedDate", DateTime.Now);
            parameters.Add("v_ModifiedBy", "DangPD");
            // Gọi vào db và trả về số bản ghi bị ảnh hưởng
            int numberOfAffectedRows = 0;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                numberOfAffectedRows = mySqlConnection.Execute(insertStoreProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            if (numberOfAffectedRows > 0)
            {
                return record;
            }
            else
            {
                return null;
            }
        }


        public object GetOrdersByCode(string code)
        {
            // Chuẩn bị tên store procedure
            string getOneRecordstoreProcedureName = "Proc_Orders_GetByCode";

            //Truyền tham số cho procedure
            var parameters = new DynamicParameters();

            parameters.Add("v_OrderCode", code);

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Query
                return mySqlConnection.QueryFirstOrDefault<Orders>(getOneRecordstoreProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

        }


        public bool InsertBulk<OrderDetail>(IEnumerable<OrderDetail> listInsert)
        {
            int total = 0;
            foreach (var orderDetail in listInsert)
            {
                // Chuẩn bị tên store procedure
                string insertStoreProcedureName = String.Format(ProceduceName.Insert, typeof(OrderDetail).Name);
                // Chuẩn bị tham số cho procedure
                var parameters = new DynamicParameters();

                var properties = typeof(OrderDetail).GetProperties();
                foreach (var property in properties)
                {
                    var propertyName = $"v_{property.Name}";
                    var propertyValue = property.GetValue(orderDetail);
                    parameters.Add(propertyName, propertyValue);
                }
                // Gọi vào db và trả về số bản ghi bị ảnh hưởng
                int numberOfAffectedRows = 0;
                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    numberOfAffectedRows = mySqlConnection.Execute(insertStoreProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }

                if (numberOfAffectedRows > 0)
                {
                    total += 1;
                }
            }
            int totalList = Convert.ToInt16(listInsert.Count());
            if (total != totalList)
            {
                return false;
            }
            return true;
        }

        public Orders InsertOrderDetail(Orders order, List<OrderDetail> listOrderDetail, List<Product> listProductDetail)
        {

            var result = InsertOrder(order);
            if (result != null)
            {
                order = (Orders)result;

                order = (Orders)GetOrdersByCode(order.orderCode);
                if (order != null)
                {
                    foreach (var item in listOrderDetail)
                    {
                        item.orderID = order.orderID;
                    }
                    bool isSuccess = InsertBulk(listOrderDetail);
                    if (!isSuccess)
                    {
                        return null;
                    }
                }
                return order;
            }
            else
            {
                return null;
            }
        }


        public bool UpdateOrders(Orders record, int idRecord)
        {
            // Chuẩn bị tên store procedure
            string updateStoredProcedureName = String.Format(ProceduceName.Update, typeof(Orders).Name);

            var properties = typeof(Orders).GetProperties();
            var parameters = new DynamicParameters();

            // Lấy key attribute
            foreach (var property in properties)
            {
                // Set key id cập nhật bằng id truyền vào
                var keyAttribute = (KeyAttribute?)property.GetCustomAttribute(typeof(KeyAttribute), false);
                if (keyAttribute != null)
                {
                    parameters.Add($"v_{property.Name}", idRecord);
                }
                var propertyName = $"v_{property.Name}"; // Tạo biến cho đầu vào cho store procedure
                var propertyValue = property.GetValue(record); // Lấy giá có thuộc tính propertyName của record
                parameters.Add(propertyName, propertyValue);
            }

            parameters.Add("v_ModifiedDate", DateTime.Now);
            parameters.Add("v_ModifiedBy", "DangPD");

            // Số bản ghi bị ảnh hưởng
            int numberOfAffectedRow = 0;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Số bản ghi bị tác động
                numberOfAffectedRow = mySqlConnection.Execute(updateStoredProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            if (numberOfAffectedRow > 0)
            {
                return true;
            }
            return false;
        }
        // update san pham
        public bool UpdateOrderDetailProduct(IEnumerable<OrderDetail> listInsert, List<Product> listProduct)
        {
            int totalRecordUpdate = 0;
            int totalRecordBuy = Convert.ToInt16(listInsert.Count());
            // update product thanhf coong true khong thi false
            // Trừ sản phẩm trong database
            foreach (var item in listInsert)
            {
                Product currentProduct = listProduct.Find(x => x.ProductID == item.productID);
                if(item.quantitys > currentProduct.Quantity)
                {
                    return false;
                }
                int productID = item.productID;
                int quantity = currentProduct.Quantity - item.quantitys;
                int quantitySell = currentProduct.QuantitySell + item.quantitys;
                // Chuẩn bị tên store procedure
                string updateStoredProcedureName = "Proc_ProductOrdersDetail_Update";

                var parameters = new DynamicParameters();
                parameters.Add("v_ProductID", productID);
                parameters.Add("v_QuantitySell", quantitySell);
                parameters.Add("v_Quantity", quantity );

                // Số bản ghi bị ảnh hưởng
                int numberOfAffectedRow = 0;
                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    // Số bản ghi bị tác động
                    numberOfAffectedRow = mySqlConnection.Execute(updateStoredProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                if(numberOfAffectedRow > 0)
                {
                    totalRecordUpdate++;
                }
                else
                {
                    totalRecordUpdate = 0;
                }
            }
            if(totalRecordUpdate == totalRecordBuy)
            {
                return true;
            }
            return false;
        }

        public bool UpdateOrderDetail(Orders order, List<OrderDetail> listOrderDetail, List<Product> listProduct)
        {
            // update thông tin đơn hàng 
            bool updateOrder = UpdateOrders(order, order.orderID);
            if (!updateOrder)
            {
                return false;
            }
            else
            {
                int statusOrder = order.statusOrders;
                // Trạng thái xác nhận đơn hàng thành công
                if (statusOrder == 1)
                {
                    // Update số sản phẩm bán,sản phẩm trong kho
                    bool updateProduct = UpdateOrderDetailProduct(listOrderDetail, listProduct);
                    if (!updateProduct)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Lấy sản phẩm theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetListProductByListID(int id)
        {
            string query = "Proc_Product_GetByID";
            DynamicParameters dynamicParam = new DynamicParameters();
            dynamicParam.Add("v_ProductID", id);
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Query
                var result = mySqlConnection.QueryFirstOrDefault<Product>(query, dynamicParam, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }

        public object getOrderByUserID(int userId)
        {
            // Chuẩn bị tên store procedure
            string getOneRecordstoreProcedureName = "Proc_Orders_ByIDUser";

            //Truyền tham số cho procedure
            var parameters = new DynamicParameters();
            parameters.Add("v_UserID", userId);

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Query
                return mySqlConnection.Query(getOneRecordstoreProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }

        public List<int> getReportRevenueByBranch(TimeParam param)
        {
            string storeName = "select COALESCE(sum(m.totalprice),0) from branch b left join (select case when s.deliverprice is null then s.totalprice else s.totalprice - s.deliverprice end as totalprice,s.branchid,s.branchname from saleorder s where date(s.orderdate) >= date(@startdate) and date(s.orderdate) <= date(@enddate) and s.statusid = 1) as m on b.idbranch = m.branchid group by b.idbranch order by b.idbranch desc;";
            DynamicParameters dynamicParam = new DynamicParameters();
            dynamicParam.Add("@startdate", param.startDate);
            dynamicParam.Add("@enddate", param.endDate);
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                return mySqlConnection.Query<int>(storeName, dynamicParam, commandType: System.Data.CommandType.Text).ToList();
            }
            //return _dbHelper.Query<int>(storeName, dynamicParam, System.Data.CommandType.Text);
        }
        
        /// <summary>
        /// báo cáo 1
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Orders> getReportRevenueByYear(ReportRevenueByYearParam param)
        {
            string storeName = "Proc_GetReportRevenueByYear";
            DynamicParameters dynamicParam = new DynamicParameters();
            dynamicParam.Add("v_branchid", param.branchid);
            dynamicParam.Add("v_year", param.year);
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                return mySqlConnection.Query<Orders>(storeName, dynamicParam, commandType:System.Data.CommandType.StoredProcedure).ToList();

            }

        }
    }
}
