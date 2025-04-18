

namespace Parcial2_ChiribogaEmily.Modelos
{
    public class dto_Vehiculo
    {
        public int ID_Vehiculo { get; set; }
        public string Placa { get; set; } 
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public string NombreVehiculo { get; set; }
        public int? ID_Conductor { get; set; }
        public string NombreConductor { get; set; }
        public string Telefono { get; set; }
    }
}