using Parcial2_ChiribogaEmily.Controladores;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Parcial2_ChiribogaEmily.Vistas.Estudiantes
{
    public partial class UcEstudiantes : UserControl
    {
        public UcEstudiantes()
        {
            InitializeComponent();
            cargarEstilosTabla();
            this.llenarGrilla(1);
        }

        private void cargarEstilosTabla()
        {
            tablaEstudiantes.ColumnHeadersDefaultCellStyle.Font = new Font("Nirmala UI", 12, FontStyle.Bold);


            tablaEstudiantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tablaEstudiantes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            tablaEstudiantes.AllowUserToResizeColumns = false;
            tablaEstudiantes.AllowUserToResizeRows = false;
            tablaEstudiantes.DefaultCellStyle.Font = new Font("Nirmala UI", 12);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmEstudiantes frmEstudiantes = new FrmEstudiantes(0);
            frmEstudiantes.ShowDialog();
            this.llenarGrilla(1);

        }
        /*
         int number = Parametro para identificar el tipo de carga de la grilla
        number = 1; llamar a todos()
        number = 2; llamar a buscar()
         */
        public void llenarGrilla(int number)
        {
            var cls_estudiantes = new cls_Estudiantes();

            tablaEstudiantes.DataSource = "";
            tablaEstudiantes.Columns.Clear();
            var autoIncrement = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            tablaEstudiantes.Columns.Add(autoIncrement);


            if (number == 1)
            {

                tablaEstudiantes.DataSource = cls_estudiantes.todos();
            }

            /*
                     public int ID_Estudiante { get; set; }
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public string Grado { get; set; } 
        public string Direccion { get; set; } 
        public int ID_Ruta { get; set; }

        public string Telefono { get; set; }
        public string NombreRuta { get; set; } 
             */

            tablaEstudiantes.Columns["Nombre"].HeaderText = "Nombre";
            tablaEstudiantes.Columns["Apellido"].HeaderText = "Apellido";
            tablaEstudiantes.Columns["Grado"].HeaderText = "Grado";
            tablaEstudiantes.Columns["Telefono"].HeaderText = "Telefono";
            tablaEstudiantes.Columns["Direccion"].HeaderText = "Direccion";
            tablaEstudiantes.Columns["NombreRuta"].HeaderText = "Ruta";
            tablaEstudiantes.Columns["ID_Estudiante"].Visible = false;
            tablaEstudiantes.Columns["ID_Ruta"].Visible = false;


            var btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };

            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };


            tablaEstudiantes.Columns.Add(btnEditar);
            tablaEstudiantes.Columns.Add(btnEliminar);

        }

        private void tablaEstudiantes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            for (int i = 0; i < tablaEstudiantes.Rows.Count; i++)
            {
                tablaEstudiantes.Rows[i].Cells[0].Value = i + 1;
            }

        }



        public void editarEstudiante(int id)
        {

            FrmEstudiantes frmEstudiantes = new FrmEstudiantes(id);
            frmEstudiantes.ShowDialog();
            this.llenarGrilla(1);

        }
        public void eliminarEstudiante(int id)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro?", "Eliminar Estudiante", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                cls_Estudiantes cls_estudiantes = new cls_Estudiantes();

                if (cls_estudiantes.eliminar(id) == "OK")
                {
                    MessageBox.Show("Registro se ha eliminado correctamente");
                    this.llenarGrilla(1);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al eliminar");


                }
                this.llenarGrilla(1);
            }
            else
            {
                MessageBox.Show("El usuario canceló la eliminación");
            }
        }
        private void tablaEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (tablaEstudiantes.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaSeleccionada = tablaEstudiantes.Rows[e.RowIndex];
                var idEstudiante = filaSeleccionada.Cells["ID_Estudiante"].Value;


                if (tablaEstudiantes.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    editarEstudiante((int)idEstudiante);
                }

                if (tablaEstudiantes.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    eliminarEstudiante((int)idEstudiante);
                }

            }
        }
    }
}
