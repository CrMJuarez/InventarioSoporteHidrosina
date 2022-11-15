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
                    SqlParameter[] collection = new SqlParameter[6];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = direccionEntrada.Nombre;

                    collection[1] = new SqlParameter("@Calle", SqlDbType.VarChar);
                    collection[1].Value = direccionEntrada.Direccion.Calle;

                    collection[2] = new SqlParameter("@NumeroInterior", SqlDbType.VarChar);
                    collection[2].Value = direccionEntrada.Direccion.NumeroInterior;

                    collection[3] = new SqlParameter("@NumeroExterior", SqlDbType.VarChar);
                    collection[3].Value = direccionEntrada.Direccion.NumeroExterior;

                    collection[4] = new SqlParameter("@IdColonia", SqlDbType.Int);
                    collection[4].Value = direccionEntrada.Direccion.Colonia.IdColonia;

                    collection[5] = new SqlParameter("@IdOperadora", SqlDbType.Int);
                    collection[5].Value = direccionEntrada.Operadora.IdOperadora;

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
                    SqlParameter[] collection = new SqlParameter[8];

                    collection[0] = new SqlParameter("@IdDireccionEntrada", SqlDbType.Int);
                    collection[0].Value = direccionEntrada.IdDireccionEntrada;

                    collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = direccionEntrada.Nombre;

                    collection[2] = new SqlParameter("@Calle", SqlDbType.VarChar);
                    collection[2].Value = direccionEntrada.Direccion.Calle;

                    collection[3] = new SqlParameter("@NumeroInterior", SqlDbType.VarChar);
                    collection[3].Value = direccionEntrada.Direccion.NumeroInterior;

                    collection[4] = new SqlParameter("@NumeroExterior", SqlDbType.VarChar);
                    collection[4].Value = direccionEntrada.Direccion.NumeroExterior;

                    collection[5] = new SqlParameter("@IdDireccion", SqlDbType.Int);
                    collection[5].Value = direccionEntrada.Direccion.IdDireccion;

                    collection[6] = new SqlParameter("@IdColonia", SqlDbType.Int);
                    collection[6].Value = direccionEntrada.Direccion.Colonia.IdColonia;

                    collection[7] = new SqlParameter("@IdOperadora", SqlDbType.Int);
                    collection[7].Value = direccionEntrada.Operadora.IdOperadora;

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
                                DataRow row = direccionEntradaTable.Rows[0];
                                ML.DireccionEntrada direccionEntrada = new ML.DireccionEntrada();
                                direccionEntrada.IdDireccionEntrada = int.Parse(row[0].ToString());
                                direccionEntrada.Nombre = row[1].ToString();
                               

                                direccionEntrada.Operadora = new ML.Operadora();
                                direccionEntrada.Operadora.IdOperadora= int.Parse(row[2].ToString());
                                direccionEntrada.Operadora.NombreCorto = row[3].ToString();

                                direccionEntrada.Direccion = new ML.Direccion();
                                direccionEntrada.Direccion.IdDireccion = int.Parse(row[4].ToString());
                                direccionEntrada.Direccion.Calle = row[5].ToString();
                                direccionEntrada.Direccion.NumeroInterior = row[6].ToString();
                                direccionEntrada.Direccion.NumeroExterior = row[7].ToString();

                                direccionEntrada.Direccion.Colonia = new ML.Colonia();
                                direccionEntrada.Direccion.Colonia.IdColonia = int.Parse(row[8].ToString());
                                direccionEntrada.Direccion.Colonia.Nombre = row[9].ToString();
                                direccionEntrada.Direccion.Colonia.CodigoPostal = row[10].ToString();

                                direccionEntrada.Direccion.Colonia.Municipio = new ML.Municipio();
                                direccionEntrada.Direccion.Colonia.Municipio.IdMunicipio = int.Parse(row[11].ToString());
                                direccionEntrada.Direccion.Colonia.Municipio.Nombre = row[12].ToString();

                                direccionEntrada.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                                direccionEntrada.Direccion.Colonia.Municipio.Estado.IdEstado = int.Parse(row[13].ToString());
                                direccionEntrada.Direccion.Colonia.Municipio.Estado.Nombre = row[14].ToString();

                                direccionEntrada.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                                direccionEntrada.Direccion.Colonia.Municipio.Estado.Pais.IdPais = int.Parse(row[15].ToString());
                                direccionEntrada.Direccion.Colonia.Municipio.Estado.Pais.Nombre = row[16].ToString();




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

        public static ML.Result GetAll(ML.DireccionEntrada direccionEntrada)
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

                        foreach (DataRow row in direccionTable.Rows)
                        {
                            //ML.DireccionEntrada direccionEntrada = new ML.DireccionEntrada();


                            direccionEntrada = new ML.DireccionEntrada();
                            direccionEntrada.IdDireccionEntrada = int.Parse(row[0].ToString());
                            direccionEntrada.Nombre = row[1].ToString();
                         

                            direccionEntrada.Operadora = new ML.Operadora();
                            direccionEntrada.Operadora.IdOperadora = int.Parse(row[2].ToString());
                            direccionEntrada.Operadora.NombreCorto = row[3].ToString();

                            direccionEntrada.Direccion = new ML.Direccion();
                            direccionEntrada.Direccion.IdDireccion = int.Parse(row[4].ToString());
                            direccionEntrada.Direccion.Calle = row[5].ToString();
                            direccionEntrada.Direccion.NumeroInterior = row[6].ToString();
                            direccionEntrada.Direccion.NumeroExterior = row[7].ToString();

                            direccionEntrada.Direccion.Colonia = new ML.Colonia();
                            direccionEntrada.Direccion.Colonia.IdColonia = int.Parse(row[8].ToString());
                            direccionEntrada.Direccion.Colonia.Nombre = row[9].ToString();
                            direccionEntrada.Direccion.Colonia.CodigoPostal = row[10].ToString();

                            direccionEntrada.Direccion.Colonia.Municipio = new ML.Municipio();
                            direccionEntrada.Direccion.Colonia.Municipio.IdMunicipio = int.Parse(row[11].ToString());
                            direccionEntrada.Direccion.Colonia.Municipio.Nombre = row[12].ToString();

                            direccionEntrada.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            direccionEntrada.Direccion.Colonia.Municipio.Estado.IdEstado = int.Parse(row[13].ToString());
                            direccionEntrada.Direccion.Colonia.Municipio.Estado.Nombre = row[14].ToString();

                            direccionEntrada.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            direccionEntrada.Direccion.Colonia.Municipio.Estado.Pais.IdPais = int.Parse(row[15].ToString());
                            direccionEntrada.Direccion.Colonia.Municipio.Estado.Pais.Nombre = row[16].ToString();

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

