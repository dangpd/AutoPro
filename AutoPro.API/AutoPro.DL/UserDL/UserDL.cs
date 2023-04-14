﻿using AutoPro.Common.Entities;
using AutoPro.Common.Entities.Param;
using AutoPro.Common.ProceduceName;
using AutoPro.DL.BaseDL;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPro.DL.UserDL
{
    public class UserDL : BaseDL<User>, IUserDL
    {


        /// <summary>
        /// Khởi tạo lấy kết nối đường dẫn database
        /// </summary>
        string connectionString = DatabaseContext.ConnectionString;
        public object checkLogin(string Account, string Password)
        {
            // Chuẩn bị tên stored proceduce
            string queryLogin = String.Format(ProceduceName.Login, typeof(User).Name);

            // Tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("v_Account", Account);
            parameters.Add("v_Password", Password);

            // Kết nối db
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                var results = mySqlConnection.QueryFirstOrDefault(queryLogin, parameters, commandType: System.Data.CommandType.StoredProcedure);
                // Return kêt quả
                return results;
            }
        }

        /// <summary>
        /// Kiểm tra tồn tại
        /// </summary>
        /// <param name="idRecord"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsExistAccount(User? record)
        {
            // Chuẩn bị tên stored proceduce
            string ExistRecord = String.Format(ProceduceName.IsExistAccount, typeof(User).Name);

            // Tham số đầu vào
            var parameter = new DynamicParameters();
            parameter.Add("v_Account", record.Account);

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Số bản ghi bị tác động
                var numberOfAffectedRow = mySqlConnection.QueryFirstOrDefault<int>(ExistRecord, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (numberOfAffectedRow > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsExistEmail(User? record)
        {
            // Chuẩn bị tên stored proceduce
            string ExistRecord = String.Format(ProceduceName.IsExistEmail, typeof(User).Name);

            // Tham số đầu vào
            var parameter = new DynamicParameters();
            parameter.Add("v_Email", record.Email);

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Số bản ghi bị tác động
                var numberOfAffectedRow = mySqlConnection.QueryFirstOrDefault<int>(ExistRecord, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (numberOfAffectedRow > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
