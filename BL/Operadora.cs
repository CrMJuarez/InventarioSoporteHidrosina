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
                    SqlParameter[] collection = new SqlParameter[7];

                    collection[0] = new SqlParameter("@NombreCorto", SqlDbType.VarChar);
                    collection[0].Value = operadora.NombreCorto;
                    collection[1] = new SqlParameter("@RazonSocial", SqlDbType.VarChar);
                    collection[1].Value = operadora.RazonSocial;
                    
                    collection[2] = new SqlParameter("@RFC", SqlDbType.VarChar);
                    collection[2].Value = operadora.RFC;

                    collection[3] = new SqlParameter("@Calle", SqlDbType.VarChar);
                    collection[3].Value = operadora.Direccion.Calle;
                    collection[4] = new SqlParameter("@NumeroInterior", SqlDbType.VarChar);
                    collection[4].Value = operadora.Direccion.NumeroInterior;
                    collection[5] = new SqlParameter("@NumeroExterior", SqlDbType.VarChar);
                    collection[5].Value = operadora.Direccion.NumeroExterior;
                    collection[6] = new SqlParameter("@IdColonia", SqlDbType.Int);
                    collection[6].Value = operadora.Direccion.Colonia.IdColonia;





                 
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
                    //var query = context.Database.ExecuteSqlRaw($"UsuarioUpdate {usuario.IdUsuario},'{usuario.UserName}', '{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}', '{usuario.Email}', '{usuario.Sexo}', '{usuario.Telefono}', '{usuario.Celular}', '{usuario.FechaNacimiento}' , '{usuario.Curp}', '{usuario.Imagen}' , {usuario.Rol.IdRol}, '{usuario.Estatus}', '{usuario.Password}', '{usuario.Direccion.Calle}', '{usuario.Direccion.NumeroInterior}', '{usuario.Direccion.NumeroExterior}', {usuario.Direccion.Colonia.IdColonia}");
                    string query = "OperadoraUpdate";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[9];

                    collection[0] = new SqlParameter("@IdOperadora", SqlDbType.Int);
                    collection[0].Value = operadora.IdOperadora;
                    collection[1] = new SqlParameter("@NombreCorto", SqlDbType.VarChar);
                    collection[1].Value = operadora.NombreCorto;
                    collection[2] = new SqlParameter("@RazonSocial", SqlDbType.VarChar);
                    collection[2].Value = operadora.RazonSocial;
                    collection[3] = new SqlParameter("@RFC", SqlDbType.VarChar);
                    collection[3].Value = operadora.RFC;
                    collection[4] = new SqlParameter("@IdDireccion", SqlDbType.Int);
                    collection[4].Value = operadora.Direccion.IdDireccion;
                    collection[5] = new SqlParameter("@Calle", SqlDbType.VarChar);
                    collection[5].Value = operadora.Direccion.Calle;
                    collection[6] = new SqlParameter("@NumeroInterior", SqlDbType.VarChar);
                    collection[6].Value = operadora.Direccion.NumeroInterior;
                    collection[7] = new SqlParameter("@NumeroExterior", SqlDbType.VarChar);
                    collection[7].Value = operadora.Direccion.NumeroExterior;
                    collection[8] = new SqlParameter("@IdColonia", SqlDbType.Int);
                    collection[8].Value = operadora.Direccion.Colonia.IdColonia;







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
                                DataRow row = operadoraTable.Rows[0];
                                ML.Operadora operadora = new ML.Operadora();
                                operadora.IdOperadora = int.Parse(row[0].ToString());
                                operadora.NombreCorto = row[1].ToString();
                                operadora.RazonSocial = row[2].ToString();
                                
                                operadora.RFC = row[3].ToString();
                                operadora.Direccion = new ML.Direccion();
                                operadora.Direccion.IdDireccion = int.Parse(row[4].ToString());
                                operadora.Direccion.Calle = row[5].ToString();
                                operadora.Direccion.NumeroInterior = row[6].ToString();
                                operadora.Direccion.NumeroExterior = row[7].ToString();

                                operadora.Direccion.Colonia = new ML.Colonia();
                                operadora.Direccion.Colonia.IdColonia = int.Parse(row[8].ToString());
                                operadora.Direccion.Colonia.Nombre = row[9].ToString();
                                operadora.Direccion.Colonia.CodigoPostal = row[10].ToString();

                                operadora.Direccion.Colonia.Municipio = new ML.Municipio();
                                operadora.Direccion.Colonia.Municipio.IdMunicipio = int.Parse(row[11].ToString());
                                operadora.Direccion.Colonia.Municipio.Nombre = row[12].ToString();

                                operadora.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                                operadora.Direccion.Colonia.Municipio.Estado.IdEstado = int.Parse(row[13].ToString());
                                operadora.Direccion.Colonia.Municipio.Estado.Nombre = row[14].ToString();

                                operadora.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                                operadora.Direccion.Colonia.Municipio.Estado.Pais.IdPais = int.Parse(row[15].ToString());
                                operadora.Direccion.Colonia.Municipio.Estado.Pais.Nombre = row[16].ToString();

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

        public static ML.Result GetAll(ML.Operadora operadora)
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
                            operadora = new ML.Operadora();
                            operadora.IdOperadora = int.Parse(row[0].ToString());
                            operadora.NombreCorto = row[1].ToString();
                            operadora.RazonSocial = row[2].ToString();
                         
                            operadora.RFC = row[3].ToString();
                            operadora.Direccion = new ML.Direccion();
                            operadora.Direccion.IdDireccion = int.Parse(row[4].ToString());
                            operadora.Direccion.Calle = row[5].ToString();
                            operadora.Direccion.NumeroInterior = row[6].ToString();
                            operadora.Direccion.NumeroExterior = row[7].ToString();

                            operadora.Direccion.Colonia = new ML.Colonia();
                            operadora.Direccion.Colonia.IdColonia = int.Parse(row[8].ToString());
                            operadora.Direccion.Colonia.Nombre = row[9].ToString();
                            operadora.Direccion.Colonia.CodigoPostal = row[10].ToString();

                            operadora.Direccion.Colonia.Municipio = new ML.Municipio();
                            operadora.Direccion.Colonia.Municipio.IdMunicipio = int.Parse(row[11].ToString());
                            operadora.Direccion.Colonia.Municipio.Nombre = row[12].ToString();

                            operadora.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            operadora.Direccion.Colonia.Municipio.Estado.IdEstado = int.Parse(row[13].ToString());
                            operadora.Direccion.Colonia.Municipio.Estado.Nombre = row[14].ToString();

                            operadora.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            operadora.Direccion.Colonia.Municipio.Estado.Pais.IdPais = int.Parse(row[15].ToString());
                            operadora.Direccion.Colonia.Municipio.Estado.Pais.Nombre = row[16].ToString();

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

