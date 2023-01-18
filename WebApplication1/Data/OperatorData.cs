using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class OperatorData
    {
        public static string Register(Operator oOperator)
        {
            using (SqlConnection oConnection = new SqlConnection(Connection.connectionPath))
            {
                SqlCommand cmd = new SqlCommand("usp_register_operator", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdentityCard", oOperator.IdentityCard);
                cmd.Parameters.AddWithValue("@NameClient", oOperator.NameClient);
                cmd.Parameters.AddWithValue("@SurnameClient", oOperator.SurnameClient);
                cmd.Parameters.AddWithValue("@DateBirth", oOperator.DateBirth);
                cmd.Parameters.AddWithValue("@Phone1", oOperator.Phone1);
                cmd.Parameters.AddWithValue("@Phone2", oOperator.Phone2);
                cmd.Parameters.AddWithValue("@Email1", oOperator.Email1);
                cmd.Parameters.AddWithValue("@Email2", oOperator.Email2);
                cmd.Parameters.AddWithValue("@Address1", oOperator.Address1);
                cmd.Parameters.AddWithValue("@Address2", oOperator.Address2);
                cmd.Parameters.Add("@Respuesta", SqlDbType.VarChar, 150);
                cmd.Parameters["@Respuesta"].Direction= ParameterDirection.Output;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    string result = Convert.ToString(cmd.Parameters["@Respuesta"].Value);
                    return result;
                }
                catch (Exception ex)
                {
                    return "Ha ocurrido un error";
                }
            }
        }

    }
}