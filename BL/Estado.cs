using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using ML;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetByIdPais(int IdPais)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))

                {

                    string query = "EstadoGetByIdPais ";
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdPais", SqlDbType.Int);
                    collection[0].Value = IdPais;
                    cmd.Parameters.AddRange(collection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable estadoTable = new DataTable();
                    da.Fill(estadoTable);


                    if (estadoTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row1 in estadoTable.Rows)
                        {

                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = int.Parse(row1[0].ToString());
                            estado.Nombre = row1[1].ToString();

                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = int.Parse(row1[2].ToString());

                            result.Objects.Add(estado);
                        }
                        result.Correct = true;
                    }
                    ////cmd.Connection.Open();
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
