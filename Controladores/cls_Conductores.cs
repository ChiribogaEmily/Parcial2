using Parcial2_ChiribogaEmily.Config;
using Parcial2_ChiribogaEmily.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Parcial2_ChiribogaEmily.Controladores
{
    public class cls_Conductores
    {
        private readonly Conexion cn = new Conexion();

        
        public string insertar(dto_Conductor conductor)
        {
            string cadena = "INSERT INTO Conductores (Nombre, Licencia, Telefono, Fecha_Contratacion) " +
                           "VALUES (@Nombre, @Licencia, @Telefono, @Fecha)";

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand(cadena, conexion))
            {
                comando.Parameters.AddWithValue("@Nombre", conductor.Nombre);
                comando.Parameters.AddWithValue("@Licencia", conductor.Licencia);
                comando.Parameters.AddWithValue("@Telefono", conductor.Telefono ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Fecha", conductor.Fecha_Contratacion);

                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

       
        public List<dto_Conductor> todos()
        {
            var lista = new List<dto_Conductor>();

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand("SELECT * FROM Conductores", conexion))
            {
                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new dto_Conductor
                        {
                            ID_Conductor = (int)lector["ID_Conductor"],
                            Nombre = lector["Nombre"].ToString(),
                            Licencia = lector["Licencia"].ToString(),
                            Telefono = lector["Telefono"].ToString(),
                            Fecha_Contratacion = (DateTime)lector["Fecha_Contratacion"]
                            
                        });
                    }
                }
            }
            return lista;
        }

        public dto_Conductor uno(int id)
        {
            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand("SELECT * FROM Conductores WHERE ID_Conductor = @ID", conexion))
            {
                comando.Parameters.AddWithValue("@ID", id);
                conexion.Open();

                using (var lector = comando.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        return new dto_Conductor
                        {
                            ID_Conductor = (int)lector["ID_Conductor"],
                            Nombre = lector["Nombre"].ToString(),
                            Licencia = lector["Licencia"].ToString(),
                            Telefono = lector["Telefono"].ToString(),
                            Fecha_Contratacion = (DateTime)lector["Fecha_Contratacion"]
                        };
                    }
                }
            }
            return null;
        }

        
        public string editar(dto_Conductor conductor)
        {
            string cadena = "UPDATE Conductores SET Nombre = @Nombre, Licencia = @Licencia, " +
                           "Telefono = @Telefono, Fecha_Contratacion = @Fecha " +
                           "WHERE ID_Conductor = @ID";

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand(cadena, conexion))
            {
                comando.Parameters.AddWithValue("@ID", conductor.ID_Conductor);
                comando.Parameters.AddWithValue("@Nombre", conductor.Nombre);
                comando.Parameters.AddWithValue("@Licencia", conductor.Licencia);
                comando.Parameters.AddWithValue("@Telefono", conductor.Telefono ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Fecha", conductor.Fecha_Contratacion);

                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

        
        public string eliminar(int id)
        {
            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand("DELETE FROM Conductores WHERE ID_Conductor = @ID", conexion))
            {
                comando.Parameters.AddWithValue("@ID", id);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }
    }
}
