﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosAppServices
{
    internal class AccesoDatos
    {
        private SqlConnection conex;
        private SqlCommand command;
        private SqlDataReader reader;

        public SqlDataReader Reader { get { return reader; } }

        public AccesoDatos()
        {
            conex = new SqlConnection();
            command = new SqlCommand();

            conex.ConnectionString = ConfigurationManager.AppSettings["ConexionString"];
        }

        public void setQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }

        public void setParams(string name, object value)
        {
            command.Parameters.AddWithValue(name, value);
        }

        public void executeSelectionQuery()
        {
            command.Connection = conex;

            try
            {
                conex.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                conex.Close();
                throw new Exception("Error al intentar acceder a la base de datos", ex);
            }

        }
        public void executeActionQuery()
        {
            command.Connection = conex;

            try
            {
                conex.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                conex.Close();
                throw new Exception("Error al intentar acceder a la base de datos", ex);
            }


        }
        public void closeConnection()
        {
            if (reader != null && !reader.IsClosed)
                reader.Close();

            conex.Close();
        }
    }
}
