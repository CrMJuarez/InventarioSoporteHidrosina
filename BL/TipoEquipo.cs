using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using Microsoft.Data.SqlClient;
using ML;

namespace BL
{
    public class TipoEquipo
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {

                    string query = "TipoEquipoGetAll";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    DataTable TipoEquipoTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(TipoEquipoTable);

                    if (TipoEquipoTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in TipoEquipoTable.Rows)
                        {
                            ML.TipoEquipo tipoEquipo = new ML.TipoEquipo();
                            tipoEquipo.IdTipoEquipo = int.Parse(row[0].ToString());
                            tipoEquipo.Nombre = row[1].ToString();

                            result.Objects.Add(tipoEquipo);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro registro del equipo";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }

        public static ML.Result GetById(int IdTipoEquipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {

                    string query = "TipoEquipoGetById";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdTipoEquipo", SqlDbType.Int);
                    collection[0].Value = IdTipoEquipo;
                    cmd.Parameters.AddRange(collection);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        DataTable modeloTable = new DataTable();
                        da.Fill(modeloTable);
                        cmd.Connection.Open();

                        if (modeloTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            DataRow row = modeloTable.Rows[0];
                            ML.TipoEquipo tipoEquipo = new ML.TipoEquipo();
                            tipoEquipo.IdTipoEquipo = int.Parse(row[0].ToString());
                            tipoEquipo.Nombre = row[1].ToString();
                            result.Object = tipoEquipo;
                            result.Correct = true;



                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se encontro registro del equipo";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }

        public static ML.Result Add(ML.TipoEquipo tipoEquipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "TipoEquipoAdd";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = tipoEquipo.Nombre;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
        public static ML.Result Update(ML.TipoEquipo tipoEquipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "TipoEquipoUpdate";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[2];

                    collection[0] = new SqlParameter("@IdTipoEquipo", SqlDbType.VarChar);
                    collection[0].Value = tipoEquipo.IdTipoEquipo;
                    collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = tipoEquipo.Nombre;
                
                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
        public static ML.Result Delete(ML.TipoEquipo tipoEquipo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "TipoEquipoDelete";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdTipoEquipo", SqlDbType.Int);
                    collection[0].Value = tipoEquipo.IdTipoEquipo;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
