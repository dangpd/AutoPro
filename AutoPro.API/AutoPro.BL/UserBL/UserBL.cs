using AutoPro.BL.BaseBL;
using AutoPro.Common.Entities;
using AutoPro.Common.Entities.DTO;
using AutoPro.DL.UserDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static AutoPro.Common.Attributes.Attributes;

namespace AutoPro.BL.UserBL
{
    public class UserBL : BaseBL<User>, IUserBL
    {

        private IUserDL _userDL;

        public UserBL(IUserDL userDL) : base(userDL)
        {
            _userDL = userDL;
        }

        public object checkLogin(string Account, string Password)
        {
            return _userDL.checkLogin(Account, Password);
        }

        protected override ServiceResult ValidateCustom(User? record)
        {
            var isValid = true;

            // Trả về chuỗi lỗi
            List<string> errorList = new List<string>();

            // Lấy kết quả exist
            bool duplicateAccount = _userDL.IsExistAccount(record);
            bool duplicateEmail = _userDL.IsExistEmail(record);

            // Lấy các thuộc tính của record
            var props = typeof(User).GetProperties();

            foreach (var prop in props)
            {
                // Kiểm tra account
                var duplicateAccountAttribute = prop.GetCustomAttribute(typeof(DuplicateAccount), true);
                if (duplicateAccountAttribute != null)
                {
                    // Kiểm tra tồn tại
                    if (duplicateAccount)
                    {
                        isValid = false;
                        errorList.Add(Common.Resource.Resource.UserMsg_DuplicateAccount);
                    }
                }

                // Kiểm tra email
                var duplicateEmailAttribute = prop.GetCustomAttribute(typeof(DuplicateAccount), true);
                if (duplicateEmailAttribute != null)
                {
                    // Kiểm tra tồn tại
                    if (duplicateEmail)
                    {
                        isValid = false;
                        errorList.Add(Common.Resource.Resource.UserMsg_DuplicateEmail);
                    }
                }

            }
            if (!isValid)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = Common.Enum.ErrorCode.InvalidData,
                        DevMsg = Common.Resource.DataResource.DevMsg_InvalidData,
                        UserMsg = Common.Resource.DataResource.UserMsg_InvalidData,
                        MoreInfo = errorList
                    }
                };
            }
            return null;
        }
    }
}
