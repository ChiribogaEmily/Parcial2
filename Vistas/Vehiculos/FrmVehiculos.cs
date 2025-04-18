using Parcial2_ChiribogaEmily.Controladores;
using Parcial2_ChiribogaEmily.Modelos;
using System;
using System.Windows.Forms;

namespace Parcial2_ChiribogaEmily.Vistas.Vehiculos
{
    public partial class FrmVehiculos : Form
    {
        private int idVehiculo = 0;
        public FrmVehiculos(int idVehiculo)
        {
            InitializeComponent();
            this.idVehiculo = idVehiculo;
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            cargarConductores();
            cargarDatosVehiculo(idVehiculo);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }



        private void cargarDatosVehiculo(int id)
        {
            if (id != 0)
            {
                cls_Vehiculos cls_vehiculos = new cls_Vehiculos();
                var vehiculo = cls_vehiculos.uno(id);
                if (vehiculo != null)
                {
                    txtMarca.Text = vehiculo.Marca;
                    txtModelo.Text = vehiculo.Modelo;
                    txtPlaca.Text = vehiculo.Placa;
                    cmbConductor.SelectedValue = vehiculo.ID_Conductor;
                }
            }
        }
        private void cargarConductores()
        {
            cls_Conductores cls_conductores = new cls_Conductores();
            var rutas = cls_conductores.todos();
            cmbConductor.DataSource = rutas;
            cmbConductor.DisplayMember = "Nombre";
            cmbConductor.ValueMember = "ID_Conductor";
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtModelo.Text == "" || txtMarca.Text == ""
                || txtPlaca.Text == "")

            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }

            cls_Vehiculos cls_vehiculos = new cls_Vehiculos();
            var mensaje = "";
            dto_Vehiculo vehiculo = new dto_Vehiculo
            {
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                Placa = txtPlaca.Text,
                ID_Conductor = (int)cmbConductor.SelectedValue
            };
            if (idVehiculo != 0)
            {
                vehiculo.ID_Vehiculo = idVehiculo;
                mensaje = cls_vehiculos.editar(vehiculo);
            }
            else
            {
                mensaje = cls_vehiculos.insertar(vehiculo);
            }
            if (mensaje == "OK")
            {
                MessageBox.Show("Registro guardado correctamente");
            }
            else
            {
                MessageBox.Show("Hubo un problema guardando el registro");

            }

            this.Close();
        }



        private void cmbConductores_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
