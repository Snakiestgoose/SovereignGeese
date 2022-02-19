using Data.Factory._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factory.Dev
{
    public class DevFactory : FactoryBase
    {
        public DevFactory()
        {
            GetConnectionString(true);
        }

        #region Select

        public int GetDevUserId()
        {
            int devUserId = 0;
            InitDataObjects();
            command.CommandText = "SELECT * FROM dev.test_table WHERE id = 1;";

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    devUserId = reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                CloseDataObjects();
            }
            return devUserId;
        }

        #endregion


    }
}
