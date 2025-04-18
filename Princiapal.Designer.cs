namespace Parcial2_ChiribogaEmily
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRutas = new System.Windows.Forms.Button();
            this.btnEstudiantes = new System.Windows.Forms.Button();
            this.btnVehiculos = new System.Windows.Forms.Button();
            this.btnConductores = new System.Windows.Forms.Button();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.contenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRutas);
            this.panel1.Controls.Add(this.btnEstudiantes);
            this.panel1.Controls.Add(this.btnVehiculos);
            this.panel1.Controls.Add(this.btnConductores);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 74);
            this.panel1.TabIndex = 0;
            // 
            // btnRutas
            // 
            this.btnRutas.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRutas.Location = new System.Drawing.Point(570, 0);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Size = new System.Drawing.Size(207, 74);
            this.btnRutas.TabIndex = 7;
            this.btnRutas.Text = "Rutas";
            this.btnRutas.UseVisualStyleBackColor = true;
            this.btnRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // btnEstudiantes
            // 
            this.btnEstudiantes.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEstudiantes.Location = new System.Drawing.Point(380, 0);
            this.btnEstudiantes.Name = "btnEstudiantes";
            this.btnEstudiantes.Size = new System.Drawing.Size(190, 74);
            this.btnEstudiantes.TabIndex = 6;
            this.btnEstudiantes.Text = "Estudiantes";
            this.btnEstudiantes.UseVisualStyleBackColor = true;
            this.btnEstudiantes.Click += new System.EventHandler(this.btnEstudiantes_Click);
            // 
            // btnVehiculos
            // 
            this.btnVehiculos.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnVehiculos.Location = new System.Drawing.Point(190, 0);
            this.btnVehiculos.Name = "btnVehiculos";
            this.btnVehiculos.Size = new System.Drawing.Size(190, 74);
            this.btnVehiculos.TabIndex = 5;
            this.btnVehiculos.Text = "Vehiculos";
            this.btnVehiculos.UseVisualStyleBackColor = true;
            this.btnVehiculos.Click += new System.EventHandler(this.btnVehiculos_Click);
            // 
            // btnConductores
            // 
            this.btnConductores.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnConductores.Location = new System.Drawing.Point(0, 0);
            this.btnConductores.Name = "btnConductores";
            this.btnConductores.Size = new System.Drawing.Size(190, 74);
            this.btnConductores.TabIndex = 4;
            this.btnConductores.Text = "Conductores";
            this.btnConductores.UseVisualStyleBackColor = true;
            this.btnConductores.Click += new System.EventHandler(this.btnConductores_Click);
            // 
            // contenedor
            // 
            this.contenedor.Controls.Add(this.label1);
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 74);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(777, 466);
            this.contenedor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido al Sistema de control de Rutas Escolares";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 540);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Rutas Escolares - Chiriboga Emily";
            this.panel1.ResumeLayout(false);
            this.contenedor.ResumeLayout(false);
            this.contenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRutas;
        private System.Windows.Forms.Button btnEstudiantes;
        private System.Windows.Forms.Button btnVehiculos;
        private System.Windows.Forms.Button btnConductores;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label1;
    }
}

