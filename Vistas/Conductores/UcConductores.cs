using Parcial2_ChiribogaEmily.Controladores;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Parcial2_ChiribogaEmily.Vistas.Conductores
{
    public partial class UcConductores : UserControl
    {
        public UcConductores()
        {
            InitializeComponent();
            cargarEstilosTabla();
            this.llenarGrilla(1);
        }

        private void cargarEstilosTabla()
        {
            tablaConductores.ColumnHeadersDefaultCellStyle.Font = new Font("Nirmala UI", 12, FontStyle.Bold);


            tablaConductores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tablaConductores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            tablaConductores.AllowUserToResizeColumns = false;
            tablaConductores.AllowUserToResizeRows = false;
            tablaConductores.DefaultCellStyle.Font = new Font("Nirmala UI", 12);
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmConductores frmConductores = new FrmConductores(0);
            frmConductores.ShowDialog();
            this.llenarGrilla(1);

        }
        /*
         int number = Parametro para identificar el tipo de carga de la grilla
        number = 1; llamar a todos()
        number = 2; llamar a buscar()
         */
        public void llenarGrilla(int number)
        {
            var cls_conductores = new cls_Conductores();

            tablaConductores.DataSource = "";
            tablaConductores.Columns.Clear();
            var autoIncrement = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            tablaConductores.Columns.Add(autoIncrement);


            if (number == 1)
            {

                tablaConductores.DataSource = cls_conductores.todos();
            }



            tablaConductores.Columns["Nombre"].HeaderText = "Nombre";
            tablaConductores.Columns["Licencia"].HeaderText = "Licencia";
            tablaConductores.Columns["Telefono"].HeaderText = "Telefono";
            tablaConductores.Columns["Fecha_Contratacion"].HeaderText = "Fecha de Contratacion";
            tablaConductores.Columns["ID_Conductor"].Visible = false;

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


            tablaConductores.Columns.Add(btnEditar);
            tablaConductores.Columns.Add(btnEliminar);

        }

        private void tablaConductores_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            for (int i = 0; i < tablaConductores.Rows.Count; i++)
            {
                tablaConductores.Rows[i].Cells[0].Value = i + 1;
            }

        }

        public void editarConductor(int id)
        {

            FrmConductores frmConductores = new FrmConductores(id);
            frmConductores.ShowDialog();
            this.llenarGrilla(1);

        }
        public void eliminarConductor(int id)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro?", "Eliminar Conductor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                cls_Conductores cls_conductores = new cls_Conductores();

                if (cls_conductores.eliminar(id) == "OK")
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
        private void tablaConductores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (tablaConductores.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaSeleccionada = tablaConductores.Rows[e.RowIndex];
                var idConductor = filaSeleccionada.Cells["ID_Conductor"].Value;


                if (tablaConductores.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    editarConductor((int)idConductor);
                }

                if (tablaConductores.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    eliminarConductor((int)idConductor);
                }

            }
        }

    }
}
