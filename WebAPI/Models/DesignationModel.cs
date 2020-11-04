using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class DesignationModel
    {
        public DataTable GetDesignation()
        {
            string conString = string.Empty;
            string spName = string.Empty;
            DataTable dataTable = new DataTable();
            conString = ConfigurationManager.ConnectionStrings["DoctorDatabase"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(conString))
            {
                spName = "[dbo].[GetAll_Designations]";
                using (SqlCommand sqlcmnd = new SqlCommand())
                {
                    sqlcmnd.CommandType = CommandType.StoredProcedure;
                    sqlcmnd.CommandText = spName;
                    sqlcmnd.Connection = sqlconn;
                    using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlcmnd))
                    {
                        sqlDataAdap.Fill(dataTable);
                    }
                }
            }
            return (dataTable);
        }

        //public int AddUpdateDesignation(Designation design)
        //{
        //    string conString = string.Empty;
        //    string spName = string.Empty;
        //    DataTable dataTable = new DataTable();
        //    int myResult = 0;
        //    conString = ConfigurationManager.ConnectionStrings["DoctorDatabase"].ConnectionString;
        //    using (SqlConnection sqlconn = new SqlConnection(conString))
        //    {
        //        spName = "[dbo].[AddUpdateDesignation]";
        //        using (SqlCommand sqlcmnd = new SqlCommand())
        //        {
        //            sqlcmnd.CommandType = CommandType.StoredProcedure;
        //            sqlcmnd.CommandText = spName;
        //            sqlcmnd.Connection = sqlconn;
        //            sqlcmnd.Parameters.AddWithValue("@DesignationId", design.DesignationId);
        //            sqlcmnd.Parameters.AddWithValue("@DesignationName", design.DesignationName);
        //            sqlcmnd.Parameters.AddWithValue("@CreatedOn", design.CreatedOn);
        //            sqlcmnd.Parameters.AddWithValue("@LastUpdatedOn", design.LastUpdatedOn);
        //            sqlcmnd.Parameters.AddWithValue("@Is_Deleted", design.Is_Deleted);
        //            sqlconn.Open();
        //            myResult = sqlcmnd.ExecuteNonQuery();
        //            sqlconn.Close();
        //            using (SqlDataAdapter sqldataAdap = new SqlDataAdapter())
        //            {
        //                sqldataAdap.Fill(dataTable);
        //            }
        //        }
        //    }
        //    return myResult;
        //}
    }
    public class Designation
    {
        public Guid DesignationId { get; set; }
        public string DesignationName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public byte Is_Deleted { get; set; }
    }
}