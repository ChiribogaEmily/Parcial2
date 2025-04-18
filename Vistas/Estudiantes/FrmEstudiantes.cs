
using Parcial2_ChiribogaEmily.Controladores;
using Parcial2_ChiribogaEmily.Modelos;
using System;
using System.Windows.Forms;

namespace Parcial2_ChiribogaEmily.Vistas.Estudiantes
{
    public partial class FrmEstudiantes : Form
    {
        private int idEstudiante = 0;
        public FrmEstudiantes(int idEstudiante)
        {
            InitializeComponent();
            this.idEstudiante = idEstudiante;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmEstudiantes_Load(object sender, EventArgs e)
        {
            cargarRutas();
            cargarDatosEstudiante(idEstudiante);
        }

        private void cargarDatosEstudiante(int id)
        {
            if (id != 0)
            {
                cls_Estudiantes cls_estudiantees = new cls_Estudiantes();
                var estudiante = cls_estudiantees.uno(id);
                if (estudiante != null)
                {
                    txtNombre.Text = estudiante.Nombre;
                    txtApellido.Text = estudiante.Apellido;
                    txtTelefono.Text = estudiante.Telefono;
                    rtxtDireccion.Text = estudiante.Direccion;
                    txtGrado.Text = estudiante.Grado;
                    cmbRutas.SelectedValue = estudiante.ID_Ruta;

                }
            }
        }
        private void cargarRutas()
        {
            cls_Rutas cls_rutas = new cls_Rutas();
            var rutas = cls_rutas.todos();
            cmbRutas.DataSource = rutas;
            cmbRutas.DisplayMember = "Nombre";
            cmbRutas.ValueMember = "ID_Ruta";
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtTelefono.Text == "" 
                || txtApellido.Text == "" || rtxtDireccion.Text == ""
                || txtGrado.Text == "" || cmbRutas.SelectedValue == null)
                
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
            cls_Estudiantes cls_estudiantees = new cls_Estudiantes();
            var mensaje = "";
            dto_Estudiante estudiante = new dto_Estudiante
            {
                ID_Ruta = (int)cmbRutas.SelectedValue,

                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Apellido = txtApellido.Text,
                Direccion = rtxtDireccion.Text,
                Grado = txtGrado.Text
            };
            if (idEstudiante != 0)
            {
                estudiante.ID_Estudiante = idEstudiante;
                mensaje = cls_estudiantees.editar(estudiante);
            }
            else
            {
                mensaje = cls_estudiantees.insertar(estudiante);
            }
            if(mensaje == "OK")
            {
                MessageBox.Show("Registro guardado correctamente");
            } else
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

        }

        private void cmbRutas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
