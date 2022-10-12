using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString("ConnectionStrings:DefaultConnection")))
                {

                    string query = "RolGetAll";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    DataTable RolTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(RolTable);

                    if (RolTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in RolTable.Rows)
                        {
                            ML.Rol Rol = new ML.Rol();
                            Rol.IdRol = int.Parse(row[0].ToString());
                            Rol.Nombre = row[1].ToString();

                            result.Objects.Add(Rol);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro registro del rol";
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
