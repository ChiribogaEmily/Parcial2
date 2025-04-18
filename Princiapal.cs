using Parcial2_ChiribogaEmily.Vistas.Conductores;
using Parcial2_ChiribogaEmily.Vistas.Estudiantes;
using Parcial2_ChiribogaEmily.Vistas.Rutas;
using Parcial2_ChiribogaEmily.Vistas.Vehiculos;
using System;

using System.Windows.Forms;

namespace Parcial2_ChiribogaEmily
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnConductores_Click(object sender, EventArgs e)
        {
            UcConductores ucConductores = new UcConductores();
            ucConductores.Dock = DockStyle.Fill;
            this.contenedor.Controls.Clear();
            this.contenedor.Controls.Add(ucConductores);
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            UcVehiculos ucVehiculos = new UcVehiculos();
            ucVehiculos.Dock = DockStyle.Fill;
            this.contenedor.Controls.Clear();
            this.contenedor.Controls.Add(ucVehiculos);
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            UcEstudiantes ucEstudiantes = new UcEstudiantes();
            ucEstudiantes.Dock = DockStyle.Fill;
            this.contenedor.Controls.Clear();
            this.contenedor.Controls.Add(ucEstudiantes);
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            UcRutas ucRutas = new UcRutas();
            ucRutas.Dock = DockStyle.Fill;
            this.contenedor.Controls.Clear();
            this.contenedor.Controls.Add(ucRutas);
        }
    }
}
