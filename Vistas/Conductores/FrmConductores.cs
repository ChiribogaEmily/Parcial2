using Parcial2_ChiribogaEmily.Controladores;
using Parcial2_ChiribogaEmily.Modelos;
using System;
using System.Windows.Forms;

namespace Parcial2_ChiribogaEmily.Vistas.Conductores
{
    public partial class FrmConductores : Form
    {
        private int idConductor = 0;
        public FrmConductores(int idConductor)
        {
            InitializeComponent();
            this.idConductor = idConductor;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmConductores_Load(object sender, EventArgs e)
        {
            cargarDatosConductor(idConductor);
        }

        private void cargarDatosConductor(int id)
        {
            if (id != 0)
            {
                cls_Conductores cls_conductores = new cls_Conductores();
                var estudiante = cls_conductores.uno(id);
                if (estudiante != null)
                {
                    txtNombre.Text = estudiante.Nombre;
                    txtTelefono.Text = estudiante.Telefono;
                    fechaContratacion.Value = (DateTime)estudiante.Fecha_Contratacion;
                    txtLicencia.Text = estudiante.Licencia;
                }
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtLicencia.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            if (txtTelefono.Text.Length < 10)
            {
                MessageBox.Show("El número de teléfono debe tener al menos 10 dígitos");
                return;
            }
            if (txtTelefono.Text.Length > 11)
            {
                MessageBox.Show("El número de teléfono no debe tener más de 11 dígitos");
                return;
            }
            cls_Conductores cls_conductores = new cls_Conductores();
            var mensaje = "";
            dto_Conductor conductor = new dto_Conductor
            {
                Fecha_Contratacion = fechaContratacion.Value,
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Licencia = txtLicencia.Text
            };
            if (idConductor != 0)
            {
                conductor.ID_Conductor = idConductor;
                mensaje = cls_conductores.editar(conductor);
            }
            else
            {
                mensaje = cls_conductores.insertar(conductor);
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtLicencia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
