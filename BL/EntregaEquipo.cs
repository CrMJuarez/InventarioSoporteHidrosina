using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
namespace BL
{
    public class EntregaEquipo
    {
        public static ML.Result Add(ML.EntregaEquipo entregaEquipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {

                    string query = "EntregaEquipoAdd";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[7];

                    collection[0] = new SqlParameter("@Recibe", SqlDbType.VarChar);
                    collection[0].Value = entregaEquipo.Recibe;

                    collection[1] = new SqlParameter("@Justificacion", SqlDbType.VarChar);
                    collection[1].Value = entregaEquipo.Justificacion;
                    if (entregaEquipo.Justificacion=="" || entregaEquipo.Justificacion==null || entregaEquipo.Justificacion.Equals(" "))
                    {
                        collection[1].Value = entregaEquipo.Justificacion = "N/A";

                    }

                    collection[2] = new SqlParameter("@IdDireccionDestino", SqlDbType.Int);
                    collection[2].Value = entregaEquipo.direccionDestino.IdDireccionDestino;

                    collection[3] = new SqlParameter("@IdPersonalEntrega", SqlDbType.Int);
                    collection[3].Value = entregaEquipo.personalEntrega.IdPersonalEntrega;

                    collection[4] = new SqlParameter("@IdOperadora", SqlDbType.Int);
                    collection[4].Value = entregaEquipo.operadora.IdOperadora;

                    collection[5] = new SqlParameter("@NumeroSerie", SqlDbType.VarChar);
                    collection[5].Value = entregaEquipo.inventario.NumeroSerie;

                    collection[6] = new SqlParameter("@IdPersonalAutorizacion", SqlDbType.Int);
                    collection[6].Value = entregaEquipo.personalAutorizacion.IdPersonalAutorizacion;                   

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
        public static ML.Result GetAll()
         {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "EntregaEquipoGetAll";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    DataTable entregaEquipoTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(entregaEquipoTable);

                    if (entregaEquipoTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in entregaEquipoTable.Rows)
                        {
                            ML.EntregaEquipo entregaEquipo = new ML.EntregaEquipo();
                            entregaEquipo.IdEntregaEquipo = int.Parse(row[0].ToString());
                            entregaEquipo.Recibe = row[1].ToString();
                            entregaEquipo.Justificacion = row[2].ToString();


                            entregaEquipo.direccionDestino = new ML.DireccionDestino();
                            entregaEquipo.direccionDestino.IdDireccionDestino = int.Parse(row[3].ToString());
                            entregaEquipo.direccionDestino.Nombre = row[4].ToString();



                            entregaEquipo.personalEntrega = new ML.PersonalEntrega();
                            entregaEquipo.personalEntrega.IdPersonalEntrega = int.Parse(row[5].ToString());
                            entregaEquipo.personalEntrega.Nombre = row[6].ToString();
                            entregaEquipo.personalEntrega.ApellidoPaterno = row[7].ToString();
                            entregaEquipo.personalEntrega.ApellidoMaterno = row[8].ToString();

                            entregaEquipo.operadora = new ML.Operadora();
                            entregaEquipo.operadora.IdOperadora = int.Parse(row[9].ToString());
                            entregaEquipo.operadora.RazonSocial = row[10].ToString();


                            entregaEquipo.inventario = new ML.Inventario();
                            entregaEquipo.inventario.NumeroSerie = row[11].ToString();


                            entregaEquipo.personalAutorizacion = new ML.PersonalAutorizacion();
                            entregaEquipo.personalAutorizacion.IdPersonalAutorizacion = int.Parse(row[12].ToString());
                            entregaEquipo.personalAutorizacion.Nombre = row[13].ToString();
                            entregaEquipo.personalAutorizacion.ApellidoPaterno = row[14].ToString();
                            entregaEquipo.personalAutorizacion.ApellidoMaterno = row[15].ToString();



                            


                            result.Objects.Add(entregaEquipo);


                        } 

                        result.Correct = true;
                    }
                    else

                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al momento de mostrar el equipo de entrega";
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
    }
}
