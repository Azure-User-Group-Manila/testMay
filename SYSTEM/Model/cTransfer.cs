using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SYSTEM
{
    public class cTransfer
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();
        public int Insert(ref string result)
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@Params"           , "01");
            cmm.Parameters.AddWithValue("@Transfer_Number"  , Transfer_Number);
            cmm.Parameters.AddWithValue("@Transfer_Date"    , Transfer_Date);
            cmm.Parameters.AddWithValue("@Transfer_Status"  , Transfer_Status);
            cmm.Parameters.AddWithValue("@Shop_ID"          , Shop_ID);
            cmm.Parameters.AddWithValue("@Inbound_ID"       , Inbound_ID);
            cmm.Parameters.AddWithValue("@Department_ID"    , Department_ID);
            cmm.Parameters.AddWithValue("@Sender_Name"      , Sender_Name);
            cmm.Parameters.AddWithValue("@Driver_Name"      , Driver_Name);
            cmm.Parameters.AddWithValue("@Receiver_Name"    , Receiver_Name);
            cmm.Parameters.AddWithValue("@Contact_Number"   , Contact_Number);
            cmm.Parameters.AddWithValue("@Remarks"          , Remarks);
            cmm.Parameters.AddWithValue("@uid"              , UserId);
            var _res = DB.ExecuteReader(cmm);
            return Convert.ToInt32(_res.Rows[0]["LINE_ID"]);
        }
        public int Update()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@Params"           , "02");
            cmm.Parameters.AddWithValue("@Line_id"          , HEADER_ID);
            cmm.Parameters.AddWithValue("@Transfer_Number"  , Transfer_Number);
            cmm.Parameters.AddWithValue("@Transfer_Date"    , Transfer_Date);
            cmm.Parameters.AddWithValue("@Transfer_Status"  , Transfer_Status);
            cmm.Parameters.AddWithValue("@Shop_ID"          , Shop_ID);
            cmm.Parameters.AddWithValue("@Inbound_ID"       , Inbound_ID);
            cmm.Parameters.AddWithValue("@Department_ID"    , Department_ID);
            cmm.Parameters.AddWithValue("@Sender_Name"      , Sender_Name);
            cmm.Parameters.AddWithValue("@Driver_Name"      , Driver_Name);
            cmm.Parameters.AddWithValue("@Receiver_Name"    , Receiver_Name);
            cmm.Parameters.AddWithValue("@Contact_Number"   , Contact_Number);
            cmm.Parameters.AddWithValue("@Remarks"          , Remarks);
            cmm.Parameters.AddWithValue("@uid"              , UserId);
            return DB.ExecuteNonQuery(cmm);
        }

        public int Delete()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@Params"       , "03");
            cmm.Parameters.AddWithValue("@Line_id"      , HEADER_ID);
            cmm.Parameters.AddWithValue("@uid"          , UserId);
            return DB.ExecuteNonQuery(cmm);
        }
        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_Transfer_headeader");
            cmm.Parameters.AddWithValue("@Params", "04");
            return DB.ExecuteReader(cmm);
        }
        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@Params", "05");
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteReader(cmm);
        }
        public DataTable Search()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@Params", "06");
            cmm.Parameters.AddWithValue("@SearchString", SearchString); 
            return DB.ExecuteReader(cmm);
        }
        public DataTable Export()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@Params", "06");
            cmm.Parameters.AddWithValue("@SearchString", SearchString);
            return DB.ExecuteReader(cmm);
        }
        public bool CheckDuplicate(string xTRANSFER_NUMBER)
        {
            string rvalue = "";
            try
            {
                cmm = DB.SqlCommandSp("sp_transfer_header");
                cmm.Parameters.AddWithValue("@Params", "07");
                cmm.Parameters.AddWithValue("@Transfer_Number", xTRANSFER_NUMBER);
                cmm.Parameters.AddWithValue("@IsActive", true);
                var _res = DB.ExecuteReader(cmm);
                if (_res.Rows.Count > 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                rvalue = ex.Message;
            }
            return false;
        }
        public int InsertTransferDetails()
        {
            cmm = DB.SqlCommandSp("sp_transfer_detail");
            cmm.Parameters.AddWithValue("@Params", "01");
            cmm.Parameters.AddWithValue("@Header_ID", HEADER_ID);
            cmm.Parameters.AddWithValue("@SKU_ID", SKU_ID);
            cmm.Parameters.AddWithValue("@SKU_Name", SKU_Name);
            cmm.Parameters.AddWithValue("@Model_Type", Model_Type);
            cmm.Parameters.AddWithValue("@UOM", UOM);
            cmm.Parameters.AddWithValue("@Item_quantity", Item_Quantity);
            cmm.Parameters.AddWithValue("@Sender_Notes", Sender_Notes);
            cmm.Parameters.AddWithValue("@Receiver_Notes", Receiver_Notes);
            return DB.ExecuteNonQuery(cmm);
        }

        public int UpdateTransferDetails()
        {
            cmm = DB.SqlCommandSp("sp_transfer_detail");
            cmm.Parameters.AddWithValue("@Params", "02");
            cmm.Parameters.AddWithValue("@Header_ID", HEADER_ID);
            cmm.Parameters.AddWithValue("@SKU_ID", SKU_ID);
            cmm.Parameters.AddWithValue("@SKU_Name", SKU_Name);
            cmm.Parameters.AddWithValue("@Model_Type", Model_Type);
            cmm.Parameters.AddWithValue("@UOM", UOM);
            cmm.Parameters.AddWithValue("@Item_quantity", Item_Quantity);
            cmm.Parameters.AddWithValue("@Sender_Notes", Sender_Notes);
            cmm.Parameters.AddWithValue("@Receiver_Notes", Receiver_Notes);
            return DB.ExecuteNonQuery(cmm);
        }

        public int DeleteTransferDetails()
        {
            cmm = DB.SqlCommandSp("sp_transfer_detail");
            cmm.Parameters.AddWithValue("@Params", "03");
            cmm.Parameters.AddWithValue("@Header_ID", HEADER_ID);
            cmm.Parameters.AddWithValue("@SKU_ID", SKU_ID);
            return DB.ExecuteNonQuery(cmm);
        }
        public DataTable TransferDetails() //03052016
        {
            cmm = DB.SqlCommandSp("sp_transfer_detail");
            cmm.Parameters.AddWithValue("@Params", "04");
            cmm.Parameters.AddWithValue("@Header_ID", HEADER_ID);
            return DB.ExecuteReader(cmm);
        }

        public string   SearchString    { get; set; }
        public int      Line_Id         { get; set; }
        public Boolean  isActive        { get; set; }
        public string   UserId          { get; set; }
        public string   Transfer_Number { get; set; }
        public DateTime Transfer_Date   { get; set; }
        public string   Transfer_Status { get; set; }
        public string   Shop_ID         { get; set; }
        public string   Inbound_ID      { get; set; }
        public String   Department_ID   { get; set; }
        public string   Sender_Name     { get; set; }
        public string   Receiver_Name   { get; set; }
        public string   Driver_Name     { get; set; }
        public string   Contact_Number  { get; set; }
        public string   Remarks         { get; set; }

        //PO DETAIL
        public int      DETAIL_ID       { get; set; }
        public int      HEADER_ID       { get; set; }
        public string   SKU_ID          { get; set; }
        public String   SKU_Name        { get; set; }
        public int      Item_Quantity   { get; set; }
        public String   UOM             { get; set; }
        public String   Model_Type      { get; set; }
        public String   Sender_Notes    { get; set; }
        public String   Receiver_Notes { get; set; }
        public Boolean detail_isActive  { get; set; }
    }
}