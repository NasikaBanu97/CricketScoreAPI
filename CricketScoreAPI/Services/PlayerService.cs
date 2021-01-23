using CricketScoreAPI.Model;
using CricketScoreAPI.Services.Interface;
using CricketScoreAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreAPI.Services
{
    public class PlayerService : IPlayer
    {
        public JsonResponse AddPlayer(Player model)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                SqlParameter[] objParam = new SqlParameter[7];
                objParam[0] = new SqlParameter("@ID", model.ID);
                objParam[1] = new SqlParameter("@FirstName", model.FirstName);
                objParam[2] = new SqlParameter("@LastName", model.LastName);
                objParam[3] = new SqlParameter("@TeamID", model.TeamID);
                objParam[4] = new SqlParameter("@RoleID", model.RoleID);
                objParam[5] = new SqlParameter("@Profile", model.Profile);
                objParam[6] = new SqlParameter("@Flag", 1);
                DataSet dataSet = CommonFunctions.ExecuteDataset(CommonFunctions.Procedures.ManagePlayers, objParam);
                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    // check 1st table  session exist or not
                    DataTable statusDataTable = dataSet.Tables[0];
                    if (statusDataTable != null && statusDataTable.Rows.Count > 0 && statusDataTable.Rows[0]["STATUS"] != null && statusDataTable.Rows[0]["STATUS"].ToString() == "S")
                    {
                        jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                        jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                    }
                    else
                    {
                        jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                        jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                    }
                }
                else
                {
                    jsonResponse.Status = CommonFunctions.ResponseStatus.Failed;
                    jsonResponse.Message = CommonFunctions.ResponseMessages.ServerError;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jsonResponse;
        }

        public JsonResponse DeletePlayerByID(int ID)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                if (ID != 0)
                {
                    SqlParameter[] objParam = new SqlParameter[2];
                    objParam[0] = new SqlParameter("@Flag", 5);
                    objParam[1] = new SqlParameter("@ID", ID);
                    DataSet dataSet = CommonFunctions.ExecuteDataset(CommonFunctions.Procedures.ManagePlayers, objParam);
                    if (dataSet != null && dataSet.Tables.Count > 0)
                    {
                        DataTable statusDataTable = dataSet.Tables[0];
                        if (statusDataTable != null && statusDataTable.Rows.Count > 0 && statusDataTable.Rows[0]["STATUS"] != null && statusDataTable.Rows[0]["STATUS"].ToString() == "S")
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                        }
                        else
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                        }
                    }
                    else
                    {
                        jsonResponse.Status = CommonFunctions.ResponseStatus.Failed;
                        jsonResponse.Message = CommonFunctions.ResponseMessages.ServerError;
                    }
                }
                else
                {
                    jsonResponse.Status = CommonFunctions.ResponseStatus.Failed;
                    jsonResponse.Message = CommonFunctions.ResponseMessages.ServerError;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jsonResponse;

        }

        public JsonResponse FetchAllPlayer()
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                    SqlParameter[] objParam = new SqlParameter[1];
                    objParam[0] = new SqlParameter("@Flag", 3);
                    DataSet dataSet = CommonFunctions.ExecuteDataset(CommonFunctions.Procedures.ManagePlayers, objParam);
                    if (dataSet != null && dataSet.Tables.Count > 0)
                    {
                        // check 1st table  session exist or not
                        DataTable statusDataTable = dataSet.Tables[0];
                        if (statusDataTable != null && statusDataTable.Rows.Count > 0 && statusDataTable.Rows[0]["STATUS"] != null && statusDataTable.Rows[0]["STATUS"].ToString() == "S")
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                            if (dataSet.Tables.Count > 1)
                            {
                                if (dataSet.Tables[1] != null && dataSet.Tables[1].Rows.Count > 0)
                                {
                                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                                    Dictionary<string, object> row;
                                    foreach (DataRow dr in dataSet.Tables[1].Rows)
                                    {
                                        row = new Dictionary<string, object>();
                                        foreach (DataColumn col in dataSet.Tables[1].Columns)
                                        {
                                            row.Add(col.ColumnName, dr[col]);
                                        }
                                        rows.Add(row);
                                    }
                                    jsonResponse.Data = rows;
                                }
                            }
                            else
                            {
                                jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                                jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                            }
                        }
                        else
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                        }
                    }
                    else
                    {
                        jsonResponse.Status = CommonFunctions.ResponseStatus.Failed;
                        jsonResponse.Message = CommonFunctions.ResponseMessages.ServerError;
                    }
                }
            
            catch (Exception ex)
            {
                throw ex;
            }
            return jsonResponse;

        }

        public JsonResponse FetchPlayerByID(int ID)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                if (ID != 0)
                {
                    SqlParameter[] objParam = new SqlParameter[2];
                    objParam[0] = new SqlParameter("@Flag", 4);
                    objParam[1] = new SqlParameter("@ID", ID);
                    DataSet dataSet =  CommonFunctions.ExecuteDataset( CommonFunctions.Procedures.ManagePlayers, objParam);
                    if (dataSet != null && dataSet.Tables.Count > 0)
                    {
                        // check 1st table  session exist or not
                        DataTable statusDataTable = dataSet.Tables[0];
                        if (statusDataTable != null && statusDataTable.Rows.Count > 0 && statusDataTable.Rows[0]["STATUS"] != null && statusDataTable.Rows[0]["STATUS"].ToString() == "S")
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                            if (dataSet.Tables.Count > 1)
                            {
                                if (dataSet.Tables[1] != null && dataSet.Tables[1].Rows.Count > 0)
                                {
                                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                                    Dictionary<string, object> row;
                                    foreach (DataRow dr in dataSet.Tables[1].Rows)
                                    {
                                        row = new Dictionary<string, object>();
                                        foreach (DataColumn col in dataSet.Tables[1].Columns)
                                        {
                                            row.Add(col.ColumnName, dr[col]);
                                        }
                                        rows.Add(row);
                                    }
                                    jsonResponse.Data = rows;
                                }
                            }
                            else
                            {
                                jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                                jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                            }
                        }
                        else
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                        }
                    }
                    else
                    {
                        jsonResponse.Status = CommonFunctions.ResponseStatus.Failed;
                        jsonResponse.Message = CommonFunctions.ResponseMessages.ServerError;
                    }
                }
                else
                {
                    jsonResponse.Status = CommonFunctions.ResponseStatus.Failed;
                    jsonResponse.Message = CommonFunctions.ResponseMessages.ServerError;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jsonResponse;
        }

        public JsonResponse UpdatePlayer(Player model)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                if (model.ID != 0)
                {
                    SqlParameter[] objParam = new SqlParameter[7];
                 objParam[0] = new SqlParameter("@ID", model.ID);
                objParam[1] = new SqlParameter("@FirstName", model.FirstName);
                objParam[2] = new SqlParameter("@LastName", model.LastName);
                objParam[3] = new SqlParameter("@TeamID", model.TeamID);
                objParam[4] = new SqlParameter("@RoleID", model.RoleID);
                objParam[5] = new SqlParameter("@Profile", model.Profile);
                objParam[6] = new SqlParameter("@Flag", 2);
                    DataSet dataSet = CommonFunctions.ExecuteDataset(CommonFunctions.Procedures.ManagePlayers, objParam);
                    if (dataSet != null && dataSet.Tables.Count > 0)
                    {
                        // check 1st table  session exist or not
                        DataTable statusDataTable = dataSet.Tables[0];
                        if (statusDataTable != null && statusDataTable.Rows.Count > 0 && statusDataTable.Rows[0]["STATUS"] != null && statusDataTable.Rows[0]["STATUS"].ToString() == "S")
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                        }
                        else
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                        }
                    }
                    else
                    {
                        jsonResponse.Status = CommonFunctions.ResponseStatus.Failed;
                        jsonResponse.Message = CommonFunctions.ResponseMessages.ServerError;
                    }
                }
                else
                {
                    jsonResponse.Status = CommonFunctions.ResponseStatus.Failed;
                    jsonResponse.Message = CommonFunctions.ResponseMessages.ServerError;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return jsonResponse;
        }
    }
}
