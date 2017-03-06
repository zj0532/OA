using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;



namespace BLL
{
   public  class StringHelper
    {
       /// <summary>
       /// 加密
       /// </summary>
       /// <param name="str"></param>
       /// <returns></returns>
       public static string Encrypt(string str)
       {
           return DAL.DESEncrypt.Encrypt(str);
       }

       public static string Decrypt(string str)
       {
           return DAL.DESEncrypt.Decrypt(str);
       }


     


    }
}
