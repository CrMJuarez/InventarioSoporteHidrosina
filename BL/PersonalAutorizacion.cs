using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
namespace BL
{
    public class PersonalAutorizacion
    {
        public static ML.Result Add(ML.PersonalAutorizacion personalAutorizacion)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "PersonalAutorizacionAdd";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[3];

                   

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = personalAutorizacion.Nombre;

                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = personalAutorizacion.ApellidoPaterno;

                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = personalAutorizacion.ApellidoMaterno;
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
        public static ML.Result Update(ML.PersonalAutorizacion personalAutorizacion)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "personalAutorizacionUpdate";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[4];

                    collection[0] = new SqlParameter("@IdPersonalAutorizacion", SqlDbType.Int);
                    collection[0].Value = personalAutorizacion.IdPersonalAutorizacion;

                    collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = personalAutorizacion.Nombre;

                    collection[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = personalAutorizacion.ApellidoPaterno;

                    collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = personalAutorizacion.ApellidoMaterno;


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
        public static ML.Result GetById(int IdPersonalAutorizacion)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "PersonalAutorizacionGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdPersonalAutorizacion", SqlDbType.Int);
                        collection[0].Value = IdPersonalAutorizacion;

                        cmd.Parameters.AddRange(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            DataTable personalTable = new DataTable();
                            da.Fill(personalTable);
                            cmd.Connection.Open();

                            if (personalTable.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                DataRow row1 = personalTable.Rows[0];
                                ML.PersonalAutorizacion personalAutorizacion = new ML.PersonalAutorizacion();
                                personalAutorizacion.IdPersonalAutorizacion = int.Parse(row1[0].ToString());
                                personalAutorizacion.Nombre = row1[1].ToString();
                                personalAutorizacion.ApellidoPaterno = row1[2].ToString();
                                personalAutorizacion.ApellidoMaterno = row1[3].ToString();

                                result.Object = personalAutorizacion;
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontraron registros";
                            }

                        }
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "PersonalAutorizacionGetAll";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    DataTable personalTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(personalTable);

                    if (personalTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in personalTable.Rows)
                        {
                            ML.PersonalAutorizacion personalAutorizacion = new ML.PersonalAutorizacion();

                            personalAutorizacion.IdPersonalAutorizacion = int.Parse(row[0].ToString());
                            personalAutorizacion.Nombre = row[1].ToString();
                            personalAutorizacion.ApellidoPaterno = row[2].ToString();
                            personalAutorizacion.ApellidoMaterno = row[3].ToString();
                            result.Objects.Add(personalAutorizacion);
                        }
                        result.Correct = true;
                    }
                    else

                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al momento de mostrar el personal";
                    }
                    cmd.Connection.Close();
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
        public static ML.Result Delete(ML.PersonalAutorizacion personalAutorizacion)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "PersonalAutorizacionDelete";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdPersonalAutorizacion", SqlDbType.Int);
                    collection[0].Value = personalAutorizacion.IdPersonalAutorizacion;

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
