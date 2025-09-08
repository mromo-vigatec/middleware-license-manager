namespace middleware_license_manager
{
    partial class Form1
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
            this.btnGenerarCertificados = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblEstadoCertificado = new System.Windows.Forms.Label();
            this.panelCertificadoInfo = new System.Windows.Forms.Panel();
            this.lblInfoCertificado = new System.Windows.Forms.Label();
            this.btnEliminarCertificado = new System.Windows.Forms.Button();
            this.btnCargarCertificado = new System.Windows.Forms.Button();
            this.btnGenerarLicencia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerarCertificados
            // 
            this.btnGenerarCertificados.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGenerarCertificados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGenerarCertificados.FlatAppearance.BorderSize = 0;
            this.btnGenerarCertificados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarCertificados.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarCertificados.ForeColor = System.Drawing.Color.White;
            this.btnGenerarCertificados.Location = new System.Drawing.Point(120, 200);
            this.btnGenerarCertificados.Name = "btnGenerarCertificados";
            this.btnGenerarCertificados.Size = new System.Drawing.Size(160, 50);
            this.btnGenerarCertificados.TabIndex = 0;
            this.btnGenerarCertificados.Text = "Generar Certificados";
            this.btnGenerarCertificados.UseVisualStyleBackColor = false;
            this.btnGenerarCertificados.Click += new System.EventHandler(this.btnGenerarCertificados_Click);
            // 
            // btnCargarCertificado
            // 
            this.btnCargarCertificado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCargarCertificado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCargarCertificado.FlatAppearance.BorderSize = 0;
            this.btnCargarCertificado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarCertificado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarCertificado.ForeColor = System.Drawing.Color.White;
            this.btnCargarCertificado.Location = new System.Drawing.Point(320, 200);
            this.btnCargarCertificado.Name = "btnCargarCertificado";
            this.btnCargarCertificado.Size = new System.Drawing.Size(160, 50);
            this.btnCargarCertificado.TabIndex = 5;
            this.btnCargarCertificado.Text = "Cargar Certificado";
            this.btnCargarCertificado.UseVisualStyleBackColor = false;
            this.btnCargarCertificado.Click += new System.EventHandler(this.btnCargarCertificado_Click);
            // 
            // btnGenerarLicencia
            // 
            this.btnGenerarLicencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGenerarLicencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnGenerarLicencia.FlatAppearance.BorderSize = 0;
            this.btnGenerarLicencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarLicencia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarLicencia.ForeColor = System.Drawing.Color.Black;
            this.btnGenerarLicencia.Location = new System.Drawing.Point(520, 200);
            this.btnGenerarLicencia.Name = "btnGenerarLicencia";
            this.btnGenerarLicencia.Size = new System.Drawing.Size(160, 50);
            this.btnGenerarLicencia.TabIndex = 6;
            this.btnGenerarLicencia.Text = "Generar Licencia";
            this.btnGenerarLicencia.UseVisualStyleBackColor = false;
            this.btnGenerarLicencia.Click += new System.EventHandler(this.btnGenerarLicencia_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));

            this.lblTitulo.Location = new System.Drawing.Point(250, 50);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Middleware License Manager";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblEstado.Location = new System.Drawing.Point(350, 270);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 19);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Listo para usar";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstadoCertificado
            // 
            this.lblEstadoCertificado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEstadoCertificado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoCertificado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEstadoCertificado.Location = new System.Drawing.Point(200, 100);
            this.lblEstadoCertificado.Name = "lblEstadoCertificado";
            this.lblEstadoCertificado.Size = new System.Drawing.Size(400, 25);
            this.lblEstadoCertificado.TabIndex = 3;
            this.lblEstadoCertificado.Text = "No hay certificado configurado para generar licencias";
            this.lblEstadoCertificado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCertificadoInfo
            // 
            this.panelCertificadoInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelCertificadoInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelCertificadoInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCertificadoInfo.Controls.Add(this.lblInfoCertificado);
            this.panelCertificadoInfo.Controls.Add(this.btnEliminarCertificado);
            this.panelCertificadoInfo.Location = new System.Drawing.Point(200, 130);
            this.panelCertificadoInfo.Name = "panelCertificadoInfo";
            this.panelCertificadoInfo.Size = new System.Drawing.Size(400, 60);
            this.panelCertificadoInfo.TabIndex = 4;
            this.panelCertificadoInfo.Visible = false;
            // 
            // lblInfoCertificado
            // 
            this.lblInfoCertificado.AutoSize = true;
            this.lblInfoCertificado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoCertificado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblInfoCertificado.Location = new System.Drawing.Point(10, 10);
            this.lblInfoCertificado.Name = "lblInfoCertificado";
            this.lblInfoCertificado.Size = new System.Drawing.Size(200, 15);
            this.lblInfoCertificado.TabIndex = 0;
            this.lblInfoCertificado.Text = "Información del certificado";
            // 
            // btnEliminarCertificado
            // 
            this.btnEliminarCertificado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminarCertificado.FlatAppearance.BorderSize = 0;
            this.btnEliminarCertificado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCertificado.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarCertificado.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCertificado.Location = new System.Drawing.Point(320, 25);
            this.btnEliminarCertificado.Name = "btnEliminarCertificado";
            this.btnEliminarCertificado.Size = new System.Drawing.Size(70, 25);
            this.btnEliminarCertificado.TabIndex = 1;
            this.btnEliminarCertificado.Text = "Eliminar";
            this.btnEliminarCertificado.UseVisualStyleBackColor = false;
            this.btnEliminarCertificado.Click += new System.EventHandler(this.btnEliminarCertificado_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerarLicencia);
            this.Controls.Add(this.btnCargarCertificado);
            this.Controls.Add(this.panelCertificadoInfo);
            this.Controls.Add(this.lblEstadoCertificado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnGenerarCertificados);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Middleware License Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelCertificadoInfo.ResumeLayout(false);
            this.panelCertificadoInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnGenerarCertificados;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblEstadoCertificado;
        private System.Windows.Forms.Panel panelCertificadoInfo;
        private System.Windows.Forms.Label lblInfoCertificado;
        private System.Windows.Forms.Button btnEliminarCertificado;
        private System.Windows.Forms.Button btnCargarCertificado;
        private System.Windows.Forms.Button btnGenerarLicencia;
    }
}

