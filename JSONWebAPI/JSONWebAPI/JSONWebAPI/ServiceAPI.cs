using System;
using System.Data;
using System.Data.SqlClient;

namespace JSONWebAPI
{

    public class ServiceAPI : IServiceAPI
    {
        SqlConnection dbConnection;

        public ServiceAPI()
        {
            dbConnection = DBConnect.getConnection();
        }

        public void CreateNewAccount(string firstName, string lastName, string userName, string password)
        {
            if (dbConnection.State.ToString() == "Closed")
            {
                dbConnection.Open();
            }

            string query = "INSERT INTO UserDetails VALUES ('" + firstName + "','" + lastName + "','" + userName + "','" + password + "');";

            SqlCommand command = new SqlCommand(query, dbConnection);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        public DataTable GetUserDetails(string userName)
        {
            DataTable userDetailsTable = new DataTable();
            userDetailsTable.Columns.Add(new DataColumn("firstName", typeof(String)));
            userDetailsTable.Columns.Add(new DataColumn("lastName", typeof(String)));

            if (dbConnection.State.ToString() == "Closed")
            {
                dbConnection.Open();
            }

            string query = "SELECT firstName,lastName FROM UserDetails WHERE userName='" + userName + "';";

            SqlCommand command = new SqlCommand(query, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userDetailsTable.Rows.Add(reader["firstName"], reader["lastName"]);
                }
            }

            reader.Close();
            dbConnection.Close();
            return userDetailsTable;

        }

        public bool UserAuthentication(string userName, string passsword)
        {
            bool auth = false;

            if (dbConnection.State.ToString() == "Closed")
            {
                dbConnection.Open();
            }

            string query = "SELECT id FROM UserDetails WHERE userName='" + userName + "' AND password='" + passsword + "';";

            SqlCommand command = new SqlCommand(query, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                auth = true;
            }

            reader.Close();
            dbConnection.Close();

            return auth;

        }
/*
        public DataTable GetPaymentDetails()
        {

            DataTable paymentDetails = new DataTable();
            
            paymentDetails.Columns.Add("no", typeof(String));
            paymentDetails.Columns.Add("name", typeof(String));

            if (dbConnection.State.ToString() == "Closed")
            {
                dbConnection.Open();
            }

            string query = "SELECT no,name FROM Payment;";
            SqlCommand command = new SqlCommand(query, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    paymentDetails.Rows.Add(reader["no"], reader["name"]);
                }
            }

            reader.Close();
            dbConnection.Close();

            return paymentDetails;

        } */
    }
}