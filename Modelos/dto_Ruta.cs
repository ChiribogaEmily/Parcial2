using System;


namespace Parcial2_ChiribogaEmily.Modelos
{
    public class dto_Ruta
    {
        public int ID_Ruta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Hora_Salida { get; set; }
        public TimeSpan Hora_Regreso { get; set; }
        public string NombreConductor { get; set; }
        public int? ID_Vehiculo { get; set; }
        public string PlacaVehiculo { get; set; }
    }
}
