using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using ML;
using System.Reflection;

namespace BL
{
    public class DireccionEntrada
    {
        public static ML.Result Add(ML.DireccionEntrada direccionEntrada)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "DireccionEntradaAdd";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[10];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = direccionEntrada.Nombre;

                    collection[1] = new SqlParameter("@Calle", SqlDbType.VarChar);
                    collection[1].Value = direccionEntrada.Calle;

                    collection[2] = new SqlParameter("@NumeroInterior", SqlDbType.VarChar);
                    collection[2].Value = direccionEntrada.NumeroInterior;

                    collection[3] = new SqlParameter("@NumeroExterior", SqlDbType.VarChar);
                    collection[3].Value = direccionEntrada.NumeroExterior;

                    collection[4] = new SqlParameter("@Colonia", SqlDbType.VarChar);
                    collection[4].Value = direccionEntrada.Colonia;

                    collection[5] = new SqlParameter("@Estado", SqlDbType.VarChar);
                    collection[5].Value = direccionEntrada.Estado;

                    collection[6] = new SqlParameter("@CodigoPostal", SqlDbType.VarChar);
                    collection[6].Value = direccionEntrada.CodigoPostal;

                    collection[7] = new SqlParameter("@Pais", SqlDbType.VarChar);
                    collection[7].Value = direccionEntrada.Pais;

                    collection[8] = new SqlParameter("@IdOperadora", SqlDbType.Int);
                    collection[8].Value = direccionEntrada.Operadora.IdOperadora;

                    collection[9] = new SqlParameter("@Municipio", SqlDbType.VarChar);
                    collection[9].Value = direccionEntrada.Municipio;


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
        public static ML.Result Update(ML.DireccionEntrada direccionEntrada)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "DireccionEntradaUpdate";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[11];

                    collection[0] = new SqlParameter("@IdDireccionEntrada", SqlDbType.Int);
                    collection[0].Value = direccionEntrada.IdDireccionEntrada;

                    collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = direccionEntrada.Nombre;

                    collection[2] = new SqlParameter("@Calle", SqlDbType.VarChar);
                    collection[2].Value = direccionEntrada.Calle;

                    collection[3] = new SqlParameter("@NumeroInterior", SqlDbType.VarChar);
                    collection[3].Value = direccionEntrada.NumeroInterior;

                    collection[4] = new SqlParameter("@NumeroExterior", SqlDbType.VarChar);
                    collection[4].Value = direccionEntrada.NumeroExterior;

                    collection[5] = new SqlParameter("@Colonia", SqlDbType.VarChar);
                    collection[5].Value = direccionEntrada.Colonia;

                    collection[6] = new SqlParameter("@Estado", SqlDbType.VarChar);
                    collection[6].Value = direccionEntrada.Estado;

                    collection[7] = new SqlParameter("@CodigoPostal", SqlDbType.VarChar);
                    collection[7].Value = direccionEntrada.CodigoPostal;

                    collection[8] = new SqlParameter("@Pais", SqlDbType.VarChar);
                    collection[8].Value = direccionEntrada.Pais;

                    collection[9] = new SqlParameter("@IdOperadora", SqlDbType.Int);
                    collection[9].Value = direccionEntrada.Operadora.IdOperadora;

                    collection[10] = new SqlParameter("@Municipio", SqlDbType.VarChar);
                    collection[10].Value = direccionEntrada.Municipio;

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

        public static ML.Result GetById(int IdDireccionEntrada)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "DireccionEntradaGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdDireccionEntrada", SqlDbType.Int);
                        collection[0].Value = IdDireccionEntrada;

                        cmd.Parameters.AddRange(collection);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            DataTable direccionEntradaTable = new DataTable();
                            da.Fill(direccionEntradaTable);
                            cmd.Connection.Open();

                            if (direccionEntradaTable.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                DataRow row1 = direccionEntradaTable.Rows[0];
                                ML.DireccionEntrada direccionEntrada = new ML.DireccionEntrada();
                                direccionEntrada.IdDireccionEntrada = int.Parse(row1[0].ToString());
                                direccionEntrada.Nombre = row1[1].ToString();
                                direccionEntrada.Calle = row1[2].ToString();
                                direccionEntrada.NumeroInterior = row1[3].ToString();
                                direccionEntrada.NumeroExterior = row1[4].ToString();
                                direccionEntrada.Colonia = row1[5].ToString();
                                direccionEntrada.Estado = row1[6].ToString();
                                direccionEntrada.CodigoPostal = row1[7].ToString();
                                direccionEntrada.Pais = row1[8].ToString();
                                direccionEntrada.Municipio = row1[9].ToString();
                                direccionEntrada.Operadora = new ML.Operadora();
                                direccionEntrada.Operadora.IdOperadora= int.Parse(row1[10].ToString());
                                direccionEntrada.Operadora.NombreCorto = row1[11].ToString();
                                
                                result.Object = direccionEntrada;
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
                    string query = "DireccionEntradaGetAll";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    DataTable direccionTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(direccionTable);

                    if (direccionTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row1 in direccionTable.Rows)
                        {
                            ML.DireccionEntrada direccionEntrada = new ML.DireccionEntrada();
                            direccionEntrada.IdDireccionEntrada = int.Parse(row1[0].ToString());
                            direccionEntrada.Nombre = row1[1].ToString();
                            direccionEntrada.Calle = row1[2].ToString();
                            direccionEntrada.NumeroInterior = row1[3].ToString();
                            direccionEntrada.NumeroExterior = row1[4].ToString();
                            direccionEntrada.Colonia = row1[5].ToString();
                            direccionEntrada.Estado = row1[6].ToString();
                            direccionEntrada.CodigoPostal = row1[7].ToString();
                            direccionEntrada.Pais = row1[8].ToString();
                            direccionEntrada.Municipio = row1[9].ToString();
                            direccionEntrada.Operadora = new ML.Operadora();
                            direccionEntrada.Operadora.IdOperadora = int.Parse(row1[10].ToString());
                            direccionEntrada.Operadora.NombreCorto = row1[11].ToString();
                            
                            result.Objects.Add(direccionEntrada);
                        }
                        result.Correct = true;
                    }
                    else

                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al momento de mostrar el modelo";
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
        public static ML.Result Delete(ML.DireccionEntrada direccionEntrada)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "DireccionEntradaDelete";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdDireccionEntrada", SqlDbType.Int);
                    collection[0].Value = direccionEntrada.IdDireccionEntrada;

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

