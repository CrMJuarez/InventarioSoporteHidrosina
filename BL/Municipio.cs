using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using ML;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {

                    string query = "MunicipioGetByIdEstado ";
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdEstado", SqlDbType.Int);
                    collection[0].Value = IdEstado;

                    cmd.Parameters.AddRange(collection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable municipioTable = new DataTable();
                    da.Fill(municipioTable);
                    cmd.Connection.Open();



                    if (municipioTable.Rows.Count > 0)
                    {

                        result.Objects = new List<object>();

                        foreach (DataRow row1 in municipioTable.Rows)
                        {
                            ML.Municipio municipio = new ML.Municipio();

                            municipio.IdMunicipio = int.Parse(row1[0].ToString());
                            municipio.Nombre = row1[1].ToString();

                            municipio.Estado = new ML.Estado();
                            municipio.Estado.IdEstado = int.Parse(row1[2].ToString());

                            result.Objects.Add(municipio);

                        }
                        result.Correct = true;
                    }
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
