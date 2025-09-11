using System;
using System.Drawing;
using System.Windows.Forms;

namespace middleware_license_manager
{
    public partial class FormGenerarLicencia : Form
    {
        private TextBox txtNumeroSerial;
        private TextBox txtNumeroUUID;
        private TextBox txtSerialDisco;
        private DateTimePicker dtpFechaExpiracion;
        private Button btnGenerar;
        private Button btnCancelar;
        
        private Label lblNumeroSerial;
        private Label lblNumeroUUID;
        private Label lblSerialDisco;
        private Label lblFechaExpiracion;
        private Label lblTitulo;

        public string NumeroSerial { get; private set; }
        public string NumeroUUID { get; private set; }
        public string SerialDisco { get; private set; }
        public DateTime FechaExpiracion { get; private set; }

        public FormGenerarLicencia()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Inicializar controles
            this.txtNumeroSerial = new TextBox();
            this.txtNumeroUUID = new TextBox();
            this.txtSerialDisco = new TextBox();
            this.dtpFechaExpiracion = new DateTimePicker();
            this.btnGenerar = new Button();
            this.btnCancelar = new Button();
            
            this.lblNumeroSerial = new Label();
            this.lblNumeroUUID = new Label();
            this.lblSerialDisco = new Label();
            this.lblFechaExpiracion = new Label();
            this.lblTitulo = new Label();

            this.SuspendLayout();

            // Configuración del formulario
            this.ClientSize = new Size(500, 350);
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

            // Número Serial
            this.lblNumeroSerial.Text = "Número Serial: *";
            this.lblNumeroSerial.Location = new Point(30, 70);
            this.lblNumeroSerial.Size = new Size(440, 20);
            this.lblNumeroSerial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblNumeroSerial.ForeColor = Color.FromArgb(51, 51, 51);

            this.txtNumeroSerial.Location = new Point(30, 95);
            this.txtNumeroSerial.Size = new Size(440, 25);
            this.txtNumeroSerial.Font = new Font("Segoe UI", 10F);
            this.txtNumeroSerial.Text = "SN-" + DateTime.Now.ToString("yyyyMMdd") + "-001";

            // Número UUID del Sistema
            this.lblNumeroUUID.Text = "Número UUID del Sistema: *";
            this.lblNumeroUUID.Location = new Point(30, 130);
            this.lblNumeroUUID.Size = new Size(440, 20);
            this.lblNumeroUUID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblNumeroUUID.ForeColor = Color.FromArgb(51, 51, 51);

            this.txtNumeroUUID.Location = new Point(30, 155);
            this.txtNumeroUUID.Size = new Size(440, 25);
            this.txtNumeroUUID.Font = new Font("Segoe UI", 10F);
            this.txtNumeroUUID.Text = Guid.NewGuid().ToString();

            // Serial del Disco
            this.lblSerialDisco.Text = "Serial del Disco: *";
            this.lblSerialDisco.Location = new Point(30, 190);
            this.lblSerialDisco.Size = new Size(440, 20);
            this.lblSerialDisco.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSerialDisco.ForeColor = Color.FromArgb(51, 51, 51);

            this.txtSerialDisco.Location = new Point(30, 215);
            this.txtSerialDisco.Size = new Size(440, 25);
            this.txtSerialDisco.Font = new Font("Segoe UI", 10F);
            this.txtSerialDisco.Text = "DISK-" + DateTime.Now.ToString("yyyyMMdd") + "-" + new Random().Next(1000, 9999);

            // Fecha de Expiración
            this.lblFechaExpiracion.Text = "Fecha de Expiración de la Licencia: *";
            this.lblFechaExpiracion.Location = new Point(30, 250);
            this.lblFechaExpiracion.Size = new Size(440, 20);
            this.lblFechaExpiracion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblFechaExpiracion.ForeColor = Color.FromArgb(51, 51, 51);

            this.dtpFechaExpiracion.Location = new Point(30, 275);
            this.dtpFechaExpiracion.Size = new Size(440, 25);
            this.dtpFechaExpiracion.Font = new Font("Segoe UI", 10F);
            this.dtpFechaExpiracion.Format = DateTimePickerFormat.Long;
            this.dtpFechaExpiracion.MinDate = DateTime.Now.Date;
            this.dtpFechaExpiracion.Value = DateTime.Now.AddYears(1);

            // Botón Generar
            this.btnGenerar.Text = "Generar Licencia";
            this.btnGenerar.Location = new Point(285, 310);
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
            this.btnCancelar.Location = new Point(415, 310);
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
                lblNumeroUUID, txtNumeroUUID,
                lblSerialDisco, txtSerialDisco,
                lblFechaExpiracion, dtpFechaExpiracion,
                btnGenerar, btnCancelar
            });

            this.ResumeLayout(false);
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            // Validar campos requeridos
            if (string.IsNullOrWhiteSpace(txtNumeroSerial.Text))
            {
                MessageBox.Show("El número serial es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroSerial.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroUUID.Text))
            {
                MessageBox.Show("El número UUID del sistema es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroUUID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSerialDisco.Text))
            {
                MessageBox.Show("El serial del disco es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerialDisco.Focus();
                return;
            }

            // Validar que la fecha de expiración sea futura
            if (dtpFechaExpiracion.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de expiración debe ser posterior a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaExpiracion.Focus();
                return;
            }

            // Validar formato UUID básico (opcional, puede ser más estricto)
            if (!EsFormatoUUIDValido(txtNumeroUUID.Text.Trim()))
            {
                MessageBox.Show("El formato del UUID no es válido. Debe ser un GUID válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroUUID.Focus();
                return;
            }

            // Asignar valores
            NumeroSerial = txtNumeroSerial.Text.Trim();
            NumeroUUID = txtNumeroUUID.Text.Trim();
            SerialDisco = txtSerialDisco.Text.Trim();
            FechaExpiracion = dtpFechaExpiracion.Value.Date;

            this.Close();
        }

        private bool EsFormatoUUIDValido(string uuid)
        {
            if (string.IsNullOrWhiteSpace(uuid))
                return false;

            // Intentar convertir a GUID para validar formato
            Guid guidResult;
            return Guid.TryParse(uuid, out guidResult);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtNumeroSerial.Focus();
        }
    }
}