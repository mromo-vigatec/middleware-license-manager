using System;
using System.Drawing;
using System.Windows.Forms;

namespace middleware_license_manager
{
    public partial class FormPasswordCertificado : Form
    {
        private TextBox txtPassword;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label lblInstrucciones;
        private Label lblArchivo;

        public string Password { get; private set; }
        public string FilePath { get; set; }

        public FormPasswordCertificado()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtPassword = new TextBox();
            this.btnAceptar = new Button();
            this.btnCancelar = new Button();
            this.lblInstrucciones = new Label();
            this.lblArchivo = new Label();

            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(450, 200);
            this.Text = "Contraseña del Certificado";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // lblInstrucciones
            this.lblInstrucciones.Text = "Ingrese la contraseña del certificado seleccionado:";
            this.lblInstrucciones.Location = new Point(20, 20);
            this.lblInstrucciones.Size = new Size(400, 20);
            this.lblInstrucciones.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblInstrucciones.ForeColor = Color.FromArgb(51, 51, 51);

            // lblArchivo
            this.lblArchivo.Location = new Point(20, 45);
            this.lblArchivo.Size = new Size(400, 30);
            this.lblArchivo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblArchivo.ForeColor = Color.FromArgb(102, 102, 102);
            this.lblArchivo.Text = "Archivo: ";

            // txtPassword
            this.txtPassword.Location = new Point(20, 85);
            this.txtPassword.Size = new Size(400, 25);
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Font = new Font("Segoe UI", 10F);
            this.txtPassword.KeyDown += TxtPassword_KeyDown;

            // btnAceptar
            this.btnAceptar.Text = "Cargar";
            this.btnAceptar.Location = new Point(270, 130);
            this.btnAceptar.Size = new Size(75, 30);
            this.btnAceptar.BackColor = Color.FromArgb(40, 167, 69);
            this.btnAceptar.ForeColor = Color.White;
            this.btnAceptar.FlatStyle = FlatStyle.Flat;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnAceptar.Click += BtnAceptar_Click;
            this.btnAceptar.DialogResult = DialogResult.OK;

            // btnCancelar
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new Point(355, 130);
            this.btnCancelar.Size = new Size(75, 30);
            this.btnCancelar.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Font = new Font("Segoe UI", 9F);
            this.btnCancelar.DialogResult = DialogResult.Cancel;

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[] {
                lblInstrucciones,
                lblArchivo,
                txtPassword,
                btnAceptar,
                btnCancelar
            });

            this.ResumeLayout(false);
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAceptar_Click(sender, e);
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es requerida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            Password = txtPassword.Text;
            this.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            // Mostrar el nombre del archivo seleccionado
            if (!string.IsNullOrEmpty(FilePath))
            {
                lblArchivo.Text = $"Archivo: {System.IO.Path.GetFileName(FilePath)}";
            }
            
            txtPassword.Focus();
        }
    }
}