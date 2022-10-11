using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using ML;
using System.Text.RegularExpressions;

namespace BL
{
    public class Modelo
    {
        public static ML.Result Add(ML.Modelo modelo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "Modelodd";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[3];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = modelo.Nombre;
                    collection[1] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                    collection[1].Value = modelo.Descripcion;
                    modelo.Marca = new ML.Marca();
                    collection[2] = new SqlParameter("@IdMarca", SqlDbType.Int);
                    collection[2].Value = modelo.Marca.IdMarca;

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
        public static ML.Result Update(ML.Modelo modelo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ModeloUpdate";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[3];


                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = modelo.Nombre;
                    collection[1] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                    collection[1].Value = modelo.Descripcion;
                    modelo.Marca = new ML.Marca();
                    collection[2] = new SqlParameter("@IdMarca", SqlDbType.Int);
                    collection[2].Value = modelo.Marca.IdMarca;

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

        public static ML.Result GetById(int IdModelo)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ModeloGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdModelo", SqlDbType.Int);
                        collection[0].Value = IdModelo;

                        cmd.Parameters.AddRange(collection);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            DataTable modeloTable = new DataTable();
                            da.Fill(modeloTable);
                            cmd.Connection.Open();

                            if (modeloTable.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                DataRow row1 = modeloTable.Rows[0];
                                ML.Modelo modelo = new ML.Modelo();
                                modelo.IdModelo = int.Parse(row1[0].ToString());
                                modelo.Nombre = row1[1].ToString();
                                modelo.Descripcion = row1[2].ToString();
                                modelo.Marca = new ML.Marca();
                                modelo.Marca.IdMarca = int.Parse(row1[3].ToString());

                                result.Object = modelo;
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
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ModeloGetAll";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    DataTable modeloTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(modeloTable);

                    if (modeloTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in modeloTable.Rows)
                        {
                            ML.Modelo modelo = new ML.Modelo();
                            modelo.IdModelo = int.Parse(row[0].ToString());
                            modelo.Nombre = row[1].ToString();
                            modelo.Descripcion = row[2].ToString();
                            modelo.Marca = new ML.Marca();
                            modelo.Marca.IdMarca = int.Parse(row[3].ToString());

                            result.Objects.Add(modelo);
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
        public static ML.Result Delete(ML.Modelo modelo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ModeloDelete";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdModelo", SqlDbType.Int);
                    collection[0].Value = modelo.IdModelo;

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
