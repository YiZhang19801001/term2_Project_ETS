using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//..
using ETS.CustomizeExceptionLib;
using ETS.DataAccess;
using ETS.Entity;

namespace ETS.Manager
{
    public class LoginManager
    {
        //login
        
        public Result<LoginInfo> Login(string userName, string passWord)
        {
            //check input, throw exception to view
            if (userName.Trim() == "" || passWord.Trim() == "")
            {
                throw new InputEmptyException();
            }
            //call dao method , handle the exceptions
            Result<LoginInfo> result = new Result<LoginInfo>();
            try
            {

                LoginDao dao = new LoginDao();
                result.Data=dao.Login(userName, passWord);
                result.Status = enumResult.Success;

            }
            catch (Exception ex)
            {
                result.Status = enumResult.Fail;
                result.Message = ex.Message;
            }
            return result;
        }

        //change password
        public enumResult ChangePWD(string userName, string passWord1, string passWord2)
        {
            enumResult res = new enumResult();
            try
            {
                //create objects
                LoginDao dao = new LoginDao();

                //input validation
                if (passWord1 != passWord2)
                {
                    throw new PasswordNotEqualExceptions();
                }

                dao.Update(userName,passWord1);
                res = enumResult.Success;
            }
            catch (Exception)
            {
                res = enumResult.Fail;
            }
            return res;
        }

    }
}
