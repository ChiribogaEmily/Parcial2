using Parcial2_ChiribogaEmily.Controladores;
using Parcial2_ChiribogaEmily.Vistas.Vehiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_ChiribogaEmily.Vistas.Vehiculos
{
    public partial class UcVehiculos : UserControl
    {
        public UcVehiculos()
        {
            InitializeComponent();
            cargarEstilosTabla();
            this.llenarGrilla(1);
        }


        private void cargarEstilosTabla()
        {
            tablaVehiculos.ColumnHeadersDefaultCellStyle.Font = new Font("Nirmala UI", 12, FontStyle.Bold);


            tablaVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tablaVehiculos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            tablaVehiculos.AllowUserToResizeColumns = false;
            tablaVehiculos.AllowUserToResizeRows = false;
            tablaVehiculos.DefaultCellStyle.Font = new Font("Nirmala UI", 12);
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmVehiculos frmVehiculos = new FrmVehiculos(0);
            frmVehiculos.ShowDialog();
            this.llenarGrilla(1);

        }
        /*
         int number = Parametro para identificar el tipo de carga de la grilla
        number = 1; llamar a todos()
        number = 2; llamar a buscar()
         */
        public void llenarGrilla(int number)
        {
            var cls_vehiculos = new cls_Vehiculos();

            tablaVehiculos.DataSource = "";
            tablaVehiculos.Columns.Clear();
            var autoIncrement = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            tablaVehiculos.Columns.Add(autoIncrement);


            if (number == 1)
            {

                tablaVehiculos.DataSource = cls_vehiculos.todos();
            }

            /*
                     public int ID_Vehiculo { get; set; }
        public string Placa { get; set; } 
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public string NombreVehiculo { get; set; }
        public int? ID_Conductor { get; set; }
        public string NombreConductor { get; set; }
        public string Telefono { get; set; }
             */

            tablaVehiculos.Columns["NombreVehiculo"].HeaderText = "Nombre";
            tablaVehiculos.Columns["Placa"].HeaderText = "Placa";


            tablaVehiculos.Columns["ID_Vehiculo"].Visible = false;
            tablaVehiculos.Columns["Marca"].Visible = false;
            tablaVehiculos.Columns["Modelo"].Visible = false;
            tablaVehiculos.Columns["ID_Conductor"].Visible = false;
            tablaVehiculos.Columns["NombreConductor"].Visible = false;
            tablaVehiculos.Columns["Telefono"].Visible = false;

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


            tablaVehiculos.Columns.Add(btnEditar);
            tablaVehiculos.Columns.Add(btnEliminar);

        }

        private void tablaVehiculos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            for (int i = 0; i < tablaVehiculos.Rows.Count; i++)
            {
                tablaVehiculos.Rows[i].Cells[0].Value = i + 1;
            }

        }

        public void editarVehiculo(int id)
        {

            FrmVehiculos frmVehiculos = new FrmVehiculos(id);
            frmVehiculos.ShowDialog();
            this.llenarGrilla(1);

        }
        public void eliminarVehiculo(int id)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro?", "Eliminar Vehiculo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                cls_Vehiculos cls_vehiculos = new cls_Vehiculos();

                if (cls_vehiculos.eliminar(id) == "OK")
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
        private void tablaVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (tablaVehiculos.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaSeleccionada = tablaVehiculos.Rows[e.RowIndex];
                var idVehiculo = filaSeleccionada.Cells["ID_Vehiculo"].Value;


                if (tablaVehiculos.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    editarVehiculo((int)idVehiculo);
                }

                if (tablaVehiculos.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    eliminarVehiculo((int)idVehiculo);
                }

            }
        }

    }
}
