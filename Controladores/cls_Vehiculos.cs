using Parcial2_ChiribogaEmily.Config;
using Parcial2_ChiribogaEmily.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Parcial2_ChiribogaEmily.Controladores
{
    public class cls_Vehiculos
    {
        private readonly Conexion cn = new Conexion();

        
        public string insertar(dto_Vehiculo vehiculo)
        {
            string cadena = "INSERT INTO Vehiculos (Placa, Marca, Modelo, ID_Conductor) " +
                           "VALUES (@Placa, @Marca, @Modelo, @Conductor)";

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand(cadena, conexion))
            {
                comando.Parameters.AddWithValue("@Placa", vehiculo.Placa);
                comando.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                comando.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                comando.Parameters.AddWithValue("@Conductor", vehiculo.ID_Conductor);

                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }


        public List<dto_Vehiculo> todos()
        {
            var lista = new List<dto_Vehiculo>();

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand(@"SELECT v.*, c.Nombre as NombreConductor,
                                                    CONCAT(v.Marca, ' ', v.Modelo) as NombreVehiculo
                                                    FROM Vehiculos v
                                                    LEFT JOIN Conductores c ON v.ID_Conductor = c.ID_Conductor;", conexion))
            {
                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {

                        lista.Add(new dto_Vehiculo
                        {
                            ID_Vehiculo = (int)lector["ID_Vehiculo"],
                            NombreVehiculo = lector["NombreVehiculo"].ToString(),
                            Placa = lector["Placa"].ToString(),
                            Marca = lector["Marca"].ToString(),
                            Modelo = lector["Modelo"].ToString(),
                            
                            ID_Conductor = (int)lector["ID_Conductor"],
                            NombreConductor = lector["NombreConductor"].ToString()
                        });
                    }
                }
            }
            return lista;
        }


        public dto_Vehiculo uno(int id)
        {
            using (var conexion = cn.obetenerConexion())
            {
                conexion.Open();
                string cadena = @"SELECT v.*, c.Nombre as NombreConductor,
                                  CONCAT(v.Marca, ' ', v.Modelo) as NombreVehiculo
                                  FROM Vehiculos v
                                  LEFT JOIN Conductores c ON v.ID_Conductor = c.ID_Conductor
                                  WHERE v.ID_Vehiculo = @Id";

                using (var comando = new SqlCommand(cadena, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", id);

                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new dto_Vehiculo
                            {
                                ID_Vehiculo = (int)lector["ID_Vehiculo"],
                                Placa = lector["Placa"].ToString(),
                                Marca = lector["Marca"].ToString(),
                                Modelo = lector["Modelo"].ToString(),
                                ID_Conductor = (int)lector["ID_Conductor"],
                                NombreConductor = lector["NombreConductor"].ToString(),
                                NombreVehiculo = lector["NombreVehiculo"].ToString()

                            };
                        }
                    }
                }
            }
            return null;
        }

        public string editar(dto_Vehiculo vehiculo)
        {
            string cadena = "UPDATE Vehiculos SET Placa = @Placa, Marca = @Marca, " +
                           "Modelo = @Modelo, ID_Conductor = @Conductor " +
                           "WHERE ID_Vehiculo = @ID";

            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand(cadena, conexion))
            {
                comando.Parameters.AddWithValue("@ID", vehiculo.ID_Vehiculo);
                comando.Parameters.AddWithValue("@Placa", vehiculo.Placa);
                comando.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                comando.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                comando.Parameters.AddWithValue("@Conductor", vehiculo.ID_Conductor);

                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

        public string eliminar(int id)
        {
            using (var conexion = cn.obetenerConexion())
            using (var comando = new SqlCommand("DELETE FROM Vehiculos WHERE ID_Vehiculo = @ID", conexion))
            {
                comando.Parameters.AddWithValue("@ID", id);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }
    }
}
