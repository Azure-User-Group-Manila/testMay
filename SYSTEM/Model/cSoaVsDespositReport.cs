using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SYSTEM
{
    public class cSoaVsDepositReport
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();
        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_sra_report2");
            cmm.Parameters.AddWithValue("@params", "01");
            return DB.ExecuteReader(cmm);
        }
        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_sra_report2");
            cmm.Parameters.AddWithValue("@params", "02");
            cmm.Parameters.AddWithValue("@FromDate", FromDate);
            cmm.Parameters.AddWithValue("@ToDate", ToDate);
            return DB.ExecuteReader(cmm);
        }
        public DataTable Search()
        {
            cmm = DB.SqlCommandSp("sp_sra_report2");
            cmm.Parameters.AddWithValue("@params", "03");
            cmm.Parameters.AddWithValue("@search", SearchString);
            return DB.ExecuteReader(cmm);
        }
        public DataTable SearchFilter()
        {
            cmm = DB.SqlCommandSp("sp_sra_report2");
            cmm.Parameters.AddWithValue("@params", "04");
            cmm.Parameters.AddWithValue("@FromDate", FromDate);
            cmm.Parameters.AddWithValue("@ToDate", ToDate);
            cmm.Parameters.AddWithValue("@search", SearchString);
            return DB.ExecuteReader(cmm);
        }
        public DataTable TransactionList()
        {
            cmm = DB.SqlCommandSp("sp_sra_report2");
            cmm.Parameters.AddWithValue("@params", "05");
            cmm.Parameters.AddWithValue("@FromDate", FromDate);
            cmm.Parameters.AddWithValue("@ToDate", ToDate);
            cmm.Parameters.AddWithValue("@search", SearchString);
            return DB.ExecuteReader(cmm);
        }
        public int Insert()
        {
            cmm = DB.SqlCommandSp("sp_maint_billing");
            cmm.Parameters.AddWithValue("@params", "01");            
            cmm.Parameters.AddWithValue("@uid", UserId);            
            cmm.Parameters.AddWithValue("@BRANCHID", BRANCHID);
            cmm.Parameters.AddWithValue("@PONumber", PONumber);
            cmm.Parameters.AddWithValue("@PODate", PODate);
            cmm.Parameters.AddWithValue("@SINumber", SINumber);
            cmm.Parameters.AddWithValue("@SIDate", SIDate);
            cmm.Parameters.AddWithValue("@DRNumber", DRNumber);
            cmm.Parameters.AddWithValue("@DRDate", DRDate);
            cmm.Parameters.AddWithValue("@SUPPLIERID", SUPPLIERID);
            cmm.Parameters.AddWithValue("@QTY", QTY);
            cmm.Parameters.AddWithValue("@UNIT_PRICE", UNIT_PRICE);
            cmm.Parameters.AddWithValue("@GROSS_VAT", GROSS_VAT);
            cmm.Parameters.AddWithValue("@VAT_AMT", VAT_AMT);
            cmm.Parameters.AddWithValue("@NET_AMT", NET_AMT);
            cmm.Parameters.AddWithValue("@REMARKS", REMARKS);
            cmm.Parameters.AddWithValue("@BILLREFNO", BILLREFNO);
            return DB.ExecuteNonQuery(cmm);
        }
        public int Update()
        {
            cmm = DB.SqlCommandSp("sp_maint_billing");
            cmm.Parameters.AddWithValue("@params", "02");
            cmm.Parameters.AddWithValue("@id", ID);
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@BRANCHID", BRANCHID);
            cmm.Parameters.AddWithValue("@PONumber", PONumber);
            cmm.Parameters.AddWithValue("@PODate", PODate);
            cmm.Parameters.AddWithValue("@SINumber", SINumber);
            cmm.Parameters.AddWithValue("@SIDate", SIDate);
            cmm.Parameters.AddWithValue("@DRNumber", DRNumber);
            cmm.Parameters.AddWithValue("@DRDate", DRDate);
            cmm.Parameters.AddWithValue("@SUPPLIERID", SUPPLIERID);
            cmm.Parameters.AddWithValue("@QTY", QTY);
            cmm.Parameters.AddWithValue("@UNIT_PRICE", UNIT_PRICE);
            cmm.Parameters.AddWithValue("@GROSS_VAT", GROSS_VAT);
            cmm.Parameters.AddWithValue("@VAT_AMT", VAT_AMT);
            cmm.Parameters.AddWithValue("@NET_AMT", NET_AMT);
            cmm.Parameters.AddWithValue("@REMARKS", REMARKS);
            cmm.Parameters.AddWithValue("@BILLREFNO", BILLREFNO);
            cmm.Parameters.AddWithValue("@PROJECT_TYPE", PROJECT_TYPE);
            return DB.ExecuteNonQuery(cmm);
        }
        public int Delete()
        {
            cmm = DB.SqlCommandSp("sp_maint_billing");
            cmm.Parameters.AddWithValue("@params", "03");
            cmm.Parameters.AddWithValue("@id", ID);
            cmm.Parameters.AddWithValue("@uid", UserId);
            return DB.ExecuteNonQuery(cmm);
        }
        public int ID { get; set; }
        public int? BRANCHID { get; set; }
        public string PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public string SINumber { get; set; }
        public DateTime? SIDate { get; set; }
        public string DRNumber { get; set; }
        public DateTime? DRDate { get; set; }
        public int? SUPPLIERID { get; set; }
        public int QTY { get; set; }
        public decimal UNIT_PRICE { get; set; }
        public decimal GROSS_VAT { get; set; }
        public decimal VAT_AMT { get; set; }
        public decimal NET_AMT { get; set; }
        public string REMARKS { get; set; }
        public string BILLREFNO { get; set; }
        public Boolean IsActive { get; set; }
        public string UserId { get; set; }
        public string SearchString { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int PROJECT_TYPE { get; set; }
    }
}