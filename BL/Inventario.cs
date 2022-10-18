using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using ML;

namespace BL
{
    public class Inventario
    {
        public static ML.Result Add(ML.Inventario inventario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "InventarioAdd";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[7];

                    collection[0] = new SqlParameter("@NumeroSerie", SqlDbType.VarChar);
                    collection[0].Value = inventario.NumeroSerie;

                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = inventario.NIAF;

                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = inventario.Responsable;

                    collection[3] = new SqlParameter("@NombreUsuario", SqlDbType.VarChar);
                    collection[3].Value = inventario.Comentario;

                    collection[4] = new SqlParameter("@TipoEquipo", SqlDbType.Int);
                    collection[4].Value = inventario.TipoEquipo.IdTipoEquipo;

                    collection[5] = new SqlParameter("@IdMarca", SqlDbType.Int);
                    collection[5].Value = inventario.Marca.IdMarca;

                    collection[6] = new SqlParameter("@IdModelo", SqlDbType.Int);
                    collection[6].Value = inventario.Modelo.IdModelo;

                    collection[7] = new SqlParameter("@IdDireccionEntrada", SqlDbType.Int);
                    collection[7].Value = inventario.DireccionEntrada.IdDireccionEntrada;

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
        public static ML.Result Update(ML.Inventario inventario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "InventarioUpdate";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[8];
                    
                    collection[0] = new SqlParameter("@IdInventario", SqlDbType.Int);
                    collection[0].Value = inventario.IdInventario;
                    
                    collection[1] = new SqlParameter("@NumeroSerie", SqlDbType.VarChar);
                    collection[1].Value = inventario.NumeroSerie;

                    collection[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[3].Value = inventario.NIAF;

                    collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = inventario.Responsable;

                    collection[4] = new SqlParameter("@NombreUsuario", SqlDbType.VarChar);
                    collection[4].Value = inventario.Comentario;

                    collection[5] = new SqlParameter("@TipoEquipo", SqlDbType.Int);
                    collection[5].Value = inventario.TipoEquipo.IdTipoEquipo;

                    collection[6] = new SqlParameter("@IdMarca", SqlDbType.Int);
                    collection[6].Value = inventario.Marca.IdMarca;

                    collection[7] = new SqlParameter("@IdModelo", SqlDbType.Int);
                    collection[7].Value = inventario.Modelo.IdModelo;

                    collection[8] = new SqlParameter("@IdDireccionEntrada", SqlDbType.Int);
                    collection[8].Value = inventario.DireccionEntrada.IdDireccionEntrada;

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

        public static ML.Result GetById(int IdInventario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "InventarioGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdInventario", SqlDbType.Int);
                        collection[0].Value = IdInventario;

                        cmd.Parameters.AddRange(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            DataTable inventarioTable = new DataTable();
                            da.Fill(inventarioTable);
                            cmd.Connection.Open();

                            if (inventarioTable.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                DataRow row1 = inventarioTable.Rows[0];
                                ML.Inventario inventario = new ML.Inventario();
                                inventario.IdInventario = int.Parse(row1[0].ToString());
                                inventario.NumeroSerie = row1[1].ToString();
                                inventario.NIAF = row1[2].ToString();
                                inventario.Responsable = row1[3].ToString();
                                inventario.Comentario = row1[4].ToString();
                                inventario.TipoEquipo = new ML.TipoEquipo();
                                inventario.TipoEquipo.IdTipoEquipo = int.Parse(row1[5].ToString());
                                inventario.TipoEquipo.Nombre = row1[6].ToString();
                                inventario.Marca = new ML.Marca();
                                inventario.Marca.IdMarca = int.Parse(row1[7].ToString());
                                inventario.Marca.Nombre = row1[8].ToString();
                                inventario.Modelo = new ML.Modelo();
                                inventario.Modelo.IdModelo = int.Parse(row1[9].ToString());
                                inventario.Modelo.Nombre = row1[10].ToString();
                                inventario.Modelo.Descripcion = row1[11].ToString();
                                inventario.DireccionEntrada = new ML.DireccionEntrada();
                                inventario.DireccionEntrada.IdDireccionEntrada = int.Parse(row1[12].ToString());
                                inventario.DireccionEntrada.Nombre = row1[13].ToString();
                                
                                result.Object = inventario;
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
                    string query = "InventarioGetAll";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    DataTable inventarioTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(inventarioTable);

                    if (inventarioTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row1 in inventarioTable.Rows)
                        {
                            ML.Inventario inventario = new ML.Inventario();
                            inventario.IdInventario = int.Parse(row1[0].ToString());
                            inventario.NumeroSerie = row1[1].ToString();
                            inventario.NIAF = row1[2].ToString();
                            inventario.Responsable = row1[3].ToString();
                            inventario.Comentario = row1[4].ToString();
                            inventario.TipoEquipo = new ML.TipoEquipo();
                            inventario.TipoEquipo.IdTipoEquipo = int.Parse(row1[5].ToString());
                            inventario.TipoEquipo.Nombre = row1[6].ToString();
                            inventario.Marca = new ML.Marca();
                            inventario.Marca.IdMarca = int.Parse(row1[7].ToString());
                            inventario.Marca.Nombre = row1[8].ToString();
                            inventario.Modelo = new ML.Modelo();
                            inventario.Modelo.IdModelo = int.Parse(row1[9].ToString());
                            inventario.Modelo.Nombre = row1[10].ToString();
                            inventario.Modelo.Descripcion = row1[11].ToString();
                            inventario.DireccionEntrada = new ML.DireccionEntrada();
                            inventario.DireccionEntrada.IdDireccionEntrada = int.Parse(row1[12].ToString());
                            inventario.DireccionEntrada.Nombre = row1[13].ToString();
                            result.Objects.Add(inventario);
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
        public static ML.Result Delete(ML.Inventario inventario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "InventarioDelete";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = inventario.IdInventario;

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
