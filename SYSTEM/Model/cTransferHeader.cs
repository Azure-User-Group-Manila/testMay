using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SYSTEM
{
    public class cTransferHeader
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();
		// TRANSFER HEADERS ADD, EDIT, DELETE, LISTALL
        public int Insert()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@params", "01");            
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@Line_id", Line_ID);
            cmm.Parameters.AddWithValue("@Transfer_Status", Transfer_Status);
            cmm.Parameters.AddWithValue("@Tranasfer_Date", Transfer_Date);
            cmm.Parameters.AddWithValue("@Transfer_Number", Transfer_Number);
            cmm.Parameters.AddWithValue("@Shop_ID", Shop_ID);
            cmm.Parameters.AddWithValue("@Inbound_ID", Inbound_ID);
            cmm.Parameters.AddWithValue("@Department_ID", Department_ID);
            cmm.Parameters.AddWithValue("@Sender_Name", Sender_Name);
            cmm.Parameters.AddWithValue("@Driver_Name", Driver_Name);
            cmm.Parameters.AddWithValue("@Receiver_Name", Sender_Name);
            cmm.Parameters.AddWithValue("@Contact_Number", Contact_Number);
            cmm.Parameters.AddWithValue("@Remarks", Remarks);
            return DB.ExecuteNonQuery(cmm);
        }
        public int Update()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@params", "02");
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@Line_id", Line_ID);
            cmm.Parameters.AddWithValue("@Transfer_Status", Transfer_Status);
            cmm.Parameters.AddWithValue("@Tranasfer_Date", Transfer_Date);
            cmm.Parameters.AddWithValue("@Transfer_Number", Transfer_Number);
            cmm.Parameters.AddWithValue("@Shop_ID", Shop_ID);
            cmm.Parameters.AddWithValue("@Inbound_ID", Inbound_ID);
            cmm.Parameters.AddWithValue("@Department_ID", Department_ID);
            cmm.Parameters.AddWithValue("@Sender_Name", Sender_Name);
            cmm.Parameters.AddWithValue("@Driver_Name", Driver_Name);
            cmm.Parameters.AddWithValue("@Receiver_Name", Sender_Name);
            cmm.Parameters.AddWithValue("@Contact_Number", Contact_Number);
            cmm.Parameters.AddWithValue("@Remarks", Remarks);
            return DB.ExecuteNonQuery(cmm);
        }
        public int Delete()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@params", "03");
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@Line_id", Line_ID);
            return DB.ExecuteNonQuery(cmm);
        }
        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@params", "04");
            return DB.ExecuteReader(cmm);
        }
        public DataTable Search()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@params", "05");
            cmm.Parameters.AddWithValue("@search", SearchString);
            return DB.ExecuteReader(cmm);
        }
        public DataTable ListFilter()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@params", "06");
            cmm.Parameters.AddWithValue("@FromDate", FromDate);
            cmm.Parameters.AddWithValue("@ToDate", ToDate);
            return DB.ExecuteReader(cmm);
        }
        public DataTable SearchFilter()
        {
            cmm = DB.SqlCommandSp("sp_transfer_header");
            cmm.Parameters.AddWithValue("@params", "07");
            cmm.Parameters.AddWithValue("@search", SearchString);
            cmm.Parameters.AddWithValue("@FromDate", FromDate);
            cmm.Parameters.AddWithValue("@ToDate", ToDate);
            return DB.ExecuteReader(cmm);
        }
		// TRANSFER DETAILS ADD, EDIT, DELETE, LISTALL
        public int InsertTransferDetails()
        {
            cmm = DB.SqlCommandSp("sp_transfer_detail");
            cmm.Parameters.AddWithValue("@Params", "01");
			cmm.Parameters.AddWithValue("@UID", UserId);
            cmm.Parameters.AddWithValue("@Header_ID", Header_ID);
            cmm.Parameters.AddWithValue("@Detail_ID", Detail_ID);			
            cmm.Parameters.AddWithValue("@SKU_ID", SKU_ID);
			cmm.Parameters.AddWithValue("@SKU_Name", SKU_Name);
			cmm.Parameters.AddWithValue("@Model_Type", Model_Type);
            cmm.Parameters.AddWithValue("@UOM", UOM);
			cmm.Parameters.AddWithValue("@Item_Quantity", Item_Quantity);
            cmm.Parameters.AddWithValue("@Sender_Notes", Sender_Notes);
			cmm.Parameters.AddWithValue("@Receiver_Notes", Receiver_Notes);
            return DB.ExecuteNonQuery(cmm);
        }
        public int UpdateTransferDetails()
        {
            cmm = DB.SqlCommandSp("sp_transfer_detail");
            cmm.Parameters.AddWithValue("@Params", "02");
			cmm.Parameters.AddWithValue("@UID", UserId);
            cmm.Parameters.AddWithValue("@Header_ID", Header_ID);
			cmm.Parameters.AddWithValue("@Detail_ID", Detail_ID);			
            cmm.Parameters.AddWithValue("@SKU_ID", SKU_ID);
			cmm.Parameters.AddWithValue("@SKU_Name", SKU_Name);
			cmm.Parameters.AddWithValue("@Model_Type", Model_Type);
            cmm.Parameters.AddWithValue("@UOM", UOM);
			cmm.Parameters.AddWithValue("@Item_Quantity", Item_Quantity);
            cmm.Parameters.AddWithValue("@Sender_Notes", Sender_Notes);
			cmm.Parameters.AddWithValue("@Receiver_Notes", Receiver_Notes);
            return DB.ExecuteNonQuery(cmm);
        }
        public int DeleteTransferDetails()
        {
            cmm = DB.SqlCommandSp("sp_transfer_detail");
            cmm.Parameters.AddWithValue("@Params", "03");
			cmm.Parameters.AddWithValue("@UID", UserId);
            cmm.Parameters.AddWithValue("@Header_ID", Header_ID);
			cmm.Parameters.AddWithValue("@Detail_ID", Detail_ID);			
            cmm.Parameters.AddWithValue("@SKU_ID", SKU_ID);
            return DB.ExecuteNonQuery(cmm);
        }
		public DataTable ListTransferDetails() 
        {
            cmm = DB.SqlCommandSp("sp_transfer_detail");
            cmm.Parameters.AddWithValue("@Params", "04");
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@Transfer_Number", Transfer_Number);
            return DB.ExecuteReader(cmm);
        }
		// Transfer Header Variables
        public int 			Line_ID 		{ get; set; }
        public string 		Transfer_Status	{ get; set; }
        public DateTime? 	Transfer_Date 	{ get; set; }
        public string 		Transfer_Number { get; set; }
        public string 		Department_ID 	{ get; set; }
        public string 		Inbound_ID 		{ get; set; }
        public string 		Shop_ID 		{ get; set; }
        public string 		Driver_Name 	{ get; set; }
        public string 		Sender_Name 	{ get; set; }
        public string 		Receiver_Name 	{ get; set; }
        public string 		Contact_Number 	{ get; set; }
        public string 		Remarks 		{ get; set; }
        public string 		UserId 			{ get; set; }
        public string 		SearchString 	{ get; set; }
        public string 		FromDate 		{ get; set; }
        public string 		ToDate 			{ get; set; }
		// Transfer Detail Variables
		public int 			Header_ID 		{ get; set; }		
		public int 			Detail_ID 		{ get; set; }		
		public string		SKU_ID 			{ get; set; }		
		public string		SKU_Name		{ get; set; }		
		public string		Model_Type		{ get; set; }		
		public string		UOM				{ get; set; }		
		public int			Item_Quantity	{ get; set; }		
		public string		Sender_Notes	{ get; set; }		
		public string		Receiver_Notes	{ get; set; }		
		
    }
}