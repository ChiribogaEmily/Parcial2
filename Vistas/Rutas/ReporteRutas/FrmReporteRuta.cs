using System;
using System.Windows.Forms;

namespace Parcial2_ChiribogaEmily.Vistas.Rutas.ReporteRutas
{
    public partial class FrmReporteRuta : Form
    {
        private int idRuta = 0;
        public FrmReporteRuta(int idRuta)
        {
            InitializeComponent();
            this.idRuta = idRuta;
        }

        private void FrmReporteRuta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'controlTransporteEscolarDataSet.Estudiantes' Puede moverla o quitarla según sea necesario.
            this.estudiantesTableAdapter.FillByRutaRutaEstudiante(this.controlTransporteEscolarDataSet.Estudiantes, idRuta);
            // TODO: esta línea de código carga datos en la tabla 'controlTransporteEscolarDataSet1.Rutas' Puede moverla o quitarla según sea necesario.


            this.reportViewer1.RefreshReport();
        }


    }
}
