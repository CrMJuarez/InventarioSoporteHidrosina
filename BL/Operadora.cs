using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using ML;

namespace BL
{
    public class Operadora
    {
        public static ML.Result Add(ML.Operadora operadora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "OperadoraAdd";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[4];

                    collection[0] = new SqlParameter("@NombreCorto", SqlDbType.VarChar);
                    collection[0].Value = operadora.NombreCorto;
                    collection[1] = new SqlParameter("@RazonSocial", SqlDbType.VarChar);
                    collection[1].Value = operadora.RazonSocial;
                    collection[2] = new SqlParameter("@Domicilio", SqlDbType.VarChar);
                    collection[2].Value = operadora.Domicilio;
                    collection[3] = new SqlParameter("@RFC", SqlDbType.VarChar);
                    collection[3].Value = operadora.RFC;
                   

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
        public static ML.Result Update(ML.Operadora operadora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "OperadoraUpdate";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[5];

                    collection[0] = new SqlParameter("@IdOperadora", SqlDbType.Int);
                    collection[0].Value = operadora.IdOperadora;
                    collection[1] = new SqlParameter("@NombreCorto", SqlDbType.VarChar);
                    collection[1].Value = operadora.NombreCorto;
                    collection[2] = new SqlParameter("@RazonSocial", SqlDbType.VarChar);
                    collection[2].Value = operadora.RazonSocial;
                    collection[3] = new SqlParameter("@Domicilio", SqlDbType.VarChar);
                    collection[3].Value = operadora.Domicilio;
                    collection[4] = new SqlParameter("@RFC", SqlDbType.VarChar);
                    collection[4].Value = operadora.RFC;

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

        public static ML.Result GetById(int IdOperadora)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "OperadoraGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdOperadora", SqlDbType.Int);
                        collection[0].Value = IdOperadora;

                        cmd.Parameters.AddRange(collection);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            DataTable operadoraTable = new DataTable();
                            da.Fill(operadoraTable);
                            cmd.Connection.Open();

                            if (operadoraTable.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                DataRow row1 = operadoraTable.Rows[0];
                                ML.Operadora operadora = new ML.Operadora();
                                operadora.IdOperadora = int.Parse(row1[0].ToString());
                                operadora.NombreCorto = row1[1].ToString();
                                operadora.RazonSocial = row1[2].ToString();
                                operadora.Domicilio = row1[3].ToString();
                                operadora.RFC = row1[4].ToString();

                                result.Object = operadora;
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
                    string query = "OperadoraGetAll";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    DataTable operadoraTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(operadoraTable);

                    if (operadoraTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in operadoraTable.Rows)
                        {
                            ML.Operadora operadora = new ML.Operadora();
                            operadora.IdOperadora = int.Parse(row[0].ToString());
                            operadora.NombreCorto = row[1].ToString();
                            operadora.RazonSocial = row[2].ToString();
                            operadora.Domicilio = row[3].ToString();
                            operadora.RFC = row[4].ToString();

                            result.Objects.Add(operadora);
                        }
                        result.Correct = true;
                    }
                    else

                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al momento de mostrar la operadora";
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
        public static ML.Result Delete(ML.Operadora operadora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "OperadoraDelete";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdOperadora", SqlDbType.Int);
                    collection[0].Value = operadora.IdOperadora;

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

