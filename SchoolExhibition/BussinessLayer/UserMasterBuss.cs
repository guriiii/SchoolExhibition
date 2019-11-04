using SchoolExhibition.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExhibition.Bussiness
{
    public class UserMasterBuss
    {
        SchoolExhibitionEntities _db = new SchoolExhibitionEntities();
        public bool LoginUser(UserVModel vmModel)//login method
        {
            bool isLogin = false;
            try
            {
                var record = (from a in _db.UserMasters
                              where a.UserName == vmModel.UserName && a.Password == vmModel.Password
                              select a).Count() > 0 ? true : false;
                if (record)
                {
                    isLogin = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isLogin;
        }
    }
}