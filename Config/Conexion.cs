

using System.Data.SqlClient;

namespace Parcial2_ChiribogaEmily.Config
{
    class Conexion
    {
        private readonly string cadena = "Server=.;Database=ControlTransporteEscolar;uid=root;pwd=123456;TrustServerCertificate=True";


        public SqlConnection obetenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
