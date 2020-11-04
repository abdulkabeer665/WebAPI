using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using WebAPI.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebAPI.Controllers
{
    public class DesignationController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dataTable = null;
            DesignationModel designModel = new DesignationModel();
            dataTable = designModel.GetDesignation();
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        [HttpPost]
        public string Post(Designation design)
        {
            try
            {
                string spName = string.Empty;
                string conString = string.Empty;
                string message = string.Empty;
                DataTable dataTable = new DataTable();
                conString = ConfigurationManager.ConnectionStrings["DoctorDatabase"].ConnectionString;
                using (SqlConnection sqlconn = new SqlConnection(conString))
                {
                    spName = "[dbo].[AddUpdateDesignation]";
                    using (SqlCommand sqlcmnd = new SqlCommand())
                    {
                        sqlcmnd.CommandType = CommandType.StoredProcedure;
                        sqlcmnd.CommandText = spName;
                        sqlcmnd.Connection = sqlconn;
                        sqlcmnd.Parameters.AddWithValue("@DesignationName", design.DesignationName);
                        //sqlcmnd.Parameters.AddWithValue("@Is_Deleted", design.Is_Deleted);
                        sqlcmnd.Parameters.Add("@RequestedOutputMessage", SqlDbType.NVarChar, -1);
                        sqlcmnd.Parameters["@RequestedOutputMessage"].Direction = ParameterDirection.Output;
                        sqlconn.Open();
                        sqlcmnd.ExecuteNonQuery();
                        sqlconn.Close();
                        message = sqlcmnd.Parameters["@RequestedOutputMessage"].Value.ToString();
                        using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlcmnd))
                        {
                            sqlDataAdap.Fill(dataTable);
                        }
                    }
                    return message;
                }
            }
            catch (Exception ex)
            {
                return "fail";                
            }
        }
        public string Put(Designation design)
        {
            try
            {
                string spName = string.Empty;
                string conString = string.Empty;
                string message = string.Empty;
                DataTable dataTable = new DataTable();
                conString = ConfigurationManager.ConnectionStrings["DoctorDatabase"].ConnectionString;
                using (SqlConnection sqlconn = new SqlConnection(conString))
                {
                    spName = "[dbo].[AddUpdateDesignation]";
                    using (SqlCommand sqlcmnd = new SqlCommand())
                    {
                        sqlcmnd.CommandType = CommandType.StoredProcedure;
                        sqlcmnd.CommandText = spName;
                        sqlcmnd.Connection = sqlconn;
                        sqlcmnd.Parameters.AddWithValue("@DesignationId", design.DesignationId);
                        sqlcmnd.Parameters.AddWithValue("@DesignationName", design.DesignationName);
                        sqlcmnd.Parameters.AddWithValue("@LastUpdatedOn", design.LastUpdatedOn);
                        sqlcmnd.Parameters.Add("@RequestedOutputMessage", SqlDbType.NVarChar, -1);
                        sqlcmnd.Parameters["@RequestedOutputMessage"].Direction = ParameterDirection.Output;
                        sqlconn.Open();
                        sqlcmnd.ExecuteNonQuery();
                        sqlconn.Close();
                        message = sqlcmnd.Parameters["@RequestedOutputMessage"].Value.ToString();
                        using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlcmnd))
                        {
                            sqlDataAdap.Fill(dataTable);
                        }
                    }
                    return message;
                }
            }
            catch (Exception ex)
            {

                return "fail";

            }
        }
        public string Delete(Designation design)
        {
            try
            {
                string message = string.Empty;
                string spName = string.Empty;
                string conString = string.Empty;
                DataTable dataTable = new DataTable();
                conString = ConfigurationManager.ConnectionStrings["DoctorDatabase"].ConnectionString;
                using (SqlConnection sqlconn = new SqlConnection(conString))
                {
                    spName = "[dbo].[AddUpdateDesignation]";
                    using (SqlCommand sqlcmnd = new SqlCommand())
                    {
                        sqlcmnd.CommandType = CommandType.StoredProcedure;
                        sqlcmnd.CommandText = spName;
                        sqlcmnd.Connection = sqlconn;
                        sqlcmnd.Parameters.AddWithValue("@DesignationId", design.DesignationId);
                        //sqlcmnd.Parameters.AddWithValue("@DesignationName", design.DesignationName);
                        sqlcmnd.Parameters.AddWithValue("@Is_Deleted", design.Is_Deleted);
                        sqlcmnd.Parameters.Add("@RequestedOutputMessage", SqlDbType.NVarChar, -1);
                        sqlcmnd.Parameters["@RequestedOutputMessage"].Direction = ParameterDirection.Output;
                        sqlconn.Open();
                        sqlcmnd.ExecuteNonQuery();
                        sqlconn.Close();
                        message = sqlcmnd.Parameters["@RequestedOutputMessage"].Value.ToString();
                        using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlcmnd))
                        {
                            sqlDataAdap.Fill(dataTable);
                        }
                    }
                }
                    return message;
            }
            catch(Exception ex)
            {
                return "fail";
            }

        }
    }
}
