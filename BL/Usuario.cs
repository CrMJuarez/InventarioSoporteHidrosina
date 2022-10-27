using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
//using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "UsuarioAdd";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[7];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;

                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;

                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;

                    collection[3] = new SqlParameter("@NombreUsuario", SqlDbType.VarChar);
                    collection[3].Value = usuario.NombreUsuario;

                    collection[4] = new SqlParameter("@Contrasenia", SqlDbType.VarChar);
                    collection[4].Value = usuario.Contrasenia;

                    collection[5] = new SqlParameter("@Estatus", SqlDbType.Bit);
                    collection[5].Value = usuario.Estatus = true;

                    collection[6] = new SqlParameter("@IdRol", SqlDbType.Int);  
                    collection[6].Value = usuario.Rol.IdRol;

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
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "UsuarioUpdate";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[8];

                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

                    collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;

                    collection[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;

                    collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;

                    collection[4] = new SqlParameter("@NombreUsuario", SqlDbType.VarChar);
                    collection[4].Value = usuario.NombreUsuario;

                    collection[5] = new SqlParameter("@Contrasenia", SqlDbType.VarChar);
                    collection[5].Value = usuario.Contrasenia;

                    collection[6] = new SqlParameter("@Estatus", SqlDbType.Bit);
                    collection[6].Value = usuario.Estatus;

                    //usuario.Rol = new ML.Rol();
                    collection[7] = new SqlParameter("@IdRol", SqlDbType.Int);
                    collection[7].Value = usuario.Rol.IdRol;

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

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "UsuarioGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            DataTable usuarioTable = new DataTable();
                            da.Fill(usuarioTable);
                            cmd.Connection.Open();

                            if (usuarioTable.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                DataRow row1 = usuarioTable.Rows[0];
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(row1[0].ToString());
                                usuario.Nombre = row1[1].ToString();
                                usuario.ApellidoPaterno = row1[2].ToString();
                                usuario.ApellidoMaterno = row1[3].ToString();
                                usuario.NombreUsuario = row1[4].ToString();
                                usuario.Contrasenia = row1[5].ToString();
                                usuario.Estatus = bool.Parse(row1[6].ToString());
                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse(row1[7].ToString());
                                usuario.Rol.Nombre = row1[8].ToString();
                                result.Object = usuario;
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
                    string query = "UsuarioGetAll";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    DataTable usuarioTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in usuarioTable.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.NombreUsuario = row[4].ToString();
                            usuario.Contrasenia = row[5].ToString();
                            usuario.Estatus = bool.Parse(row[6].ToString());
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = int.Parse(row[7].ToString());
                            usuario.Rol.Nombre = row[8].ToString();
                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else

                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al momento de mostrar el usuario";
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
        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "UsuarioDelete";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

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



        public static ML.Result GetByNombreUsuario(string NombreUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "GetByNombreUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@NombreUsuario", SqlDbType.VarChar);
                        collection[0].Value = NombreUsuario;

                        cmd.Parameters.AddRange(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            DataTable usuarioTable = new DataTable();
                            da.Fill(usuarioTable);
                            cmd.Connection.Open();

                            if (usuarioTable.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                DataRow row1 = usuarioTable.Rows[0];
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(row1[0].ToString());
                                usuario.Nombre = row1[1].ToString();
                                usuario.ApellidoPaterno = row1[2].ToString();
                                usuario.ApellidoMaterno = row1[3].ToString();
                                usuario.NombreUsuario = row1[4].ToString();
                                usuario.Contrasenia = row1[5].ToString();
                                usuario.Estatus = bool.Parse(row1[6].ToString());
                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse(row1[7].ToString());
                                usuario.Rol.Nombre = row1[8].ToString();
                                result.Object = usuario;
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



    }
}
