using Parcial2_ChiribogaEmily.Config;
using Parcial2_ChiribogaEmily.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Parcial2_ChiribogaEmily.Controladores
{
    public class cls_Rutas
    {
        private readonly Conexion cn = new Conexion();

        public string insertar(dto_Ruta ruta)
        {
            string cadena = "INSERT INTO Rutas (Nombre, Descripcion, Hora_Salida, Hora_Regreso, ID_Vehiculo) " +
                           "VALUES (@Nombre, @Descripcion, @Salida, @Regreso, @Vehiculo)";

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand(cadena, conexion))
            {
                comando.Parameters.AddWithValue("@Nombre", ruta.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", ruta.Descripcion);
                comando.Parameters.AddWithValue("@Salida", ruta.Hora_Salida);
                comando.Parameters.AddWithValue("@Regreso", ruta.Hora_Regreso);
                comando.Parameters.AddWithValue("@Vehiculo", ruta.ID_Vehiculo);

                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

        
        public List<dto_Ruta> todos()
        {
            var lista = new List<dto_Ruta>();

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand(@"SELECT r.*, v.Placa, v.ID_Conductor, c.Nombre as NombreConductor
                        FROM Rutas r
                        JOIN Vehiculos v ON r.ID_Vehiculo = v.ID_Vehiculo
						JOIN Conductores c ON v.ID_Conductor = c.ID_Conductor;", conexion))
            {
                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new dto_Ruta
                        {
                            ID_Ruta = (int)lector["ID_Ruta"],
                            Nombre = lector["Nombre"].ToString(),
                            Descripcion = lector["Descripcion"].ToString(),
                            Hora_Salida = DateTime.Parse(lector["Hora_Salida"].ToString()).TimeOfDay,
                            Hora_Regreso = DateTime.Parse(lector["Hora_Regreso"].ToString()).TimeOfDay,
                            PlacaVehiculo = lector["Placa"].ToString(),
                            NombreConductor = lector["NombreConductor"].ToString(),
                            ID_Vehiculo = (int)lector["ID_Vehiculo"]
                        });
                    }
                }
            }
            return lista;
        }

        public dto_Ruta uno(int id)
        {
            using (var conexion = cn.obetenerConexion())
            {
                conexion.Open();
                string cadena = @"  SELECT r.*, v.Placa, v.ID_Conductor, c.Nombre as NombreConductor
                        FROM Rutas r
                        JOIN Vehiculos v ON r.ID_Vehiculo = v.ID_Vehiculo
						JOIN Conductores c ON v.ID_Conductor = c.ID_Conductor
                        WHERE r.ID_Ruta = @Id";

                using (var comando = new SqlCommand(cadena, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", id);

                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new dto_Ruta
                            {
                                ID_Ruta = (int)lector["ID_Ruta"],
                                Nombre = lector["Nombre"].ToString(),
                                Descripcion = lector["Descripcion"].ToString(),
                                Hora_Salida = DateTime.Parse(lector["Hora_Salida"].ToString()).TimeOfDay,
                                Hora_Regreso = DateTime.Parse(lector["Hora_Regreso"].ToString()).TimeOfDay,
                                ID_Vehiculo = (int)lector["ID_Vehiculo"],
                                NombreConductor = lector["NombreConductor"].ToString(),
                                PlacaVehiculo = lector["Placa"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
        public string editar(dto_Ruta ruta)
        {
            string cadena = "UPDATE Rutas SET Nombre = @Nombre, Descripcion = @Descripcion, " +
                           "Hora_Salida = @Salida, Hora_Regreso = @Regreso, ID_Vehiculo = @Vehiculo " +
                           "WHERE ID_Ruta = @ID";

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand(cadena, conexion))
            {
                comando.Parameters.AddWithValue("@ID", ruta.ID_Ruta);
                comando.Parameters.AddWithValue("@Nombre", ruta.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", ruta.Descripcion);
                comando.Parameters.AddWithValue("@Salida", ruta.Hora_Salida);
                comando.Parameters.AddWithValue("@Regreso", ruta.Hora_Regreso);
                comando.Parameters.AddWithValue("@Vehiculo", ruta.ID_Vehiculo);

                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

        
        public string eliminar(int id)
        {
            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand("DELETE FROM Rutas WHERE ID_Ruta = @ID", conexion))
            {
                comando.Parameters.AddWithValue("@ID", id);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }
    }
}
