using System;
using System.Drawing;
using System.Windows.Forms;

namespace middleware_license_manager
{
    public partial class FormGenerarLicencia : Form
    {
        private TextBox txtNumeroSerial;
        private DateTimePicker dtpFechaExpiracion;
        private TextBox txtIdentificacionDisco;
        private TextBox txtNumeroMAC;
        private Button btnGenerar;
        private Button btnCancelar;
        
        private Label lblNumeroSerial;
        private Label lblFechaExpiracion;
        private Label lblIdentificacionDisco;
        private Label lblNumeroMAC;
        private Label lblTitulo;

        public string NumeroSerial { get; private set; }
        public DateTime FechaExpiracion { get; private set; }
        public string IdentificacionDisco { get; private set; }
        public string NumeroMAC { get; private set; }

        public FormGenerarLicencia()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Inicializar controles
            this.txtNumeroSerial = new TextBox();
            this.dtpFechaExpiracion = new DateTimePicker();
            this.txtIdentificacionDisco = new TextBox();
            this.txtNumeroMAC = new TextBox();
            this.btnGenerar = new Button();
            this.btnCancelar = new Button();
            
            this.lblNumeroSerial = new Label();
            this.lblFechaExpiracion = new Label();
            this.lblIdentificacionDisco = new Label();
            this.lblNumeroMAC = new Label();
            this.lblTitulo = new Label();

            this.SuspendLayout();

            // Configuración del formulario
            this.ClientSize = new Size(500, 380);
            this.Text = "Generar Nueva Licencia";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // Título
            this.lblTitulo.Text = "Configuración de Nueva Licencia";
            this.lblTitulo.Location = new Point(20, 20);
            this.lblTitulo.Size = new Size(460, 25);
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Número Serial del Equipo (Campo requerido)
            this.lblNumeroSerial.Text = "Número Serial del Equipo: * (Ej: ABC123-XYZ789-DEF456)";
            this.lblNumeroSerial.Location = new Point(30, 70);
            this.lblNumeroSerial.Size = new Size(440, 20);
            this.lblNumeroSerial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblNumeroSerial.ForeColor = Color.FromArgb(51, 51, 51);

            this.txtNumeroSerial.Location = new Point(30, 95);
            this.txtNumeroSerial.Size = new Size(440, 25);
            this.txtNumeroSerial.Font = new Font("Segoe UI", 10F);

            // Fecha de Expiración (Campo requerido)
            this.lblFechaExpiracion.Text = "Fecha de Expiración: *";
            this.lblFechaExpiracion.Location = new Point(30, 140);
            this.lblFechaExpiracion.Size = new Size(200, 20);
            this.lblFechaExpiracion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblFechaExpiracion.ForeColor = Color.FromArgb(51, 51, 51);

            this.dtpFechaExpiracion.Location = new Point(30, 165);
            this.dtpFechaExpiracion.Size = new Size(440, 25);
            this.dtpFechaExpiracion.Font = new Font("Segoe UI", 10F);
            this.dtpFechaExpiracion.Format = DateTimePickerFormat.Long;
            this.dtpFechaExpiracion.MinDate = DateTime.Now.Date;
            this.dtpFechaExpiracion.Value = DateTime.Now.AddYears(1);

            // Número de Identificación de Disco (Campo opcional)
            this.lblIdentificacionDisco.Text = "Número de Identificación de Disco (Ej: 1234-5678-9ABC-DEF0):";
            this.lblIdentificacionDisco.Location = new Point(30, 210);
            this.lblIdentificacionDisco.Size = new Size(440, 20);
            this.lblIdentificacionDisco.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblIdentificacionDisco.ForeColor = Color.FromArgb(102, 102, 102);

            this.txtIdentificacionDisco.Location = new Point(30, 235);
            this.txtIdentificacionDisco.Size = new Size(440, 25);
            this.txtIdentificacionDisco.Font = new Font("Segoe UI", 10F);
            this.txtIdentificacionDisco.BackColor = Color.FromArgb(250, 250, 250);

            // Número MAC del Equipo (Campo opcional)
            this.lblNumeroMAC.Text = "Número MAC del Equipo (Ej: 00:1B:44:11:3A:B7):";
            this.lblNumeroMAC.Location = new Point(30, 280);
            this.lblNumeroMAC.Size = new Size(440, 20);
            this.lblNumeroMAC.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblNumeroMAC.ForeColor = Color.FromArgb(102, 102, 102);

            this.txtNumeroMAC.Location = new Point(30, 305);
            this.txtNumeroMAC.Size = new Size(440, 25);
            this.txtNumeroMAC.Font = new Font("Segoe UI", 10F);
            this.txtNumeroMAC.BackColor = Color.FromArgb(250, 250, 250);

            // Botón Generar
            this.btnGenerar.Text = "Generar Licencia";
            this.btnGenerar.Location = new Point(285, 340);
            this.btnGenerar.Size = new Size(120, 35);
            this.btnGenerar.BackColor = Color.FromArgb(255, 193, 7);
            this.btnGenerar.ForeColor = Color.Black;
            this.btnGenerar.FlatStyle = FlatStyle.Flat;
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnGenerar.Click += BtnGenerar_Click;
            this.btnGenerar.DialogResult = DialogResult.OK;

            // Botón Cancelar
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new Point(415, 340);
            this.btnCancelar.Size = new Size(75, 35);
            this.btnCancelar.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Font = new Font("Segoe UI", 9F);
            this.btnCancelar.DialogResult = DialogResult.Cancel;

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[] {
                lblTitulo,
                lblNumeroSerial, txtNumeroSerial,
                lblFechaExpiracion, dtpFechaExpiracion,
                lblIdentificacionDisco, txtIdentificacionDisco,
                lblNumeroMAC, txtNumeroMAC,
                btnGenerar, btnCancelar
            });

            this.ResumeLayout(false);
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            // Validar campos requeridos
            if (string.IsNullOrWhiteSpace(txtNumeroSerial.Text))
            {
                MessageBox.Show("El número serial del equipo es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroSerial.Focus();
                return;
            }

            // Validar que la fecha de expiración sea futura
            if (dtpFechaExpiracion.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de expiración debe ser posterior a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaExpiracion.Focus();
                return;
            }

            // Validar formato MAC si se proporciona
            if (!string.IsNullOrWhiteSpace(txtNumeroMAC.Text))
            {
                if (!EsFormatoMACValido(txtNumeroMAC.Text.Trim()))
                {
                    MessageBox.Show("El formato del número MAC no es válido. Use el formato: XX:XX:XX:XX:XX:XX", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumeroMAC.Focus();
                    return;
                }
            }

            // Asignar valores
            NumeroSerial = txtNumeroSerial.Text.Trim();
            FechaExpiracion = dtpFechaExpiracion.Value.Date;
            IdentificacionDisco = txtIdentificacionDisco.Text.Trim();
            NumeroMAC = txtNumeroMAC.Text.Trim();

            this.Close();
        }

        private bool EsFormatoMACValido(string mac)
        {
            if (string.IsNullOrWhiteSpace(mac))
                return true; // Es opcional

            // Formato típico: XX:XX:XX:XX:XX:XX donde X es un dígito hexadecimal
            var patron = @"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$";
            return System.Text.RegularExpressions.Regex.IsMatch(mac, patron);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtNumeroSerial.Focus();
        }
    }
}