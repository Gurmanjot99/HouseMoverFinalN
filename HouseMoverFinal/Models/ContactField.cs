using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HouseMoverFinal.Models
{
	public class ContactField
	{
		public String Name { get; set; }
        public String Email { get; set; }
        public String Message { get; set; }

        SqlConnection sqlConn;
        String connection_String = "Data Source=DESKTOP-G2UGPMF\\SQLEXPRESS;Initial Catalog=HouseMover;Integrated Security=True";
        SqlCommand sqlCmd;
        SqlDataReader sqlDatareader;

        //this statement is related to insert delete update query that is the main statement of any database record 
        public void sendMessage(String Query)
        {

            sqlConn = new SqlConnection(connection_String);
            sqlConn.Open();


            sqlCmd = new SqlCommand(Query, sqlConn);
            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();

        }

    }
}