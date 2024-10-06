using MySql.Data.MySqlClient;
using System.Data;

namespace Web_API.DAL
{
    public sealed class DataAccessparameters
    {
        public string dbName { get; set; } = "MasterDB";
        public string ConnString { get; set; } = "Server=127.0.0.1;Database={0};Uid=root;Pwd=123456;";
        public string CommandName { get; set; }
        public CommandType CommandType { get; set; }
        public List<MySqlParameter> MySQLParams { get; set; } = new List<MySqlParameter>();
        public Action<MySqlDataReader,object> ActionMapper { get; set; }
    }
    public sealed class dbhelper
    {
        public async Task<bool> ExecuteNonQuery(DataAccessparameters parems)
        {
            string ConnString = string.Format(parems.ConnString, parems.dbName);

            using (MySqlConnection conn = new MySqlConnection(ConnString))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(parems.CommandName, conn))
                    {
                        cmd.CommandType = parems.CommandType;
                        int i = 0;
                        while (i < parems.MySQLParams.Count)
                        {
                            cmd.Parameters.Add(parems.MySQLParams[i]);
                            i++;
                        }
                        await conn.OpenAsync();

                        return Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.GetBaseException().Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.GetBaseException().Message);
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
        }
        public async Task<List<T>> ExecuteQuery<T>(DataAccessparameters parems) where T : new()
        {
            string ConnString = string.Format(parems.ConnString, parems.dbName);

            using (MySqlConnection conn = new MySqlConnection(ConnString))
            {
                try
                {
                    List<T> resultList = new List<T>();

                    using (MySqlCommand cmd = new MySqlCommand(parems.CommandName, conn))
                    {
                        cmd.CommandType = parems.CommandType;
                        int i = 0;
                        while (i < parems.MySQLParams.Count)
                        {
                            cmd.Parameters.Add(parems.MySQLParams[i]);
                            i++;
                        }
                        await conn.OpenAsync();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                T model = new T();
                                parems.ActionMapper(reader, model);
                                resultList.Add(model);
                            }
                        }
                        return resultList;
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.GetBaseException().Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.GetBaseException().Message);
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
        }
    }
}
