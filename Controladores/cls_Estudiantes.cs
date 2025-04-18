using Parcial2_ChiribogaEmily.Config;
using Parcial2_ChiribogaEmily.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Parcial2_ChiribogaEmily.Controladores
{
    public class cls_Estudiantes
    {
        private readonly Conexion cn = new Conexion();

      
        public string insertar(dto_Estudiante estudiante)
        {
            string cadena = "INSERT INTO Estudiantes (Nombre, Apellido, Grado, Direccion, Telefono, ID_Ruta) " +
                           "VALUES (@Nombre, @Apellido, @Grado, @Direccion, @Telefono, @Ruta)";

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand(cadena, conexion))
            {
                comando.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                comando.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                comando.Parameters.AddWithValue("@Grado", estudiante.Grado);
                comando.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
                comando.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
                comando.Parameters.AddWithValue("@Ruta", estudiante.ID_Ruta);

                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

    
        public List<dto_Estudiante> todos()
        {
            var lista = new List<dto_Estudiante>();

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand(@"SELECT e.*, r.Nombre as NombreRuta
                        FROM Estudiantes e
                        LEFT JOIN Rutas r ON e.ID_Ruta = r.ID_Ruta", conexion))
            {
                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new dto_Estudiante
                        {
                            ID_Estudiante = (int)lector["ID_Estudiante"],
                            Nombre = lector["Nombre"].ToString(),
                            Apellido = lector["Apellido"].ToString(),
                            Grado = lector["Grado"].ToString(),
                            Direccion = lector["Direccion"].ToString(),
                            
                            Telefono = lector["Telefono"].ToString(),
                            NombreRuta = lector["NombreRuta"].ToString(),
                            ID_Ruta = (int)lector["ID_Ruta"] 
                        });
                    }
                }
            }
            return lista;
        }

        public dto_Estudiante uno(int id)
        {
            using (var conexion = cn.obetenerConexion())
            {
                conexion.Open();
                string query = @"SELECT e.*, r.Nombre as NombreRuta 
                        FROM Estudiantes e
                        LEFT JOIN Rutas r ON e.ID_Ruta = r.ID_Ruta
                        WHERE e.ID_Estudiante = @Id";

                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", id);

                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new dto_Estudiante
                            {
                                ID_Estudiante = (int)lector["ID_Estudiante"],
                                Nombre = lector["Nombre"].ToString(),
                                Apellido = lector["Apellido"].ToString(),
                                Grado = lector["Grado"].ToString(),
                                Direccion = lector["Direccion"].ToString(),
                                Telefono = lector["Telefono"].ToString(),
                                ID_Ruta = (int)lector["ID_Ruta"],
                                NombreRuta = lector["NombreRuta"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public string editar(dto_Estudiante estudiante)
        {
            string cadena = "UPDATE Estudiantes SET Nombre = @Nombre, Apellido = @Apellido, " +
                           "Grado = @Grado, Direccion = @Direccion, Telefono = @Telefono, ID_Ruta = @Ruta " +
                           "WHERE ID_Estudiante = @ID";

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand(cadena, conexion))
            {
                comando.Parameters.AddWithValue("@ID", estudiante.ID_Estudiante);
                comando.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                comando.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                comando.Parameters.AddWithValue("@Grado", estudiante.Grado);
                comando.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
                comando.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
                comando.Parameters.AddWithValue("@Ruta", estudiante.ID_Ruta);

                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

     
        public string eliminar(int id)
        {
            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand("DELETE FROM Estudiantes WHERE ID_Estudiante = @ID", conexion))
            {
                comando.Parameters.AddWithValue("@ID", id);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

        // Método adicional para asignar ruta
        public string asignarRuta(int idEstudiante, int? idRuta)
        {
            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand("UPDATE Estudiantes SET ID_Ruta = @Ruta WHERE ID_Estudiante = @ID", conexion))
            {
                comando.Parameters.AddWithValue("@ID", idEstudiante);
                comando.Parameters.AddWithValue("@Ruta", idRuta);

                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }
    }
}
