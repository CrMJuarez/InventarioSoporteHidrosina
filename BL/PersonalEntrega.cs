using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace BL
{
    internal class PersonalEntrega
    {
        public static ML.Result Add(ML.PersonalEntrega personalEntrega)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "PersonalEntregaAdd";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[3];


                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = personalEntrega.Nombre;

                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = personalEntrega.ApellidoPaterno;

                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = personalEntrega.ApellidoMaterno;
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
        public static ML.Result Update(ML.PersonalEntrega personalEntrega)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "personalEntregaUpdate";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[4];

                    collection[0] = new SqlParameter("@IdPersonalEntrega", SqlDbType.Int);
                    collection[0].Value = personalEntrega.IdPersonalEntrega;

                    collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = personalEntrega.Nombre;

                    collection[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = personalEntrega.ApellidoPaterno;

                    collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = personalEntrega.ApellidoMaterno;


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
        public static ML.Result GetById(int IdPersonalEntrega)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "PersonalEntregaGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdPersonalEntrega", SqlDbType.Int);
                        collection[0].Value = IdPersonalEntrega;

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
                                ML.PersonalEntrega personalEntrega = new ML.PersonalEntrega();
                                personalEntrega.IdPersonalEntrega = int.Parse(row1[0].ToString());
                                personalEntrega.Nombre = row1[1].ToString();
                                personalEntrega.ApellidoPaterno = row1[2].ToString();
                                personalEntrega.ApellidoMaterno = row1[3].ToString();

                                result.Object = personalEntrega;
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
                    string query = "PersonalEntregaGetAll";

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
                            ML.PersonalEntrega personalEntrega = new ML.PersonalEntrega();

                            personalEntrega.IdPersonalEntrega = int.Parse(row[0].ToString());
                            personalEntrega.Nombre = row[1].ToString();
                            personalEntrega.ApellidoPaterno = row[2].ToString();
                            personalEntrega.ApellidoMaterno = row[3].ToString();
                            result.Objects.Add(personalEntrega);
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
        public static ML.Result Delete(ML.PersonalEntrega personalEntrega)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "PersonalEntregaDelete";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdPersonalEntrega", SqlDbType.Int);
                    collection[0].Value = personalEntrega.IdPersonalEntrega;

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
