using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSTEM.Model
{
    public class cErrors
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand(); 

        public int Insert()
        {
            cmm = DB.SqlCommandSp("sp_auditlogs");
            cmm.Parameters.AddWithValue("@Param", "06");
            cmm.Parameters.AddWithValue("@Module", Module);
            cmm.Parameters.AddWithValue("@ErrorDescription", ErrorDescription);
            cmm.Parameters.AddWithValue("@ParameterValues", ParamValues);
            cmm.Parameters.AddWithValue("@ErrorOccuredOn", ErrorOccursOn);
            cmm.Parameters.AddWithValue("@uid", UserId);
            return DB.ExecuteNonQuery(cmm);
        }

        public string UserId { get; set; }
        public string Module { get; set; }
        public string ErrorDescription { get; set; }
        public string ParamValues { get; set; }
        public string ErrorOccursOn { get; set; }
    }
}
