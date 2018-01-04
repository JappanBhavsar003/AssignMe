using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Reflection;
using AssignMe.Models;

namespace AssignMe.Common
{
    public class Response
    {
        public bool error { get; set; }
        public string msg { get; set; }
        public dynamic data { get; set; }
        public Response()
        {
            this.error = true;
            this.msg = "Something is wrong dude!";
            this.data = null;
        }
        public Response(bool error, string msg, dynamic data)
        {
            this.error = error;
            this.msg = msg;
            this.data = data;
        }
    }

    public class sql
    {
        // run a stored procedure that takes a parameter
        public static dynamic auth_User(string sp_name, ExtLoginParam sp_param)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                // create and open a connection object
                conn = new
                    SqlConnection("Server=(local);DataBase=AssignMe;Integrated Security=SSPI");
                conn.Open();

                // 1. create a command object identifying
                // the stored procedure
                SqlCommand cmd = new SqlCommand(
                    sp_name, conn);

                // 2. set the command object so it knows
                // to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which
                // will be passed to the stored procedure
                if(sp_param != null)
                {
                    cmd.Parameters.Add("@email", sp_param.email.ToString());
                    cmd.Parameters.Add("@pswd", sp_param.dcryptPswd.ToString());


                    //foreach (PropertyInfo p in sp_param.GetType().GetProperties())
                    //{
                    //    if (p.CanRead)
                    //    {
                    //        cmd.Parameters.Add("@" + p.Name, p.GetValue(sp_param, null));
                    //    }
                    //}
                }

                // execute the command
                //cmd.ExecuteNonQuery();

                rdr = cmd.ExecuteReader();

                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    if(rdr["error"].ToString() == "0")
                    {
                        string dataStr = rdr["data"].ToString();
                        List<string> dataListStr = dataStr.Split(',').ToList();
                        Token token = new Token(Convert.ToInt32(dataListStr[0]),Convert.ToInt32(dataListStr[1]),
                                        Convert.ToString(dataListStr[2]), Convert.ToString(dataListStr[3]),
                                        Convert.ToString(dataListStr[4]), Convert.ToString(dataListStr[5]),
                                        Convert.ToString(dataListStr[6]), Convert.ToString(dataListStr[7]));
                        return new Response(false, "done", token);
                    }
                    else
                    {
                        return new Response();
                    }
                }

                return new Response();

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
        }

        public static dynamic reg_User(string sp_name, ExtSigninParam sp_param)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                // create and open a connection object
                conn = new
                    SqlConnection("Server=(local);DataBase=AssignMe;Integrated Security=SSPI");
                conn.Open();

                // 1. create a command object identifying
                // the stored procedure
                SqlCommand cmd = new SqlCommand(
                    sp_name, conn);

                // 2. set the command object so it knows
                // to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which
                // will be passed to the stored procedure
                if (sp_param != null)
                {
                    cmd.Parameters.Add("@email", sp_param.email.ToString());
                    cmd.Parameters.Add("@pswd", sp_param.dcryptPswd.ToString());
                    cmd.Parameters.Add("@companyName", sp_param.companyName.ToString());
                    cmd.Parameters.Add("@city", sp_param.city.ToString());
                    cmd.Parameters.Add("@state", sp_param.state.ToString());
                    cmd.Parameters.Add("@mobile", sp_param.mobile.ToString());
                    cmd.Parameters.Add("@userName", sp_param.userName.ToString());
                }

                // execute the command
                //cmd.ExecuteNonQuery();

                rdr = cmd.ExecuteReader();

                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    if (rdr["error"].ToString() == "0")
                    {
                        string dataStr = rdr["data"].ToString();
                        List<string> dataListStr = dataStr.Split(',').ToList();
                        Token token = new Token(Convert.ToInt32(dataListStr[0]), Convert.ToInt32(dataListStr[1]),
                                        Convert.ToString(dataListStr[2]), Convert.ToString(dataListStr[3]),
                                        Convert.ToString(dataListStr[4]), Convert.ToString(dataListStr[5]),
                                        Convert.ToString(dataListStr[6]), Convert.ToString(dataListStr[7]));
                        return new Response(false, "done", token);
                    }
                    else
                    {
                        return new Response();
                    }
                }

                return new Response();

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
        }

    }

   
}