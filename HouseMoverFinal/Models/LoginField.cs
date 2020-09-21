using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HouseMoverFinal.Models
{
    public class LoginField
    {
        public String userName { get; set; }
        public String userPassword { get; set; }

        SqlConnection sqlConn;
        String connection_String = "Data Source=DESKTOP-G2UGPMF\\SQLEXPRESS;Initial Catalog=HouseMover;Integrated Security=True";
        SqlCommand sqlCmd;
        SqlDataReader sqlDatareader;

        public DataTable Login(String query)
        {
            DataTable tbl = new DataTable();


            sqlConn = new SqlConnection(connection_String);

            sqlConn.Open();
            sqlCmd = new SqlCommand(query, sqlConn);

            sqlDatareader = sqlCmd.ExecuteReader();

            tbl.Load(sqlDatareader);

            sqlConn.Close();
            return tbl;

        }

    }
}