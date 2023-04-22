using AutoPro.Common.Entities;
using AutoPro.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPro.DL.UserDL
{
    public interface IUserDL : IBaseDL<User>
    {
        public object checkLogin(string Account, string Password);

        public int UpdateAdmin(User record, int idRecord);

        public bool IsExistAccount(User? record);

        public bool IsExistEmail(User? record);
    }
}
