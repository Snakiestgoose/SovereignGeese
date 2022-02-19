using MySqlConnector;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Microsoft.Extensions.Hosting;

namespace Data.Factory._Base
{
    public class FactoryBase
    {
        protected string _connectionString;
        protected MySqlConnection connection;
        protected MySqlCommand command;
        protected MySqlDataReader reader;

        protected void GetConnectionString(bool local = false)
        {
            try
            {
                var connections = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.Debug_Local.json", optional: true, reloadOnChange: true).Build().GetSection("ConnectionStrings");
                _connectionString = connections["DevDB"];


                // Connection String without building appsettings environment
                //var connections = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings");
                //_connectionString = connections["DevDB"];
            }
            // FileNotFound throws if can't find the appsettings file
            catch (FileNotFoundException ex)
            {
                // Conneciton String from app.config for testing out of Data.Factory
                if (local)
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["DevLocal"]?.ConnectionString ?? "";
                }
                else
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["DevDB"]?.ConnectionString ?? "";
                }
            }
        }


        protected void InitDataObjects()
        {
            connection = new MySqlConnection(_connectionString);
            command = new MySqlCommand();
            command.Connection = connection;
        }

        protected void CloseDataObjects()
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
                reader = null;
            }

            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }

            if (command != null)
            {
                command.Dispose();
            }
        }
    }
}
