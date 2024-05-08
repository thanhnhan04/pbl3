using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using PBL3_CNPM.Models;

namespace PBL3_CNPM
{
    public class DataProvider
    {
        private string connectionSTR = @"Data Source=DESKTOP-SP2HFDB;Initial Catalog=QUANLYNHANVIENKHACHSAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private SqlConnection connection;
        public DataProvider()
        {
            connection = new SqlConnection(connectionSTR);
            connection.Open();
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataTable ExecuteQuery(string query)
        {
            SqlConnection connection = new SqlConnection(connectionSTR);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public SqlDataReader ExecuteReader(string query, string IdUser)
        {
            SqlConnection connection = new SqlConnection(connectionSTR);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaNV", IdUser);
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public int GetIdentity(string query)
        {
            int identity = -1;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        identity = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                       
                        
                    }
                }
            }

            return identity;
        }

        public bool Kiemtra(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}

