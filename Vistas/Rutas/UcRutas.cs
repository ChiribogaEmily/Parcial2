using Parcial2_ChiribogaEmily.Controladores;
using Parcial2_ChiribogaEmily.Vistas.Rutas.ReporteRutas;
using System;

using System.Drawing;

using System.Windows.Forms;

namespace Parcial2_ChiribogaEmily.Vistas.Rutas
{
    public partial class UcRutas : UserControl
    {
        public UcRutas()
        {
            InitializeComponent();
            cargarEstilosTabla();
            llenarGrilla(1);
        }


        private void cargarEstilosTabla()
        {
            tablaRutas.ColumnHeadersDefaultCellStyle.Font = new Font("Nirmala UI", 12, FontStyle.Bold);


            tablaRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tablaRutas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            tablaRutas.AllowUserToResizeColumns = false;
            tablaRutas.AllowUserToResizeRows = false;
            tablaRutas.DefaultCellStyle.Font = new Font("Nirmala UI", 12);
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmRutas frmRutaes = new FrmRutas(0);
            frmRutaes.ShowDialog();
            this.llenarGrilla(1);

        }
        /*
         int number = Parametro para identificar el tipo de carga de la grilla
        number = 1; llamar a todos()
        number = 2; llamar a buscar()
         */
        public void llenarGrilla(int number)
        {
            var cls_rutas = new cls_Rutas();

            tablaRutas.DataSource = "";
            tablaRutas.Columns.Clear();
            var autoIncrement = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            tablaRutas.Columns.Add(autoIncrement);


            if (number == 1)
            {

                tablaRutas.DataSource = cls_rutas.todos();
            }



            tablaRutas.Columns["Nombre"].HeaderText = "Nombre Ruta";
            tablaRutas.Columns["Descripcion"].HeaderText = "Descripcion";
            tablaRutas.Columns["NombreConductor"].HeaderText = "Conductor";
            tablaRutas.Columns["PlacaVehiculo"].HeaderText = "Placa Vehiculo";

            tablaRutas.Columns["Hora_Salida"].HeaderText = "Hora de Salida";
            tablaRutas.Columns["Hora_Regreso"].HeaderText = "Hora de Regreso";
            tablaRutas.Columns["ID_Ruta"].Visible = false;
            tablaRutas.Columns["ID_Vehiculo"].Visible = false;

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

            var btnReporte = new DataGridViewButtonColumn
            {
                HeaderText = "Reporte",
                Text = "Reporte",
                UseColumnTextForButtonValue = true
            };

            tablaRutas.Columns.Add(btnReporte);
            tablaRutas.Columns.Add(btnEditar);
            tablaRutas.Columns.Add(btnEliminar);

        }

        private void tablaRutas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            for (int i = 0; i < tablaRutas.Rows.Count; i++)
            {
                tablaRutas.Rows[i].Cells[0].Value = i + 1;
            }

        }

        public void editarRuta(int id)
        {

            FrmRutas frmRutas = new FrmRutas(id);
            frmRutas.ShowDialog();
            this.llenarGrilla(1);

        }
        public void eliminarRuta(int id)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro?", "Eliminar Ruta", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                cls_Rutas cls_rutas = new cls_Rutas();

                if (cls_rutas.eliminar(id) == "OK")
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

        private void abrirReporteRuta(int idRuta)
        {
            FrmReporteRuta frmReporteRuta = new FrmReporteRuta(idRuta);
            frmReporteRuta.ShowDialog();
        }


        private void tablaRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (tablaRutas.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaSeleccionada = tablaRutas.Rows[e.RowIndex];
                var idRuta = filaSeleccionada.Cells["ID_Ruta"].Value;

                if (tablaRutas.Columns[e.ColumnIndex].HeaderText == "Reporte")
                {
                    abrirReporteRuta((int)idRuta);
                }
                if (tablaRutas.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    editarRuta((int)idRuta);
                }

                if (tablaRutas.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    eliminarRuta((int)idRuta);
                }

            }
        }

    }
}
