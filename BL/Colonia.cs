using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using ML;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {
                    string query = "ColoniaGetByIdMunicipio ";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdMunicipio", SqlDbType.Int);
                        collection[0].Value = IdMunicipio;

                        cmd.Parameters.AddRange(collection);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable coloniaTable = new DataTable();
                            da.Fill(coloniaTable);
                            cmd.Connection.Open();

                            result.Objects = new List<object>();

                            if (coloniaTable.Rows.Count > 0)
                            {

                                DataRow row1 = coloniaTable.Rows[0];
                                ML.Colonia colonia = new ML.Colonia();

                                colonia.IdColonia = int.Parse(row1[0].ToString());
                                colonia.Nombre = row1[1].ToString();
                                colonia.CodigoPostal = row1[2].ToString();

                                colonia.Municipio = new ML.Municipio();
                                colonia.Municipio.IdMunicipio = int.Parse(row1[3].ToString());

                                result.Objects.Add(colonia);
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se ha podido realizar la consulta";
                            }
                        }
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

