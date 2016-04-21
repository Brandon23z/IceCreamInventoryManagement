using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace IceCreamInventoryManagement
{
    class SQL
    {
        const string dbFileName = "database.FDB";
        public enum SQLError { none, error, unique_key_violation }

        public class SQLResult
        {
            public SQLError error;
            public int rowsAffected;
            public queryResult data;
            public SQLResult(SQLError _error, int _rowsAffected, queryResult _data = null)
            {
                error = _error;
                rowsAffected = _rowsAffected;
                data = _data;
            }
        }

        private static SQLError parseErrorCode(int errorCode)
        {
            switch (errorCode)
            {
                case 335544665:
                    return SQLError.unique_key_violation;
                    break;
                default:
                    return SQLError.error;
                    break;
            }
        }

        public class queryResult
        {
            public List<object> data;
            public Dictionary<string, int> fields;

            public queryResult(List<object> _data, Dictionary<string, int> _fields)
            {
                data = _data;
                fields = _fields;
            }

            public string getField(int row, string field)
            {
                field = field.ToUpper();
                if (row < data.Count && fields.ContainsKey(field))
                {
                    object[] o = (object[])data[row];
                    return o[fields[field]].ToString();
                }
                else
                {
                    return "";
                }
            }

        }

        public static SQLResult sqlnonquery(string sql, Dictionary<string, string> parameters = null)
        {
            try
            {
                string connectionString = "User = ADMIN; Password = masterkey; Database = " + dbFileName + "; Dialect = 3; ServerType = 1;";

                FbConnection fbConnection = new FbConnection(connectionString);
                fbConnection.Open();
                FbCommand command = new FbCommand(sql, fbConnection);
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, string> param in parameters)
                    {
                        command.Parameters.Add(param.Key, param.Value);
                    }
                }
                int rows = command.ExecuteNonQuery();
                fbConnection.Close();
                return new SQLResult(SQLError.none, rows);
            }
            catch (FbException e)
            {
                Console.WriteLine(e.Message);
                return new SQLResult(parseErrorCode(e.ErrorCode), 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new SQLResult(SQLError.error, 0);
            }
        }

        public static SQLResult sqlquery(string sql, Dictionary<string, string> parameters = null)
        {
            try
            {
                List<object> data = new List<object>();
                string connectionString = "User = ADMIN; Password = masterkey; Database = " + dbFileName + "; Dialect = 3; ServerType = 1;";
                FbConnection fbConnection = new FbConnection(connectionString);
                fbConnection.Open();
                FbTransaction fbTransaction = fbConnection.BeginTransaction();
                FbCommand command = new FbCommand(sql, fbConnection);
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, string> param in parameters)
                    {
                        command.Parameters.Add(param.Key, param.Value);
                    }
                }
                command.Transaction = fbTransaction;
                FbDataReader r = command.ExecuteReader();
                int fieldcount = r.FieldCount;
                Dictionary<string, int> fields = new Dictionary<string, int>();

                if (r.HasRows)
                {
                    for (int i = 0; i < r.FieldCount; i++)
                    {
                        fields.Add(r.GetName(i), i);
                    }

                    while (r.Read())
                    {
                        Object[] values = new Object[fieldcount];
                        r.GetValues(values);
                        data.Add(values);
                    }
                }
                fbTransaction.Commit();
                fbConnection.Close();
                queryResult res = new queryResult(data, fields);
                return new SQLResult(SQLError.none, fieldcount, res);
            }
            catch (FbException e)
            {
                Console.WriteLine(e.Message);
                return new SQLResult(parseErrorCode(e.ErrorCode), 0);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new SQLResult(SQLError.error, 0);
            }
        }
    }
}
