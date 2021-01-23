using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreAPI.Utilities
{
    public static class CommonFunctions
    {
        public class ResponseStatus
        {
            public const string Success = "S";
            public const string Failed = "F";
        }

        public class ResponseMessages
        {
            public const string Success = "Success.";
            public const string Failed = "Failed";
            public const string ServerError = "Something went wrong";
        }

        public class Procedures
        {
            public const string ManagePlayers = "CricketScoreDetails";
        }

        public static DataSet ExecuteDataset(string CommandText, SqlParameter[] SqlParameters, CommandType Type = CommandType.StoredProcedure)
        {
            try
            {
                string ConnectionStringSSON = string.Empty;
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);

                var root = configurationBuilder.Build();
                ConnectionStringSSON = root.GetConnectionString("LocalDB");

                DataSet ds = new DataSet();

                using (SqlConnection con = new SqlConnection(ConnectionStringSSON))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(CommandText, con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        da.SelectCommand.CommandType = Type;
                        da.SelectCommand.CommandTimeout = 0;

                        if (SqlParameters != null)
                        {
                            da.SelectCommand.Parameters.AddRange(SqlParameters);
                        }
                        da.Fill(ds);
                    }
                }

                return ds;
            }
            catch (Exception ex)
            {
                StackTrace CallStack = new StackTrace(ex, true);
                ex.Data["ErrDescription"] = ex.Data["ErrDescription"] != null ? ex.Data["ErrDescription"] : string.Format("Error captured in {0} on Line No {1} of Method {2}", CallStack.GetFrame(0).GetFileName(), CallStack.GetFrame(0).GetFileLineNumber(), CallStack.GetFrame(0).GetMethod().ToString());
                throw ex;
            }
        }

    }

    
}
