using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace BL
{
    public class DireccionDestino
    {
        public static ML.Result Add(ML.DireccionDestino direccionDestino)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "DireccionDestinoAdd";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[10];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = direccionDestino.Nombre;

                    collection[1] = new SqlParameter("@Calle", SqlDbType.VarChar);
                    collection[1].Value = direccionDestino.Calle;

                    collection[2] = new SqlParameter("@NumeroInterior", SqlDbType.VarChar);
                    collection[2].Value = direccionDestino.NumeroInterior;

                    collection[3] = new SqlParameter("@NumeroExterior", SqlDbType.VarChar);
                    collection[3].Value = direccionDestino.NumeroExterior;

                    collection[4] = new SqlParameter("@Colonia", SqlDbType.VarChar);
                    collection[4].Value = direccionDestino.Colonia;

                    collection[5] = new SqlParameter("@Estado", SqlDbType.VarChar);
                    collection[5].Value = direccionDestino.Estado;

                    collection[6] = new SqlParameter("@CodigoPostal", SqlDbType.VarChar);
                    collection[6].Value = direccionDestino.CodigoPostal;

                    collection[7] = new SqlParameter("@Pais", SqlDbType.VarChar);
                    collection[7].Value = direccionDestino.Pais;

                    collection[8] = new SqlParameter("@IdOperadora", SqlDbType.Int);
                    collection[8].Value = direccionDestino.Operadora.IdOperadora;

                    collection[9] = new SqlParameter("@Municipio", SqlDbType.VarChar);
                    collection[9].Value = direccionDestino.Municipio;


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
        public static ML.Result Update(ML.DireccionDestino direccionDestino)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "DireccionDestinoUpdate";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[11];

                    collection[0] = new SqlParameter("@IddireccionDestino", SqlDbType.Int);
                    collection[0].Value = direccionDestino.IdDireccionDestino;

                    collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = direccionDestino.Nombre;

                    collection[2] = new SqlParameter("@Calle", SqlDbType.VarChar);
                    collection[2].Value = direccionDestino.Calle;

                    collection[3] = new SqlParameter("@NumeroInterior", SqlDbType.VarChar);
                    collection[3].Value = direccionDestino.NumeroInterior;

                    collection[4] = new SqlParameter("@NumeroExterior", SqlDbType.VarChar);
                    collection[4].Value = direccionDestino.NumeroExterior;

                    collection[5] = new SqlParameter("@Colonia", SqlDbType.VarChar);
                    collection[5].Value = direccionDestino.Colonia;

                    collection[6] = new SqlParameter("@Estado", SqlDbType.VarChar);
                    collection[6].Value = direccionDestino.Estado;

                    collection[7] = new SqlParameter("@CodigoPostal", SqlDbType.VarChar);
                    collection[7].Value = direccionDestino.CodigoPostal;

                    collection[8] = new SqlParameter("@Pais", SqlDbType.VarChar);
                    collection[8].Value = direccionDestino.Pais;

                    collection[9] = new SqlParameter("@IdOperadora", SqlDbType.Int);
                    collection[9].Value = direccionDestino.Operadora.IdOperadora;

                    collection[10] = new SqlParameter("@Municipio", SqlDbType.VarChar);
                    collection[10].Value = direccionDestino.Municipio;

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

        public static ML.Result GetById(int IdDireccionDestino)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "DireccionDestinoGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdDireccionDestino", SqlDbType.Int);
                        collection[0].Value = IdDireccionDestino;

                        cmd.Parameters.AddRange(collection);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            DataTable direccionDestinoTable = new DataTable();
                            da.Fill(direccionDestinoTable);
                            cmd.Connection.Open();

                            if (direccionDestinoTable.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                DataRow row1 = direccionDestinoTable.Rows[0];
                                ML.DireccionDestino direccionDestino = new ML.DireccionDestino();
                                direccionDestino.IdDireccionDestino = int.Parse(row1[0].ToString());
                                direccionDestino.Nombre = row1[1].ToString();
                                direccionDestino.Calle = row1[2].ToString();
                                direccionDestino.NumeroInterior = row1[3].ToString();
                                direccionDestino.NumeroExterior = row1[4].ToString();
                                direccionDestino.Colonia = row1[5].ToString();
                                direccionDestino.Estado = row1[6].ToString();
                                direccionDestino.CodigoPostal = row1[7].ToString();
                                direccionDestino.Pais = row1[8].ToString();
                                direccionDestino.Municipio = row1[9].ToString();
                                direccionDestino.Operadora = new ML.Operadora();
                                direccionDestino.Operadora.IdOperadora = int.Parse(row1[10].ToString());
                                direccionDestino.Operadora.NombreCorto = row1[11].ToString();

                                result.Object = direccionDestino;
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
                    string query = "DireccionDestinoGetAll";

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
                            ML.DireccionDestino direccionDestino = new ML.DireccionDestino();
                            direccionDestino.IdDireccionDestino = int.Parse(row1[0].ToString());
                            direccionDestino.Nombre = row1[1].ToString();
                            direccionDestino.Calle = row1[2].ToString();
                            direccionDestino.NumeroInterior = row1[3].ToString();
                            direccionDestino.NumeroExterior = row1[4].ToString();
                            direccionDestino.Colonia = row1[5].ToString();
                            direccionDestino.Estado = row1[6].ToString();
                            direccionDestino.CodigoPostal = row1[7].ToString();
                            direccionDestino.Pais = row1[8].ToString();
                            direccionDestino.Municipio = row1[9].ToString();
                            direccionDestino.Operadora = new ML.Operadora();
                            direccionDestino.Operadora.IdOperadora = int.Parse(row1[10].ToString());
                            direccionDestino.Operadora.NombreCorto = row1[11].ToString();

                            result.Objects.Add(direccionDestino);
                        }
                        result.Correct = true;
                    }
                    else

                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al momento de mostrar la direccion";
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
        public static ML.Result Delete(ML.DireccionDestino direccionDestino)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "DireccionDestinoDelete";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdDireccionDestino", SqlDbType.Int);
                    collection[0].Value = direccionDestino.IdDireccionDestino;

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
