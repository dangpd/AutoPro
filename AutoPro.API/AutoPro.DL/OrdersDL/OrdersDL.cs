using AutoPro.Common.Entities;
using AutoPro.Common.Entities.DTO;
using AutoPro.Common.ProceduceName;
using AutoPro.DL.BaseDL;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPro.DL.OrdersDL
{
    public class OrdersDL : BaseDL<Orders>, IOrdersDL
    {
        // Khởi tạo lấy kết nối đường dẫn database
        string connectionString = DatabaseContext.ConnectionString;
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

            var propertyName = $"v_OrderCode";
            parameters.Add(propertyName, code);

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

        public Orders UpdateOrderDetail(Orders order, List<OrderDetail> listOrderDetail)
        {
            //var result = Update(product, product.idsaleorder);
            //bool isSuccess = _dbHelper.UpdateBulk(listOrderDetail);
            //if (isSuccess)
            //{
            //    return product;
            //}
            return null;
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

    }
}
