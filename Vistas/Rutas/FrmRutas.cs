
using Parcial2_ChiribogaEmily.Controladores;
using Parcial2_ChiribogaEmily.Modelos;
using System;
using System.Windows.Forms;

namespace Parcial2_ChiribogaEmily.Vistas.Rutas
{
    public partial class FrmRutas : Form
    {
        private int idRuta = 0;
        public FrmRutas(int idRuta)
        {
            InitializeComponent();
            this.idRuta = idRuta;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmRutas_Load(object sender, EventArgs e)
        {
            cargarVehiculos();
            cargarDatosRuta(idRuta);
        }

        private void cargarDatosRuta(int id)
        {
            if (id != 0)
            {
                cls_Rutas cls_rutas = new cls_Rutas();
                var ruta = cls_rutas.uno(id);
                if (ruta != null)
                {
                    txtNombre.Text = ruta.Nombre;
                    hSalida.Value = DateTime.Parse(ruta.Hora_Salida.ToString());
                    hRegreso.Value = DateTime.Parse(ruta.Hora_Regreso.ToString());
                    rtxtDesc.Text = ruta.Descripcion;
                    cmbVehiculos.SelectedValue = ruta.ID_Vehiculo;

                }
            }
        }
        private void cargarVehiculos()
        {
            cls_Vehiculos cls_vehiculos = new cls_Vehiculos();
            var rutas = cls_vehiculos.todos();
            cmbVehiculos.DataSource = rutas;
            cmbVehiculos.DisplayMember = "NombreVehiculo";
            cmbVehiculos.ValueMember = "ID_Vehiculo";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || rtxtDesc.Text == "" ||
                 cmbVehiculos.SelectedValue == null)

            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            if (hSalida.Value.TimeOfDay >= hRegreso.Value.TimeOfDay)
            {
                MessageBox.Show("La hora de salida tiene que ser antes de la hora de regreso");
                return;
            }

            cls_Rutas cls_rutas = new cls_Rutas();
            var mensaje = "";
            dto_Ruta ruta = new dto_Ruta
            {
                ID_Ruta = (int)cmbVehiculos.SelectedValue,

                Nombre = txtNombre.Text,
                ID_Vehiculo = (int)cmbVehiculos.SelectedValue,
                Descripcion = rtxtDesc.Text,  
                Hora_Regreso = hRegreso.Value.TimeOfDay,
                Hora_Salida = hSalida.Value.TimeOfDay
                

            };
            if (idRuta != 0)
            {
                ruta.ID_Ruta = idRuta;
                mensaje = cls_rutas.editar(ruta);
            }
            else
            {
                mensaje = cls_rutas.insertar(ruta);
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


        private void cmbVehiculos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}

