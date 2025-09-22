using System;
using System.Drawing;
using System.Windows.Forms;

namespace middleware_license_manager
{
    public partial class FormGenerarLicencia : Form
    {
        private TextBox txtNumeroSerial;
        private TextBox txtMachineID;
        private TextBox txtSerialDisco;
        private DateTimePicker dtpFechaExpiracion;
        private Button btnGenerar;
        private Button btnCancelar;
        private Button btnObtenerSistema;
        
        private Label lblNumeroSerial;
        private Label lblMachineID;
        private Label lblSerialDisco;
        private Label lblFechaExpiracion;
        private Label lblTitulo;

        public string NumeroSerial { get; private set; }
        public string MachineID { get; private set; }
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
            this.txtMachineID = new TextBox();
            this.txtSerialDisco = new TextBox();
            this.dtpFechaExpiracion = new DateTimePicker();
            this.btnGenerar = new Button();
            this.btnCancelar = new Button();
            this.btnObtenerSistema = new Button();
            
            this.lblNumeroSerial = new Label();
            this.lblMachineID = new Label();
            this.lblSerialDisco = new Label();
            this.lblFechaExpiracion = new Label();
            this.lblTitulo = new Label();

            this.SuspendLayout();

            // Configuración del formulario
            this.ClientSize = new Size(500, 400);
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

            // Botón para obtener información del sistema
            this.btnObtenerSistema.Text = "Obtener Info del Sistema";
            this.btnObtenerSistema.Location = new Point(300, 55);
            this.btnObtenerSistema.Size = new Size(170, 30);
            this.btnObtenerSistema.BackColor = Color.FromArgb(108, 117, 125);
            this.btnObtenerSistema.ForeColor = Color.White;
            this.btnObtenerSistema.FlatStyle = FlatStyle.Flat;
            this.btnObtenerSistema.FlatAppearance.BorderSize = 0;
            this.btnObtenerSistema.Font = new Font("Segoe UI", 9F);
            this.btnObtenerSistema.Click += BtnObtenerSistema_Click;

            // Número Serial
            this.lblNumeroSerial.Text = "Número Serial: *";
            this.lblNumeroSerial.Location = new Point(30, 100);
            this.lblNumeroSerial.Size = new Size(440, 20);
            this.lblNumeroSerial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblNumeroSerial.ForeColor = Color.FromArgb(51, 51, 51);

            this.txtNumeroSerial.Location = new Point(30, 125);
            this.txtNumeroSerial.Size = new Size(440, 25);
            this.txtNumeroSerial.Font = new Font("Segoe UI", 10F);
            this.txtNumeroSerial.Text = "Y0000001651";

            // Machine ID del Sistema (/etc/machine-id)
            this.lblMachineID.Text = "Machine ID del Sistema (/etc/machine-id): *";
            this.lblMachineID.Location = new Point(30, 160);
            this.lblMachineID.Size = new Size(440, 20);
            this.lblMachineID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblMachineID.ForeColor = Color.FromArgb(51, 51, 51);

            this.txtMachineID.Location = new Point(30, 185);
            this.txtMachineID.Size = new Size(440, 25);
            this.txtMachineID.Font = new Font("Segoe UI", 10F);
            this.txtMachineID.Text = "86928bca37d04d128391af3261ab9389";

            // Serial del Disco (lsblk -no SERIAL)
            this.lblSerialDisco.Text = "Serial del Disco (lsblk -no SERIAL): *";
            this.lblSerialDisco.Location = new Point(30, 220);
            this.lblSerialDisco.Size = new Size(440, 20);
            this.lblSerialDisco.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSerialDisco.ForeColor = Color.FromArgb(51, 51, 51);

            this.txtSerialDisco.Location = new Point(30, 245);
            this.txtSerialDisco.Size = new Size(440, 25);
            this.txtSerialDisco.Font = new Font("Segoe UI", 10F);
            this.txtSerialDisco.Text = "UB202501210000009";

            // Fecha de Expiración
            this.lblFechaExpiracion.Text = "Fecha de Expiración de la Licencia: *";
            this.lblFechaExpiracion.Location = new Point(30, 280);
            this.lblFechaExpiracion.Size = new Size(440, 20);
            this.lblFechaExpiracion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblFechaExpiracion.ForeColor = Color.FromArgb(51, 51, 51);

            this.dtpFechaExpiracion.Location = new Point(30, 305);
            this.dtpFechaExpiracion.Size = new Size(440, 25);
            this.dtpFechaExpiracion.Font = new Font("Segoe UI", 10F);
            this.dtpFechaExpiracion.Format = DateTimePickerFormat.Long;
            this.dtpFechaExpiracion.MinDate = DateTime.Now.Date;
            this.dtpFechaExpiracion.Value = DateTime.Now.AddYears(10);

            // Botón Generar
            this.btnGenerar.Text = "Generar Licencia";
            this.btnGenerar.Location = new Point(285, 350);
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
            this.btnCancelar.Location = new Point(415, 350);
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
                btnObtenerSistema,
                lblNumeroSerial, txtNumeroSerial,
                lblMachineID, txtMachineID,
                lblSerialDisco, txtSerialDisco,
                lblFechaExpiracion, dtpFechaExpiracion,
                btnGenerar, btnCancelar
            });

            this.ResumeLayout(false);
        }

        private void BtnObtenerSistema_Click(object sender, EventArgs e)
        {
            try
            {
                var formInfo = new FormInformacionSistema();
                if (formInfo.ShowDialog() == DialogResult.OK)
                {
                    // Actualizar campos con información capturada
                    if (!string.IsNullOrWhiteSpace(formInfo.NumeroSerial))
                        txtNumeroSerial.Text = formInfo.NumeroSerial;
                    
                    if (!string.IsNullOrWhiteSpace(formInfo.MachineID))
                        txtMachineID.Text = formInfo.MachineID;
                    
                    if (!string.IsNullOrWhiteSpace(formInfo.SerialDisco))
                        txtSerialDisco.Text = formInfo.SerialDisco;

                    MessageBox.Show("Información del sistema actualizada correctamente.", 
                                  "Sistema Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener información del sistema: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            if (string.IsNullOrWhiteSpace(txtMachineID.Text))
            {
                MessageBox.Show("El Machine ID del sistema es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMachineID.Focus();
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

            // Validar formato Machine ID (32 caracteres hexadecimales)
            if (!EsFormatoMachineIDValido(txtMachineID.Text.Trim()))
            {
                MessageBox.Show("El formato del Machine ID no es válido. Debe ser exactamente 32 caracteres hexadecimales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMachineID.Focus();
                return;
            }

            // Asignar valores
            NumeroSerial = txtNumeroSerial.Text.Trim();
            MachineID = txtMachineID.Text.Trim();
            SerialDisco = txtSerialDisco.Text.Trim();
            FechaExpiracion = dtpFechaExpiracion.Value.Date;

            this.Close();
        }

        private bool EsFormatoMachineIDValido(string machineId)
        {
            if (string.IsNullOrWhiteSpace(machineId))
                return false;

            // Machine ID debe ser exactamente 32 caracteres hexadecimales
            if (machineId.Length != 32)
                return false;

            // Verificar que todos los caracteres sean hexadecimales
            foreach (char c in machineId)
            {
                if (!Uri.IsHexDigit(c))
                    return false;
            }

            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtNumeroSerial.Focus();
        }
    }
}