using System;
using System.Drawing;
using System.Windows.Forms;

namespace middleware_license_manager
{
    public partial class FormInformacionSistema : Form
    {
        private TextBox txtNumeroSerial;
        private TextBox txtMachineID;
        private TextBox txtSerialDisco;
        private TextBox txtComandoMachineID;
        private TextBox txtComandoDisco;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnEjemplo;
        
        private Label lblTitulo;
        private Label lblNumeroSerial;
        private Label lblMachineID;
        private Label lblSerialDisco;
        private Label lblInstrucciones;

        public string NumeroSerial { get; private set; }
        public string MachineID { get; private set; }
        public string SerialDisco { get; private set; }

        public FormInformacionSistema()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Inicializar controles
            this.txtNumeroSerial = new TextBox();
            this.txtMachineID = new TextBox();
            this.txtSerialDisco = new TextBox();
            this.txtComandoMachineID = new TextBox();
            this.txtComandoDisco = new TextBox();
            this.btnAceptar = new Button();
            this.btnCancelar = new Button();
            this.btnEjemplo = new Button();
            
            this.lblTitulo = new Label();
            this.lblNumeroSerial = new Label();
            this.lblMachineID = new Label();
            this.lblSerialDisco = new Label();
            this.lblInstrucciones = new Label();

            this.SuspendLayout();

            // Configuración del formulario
            this.ClientSize = new Size(600, 500);
            this.Text = "Información del Sistema";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // Título
            this.lblTitulo.Text = "Obtener Información del Sistema Linux";
            this.lblTitulo.Location = new Point(20, 20);
            this.lblTitulo.Size = new Size(560, 25);
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Instrucciones
            this.lblInstrucciones.Text = "Ejecute los siguientes comandos en el sistema Linux y copie los resultados:";
            this.lblInstrucciones.Location = new Point(30, 60);
            this.lblInstrucciones.Size = new Size(540, 20);
            this.lblInstrucciones.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblInstrucciones.ForeColor = Color.FromArgb(102, 102, 102);

            // Comando Machine ID
            this.lblMachineID.Text = "1. Para obtener Machine ID ejecute:";
            this.lblMachineID.Location = new Point(30, 95);
            this.lblMachineID.Size = new Size(540, 20);
            this.lblMachineID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblMachineID.ForeColor = Color.FromArgb(51, 51, 51);

            this.txtComandoMachineID.Location = new Point(30, 120);
            this.txtComandoMachineID.Size = new Size(540, 25);
            this.txtComandoMachineID.Font = new Font("Courier New", 9F);
            this.txtComandoMachineID.Text = "cat /etc/machine-id";
            this.txtComandoMachineID.ReadOnly = true;
            this.txtComandoMachineID.BackColor = Color.FromArgb(240, 240, 240);

            this.txtMachineID.Location = new Point(30, 150);
            this.txtMachineID.Size = new Size(540, 25);
            this.txtMachineID.Font = new Font("Segoe UI", 10F);
            this.txtMachineID.Text = "86928bca37d04d128391af3261ab9389";

            // Comando Serial de Disco
            this.lblSerialDisco.Text = "2. Para obtener Serial del Disco ejecute:";
            this.lblSerialDisco.Location = new Point(30, 190);
            this.lblSerialDisco.Size = new Size(540, 20);
            this.lblSerialDisco.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSerialDisco.ForeColor = Color.FromArgb(51, 51, 51);

            this.txtComandoDisco.Location = new Point(30, 215);
            this.txtComandoDisco.Size = new Size(540, 25);
            this.txtComandoDisco.Font = new Font("Courier New", 9F);
            this.txtComandoDisco.Text = "lsblk -no SERIAL /dev/nvme0n1";
            this.txtComandoDisco.ReadOnly = true;
            this.txtComandoDisco.BackColor = Color.FromArgb(240, 240, 240);

            this.txtSerialDisco.Location = new Point(30, 245);
            this.txtSerialDisco.Size = new Size(540, 25);
            this.txtSerialDisco.Font = new Font("Segoe UI", 10F);
            this.txtSerialDisco.Text = "UB202501210000009";

            // Número Serial
            this.lblNumeroSerial.Text = "3. Número Serial del Sistema:";
            this.lblNumeroSerial.Location = new Point(30, 285);
            this.lblNumeroSerial.Size = new Size(540, 20);
            this.lblNumeroSerial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblNumeroSerial.ForeColor = Color.FromArgb(51, 51, 51);

            this.txtNumeroSerial.Location = new Point(30, 310);
            this.txtNumeroSerial.Size = new Size(540, 25);
            this.txtNumeroSerial.Font = new Font("Segoe UI", 10F);
            this.txtNumeroSerial.Text = "Y0000001651";

            // Botón Ejemplo
            this.btnEjemplo.Text = "Cargar Ejemplos";
            this.btnEjemplo.Location = new Point(30, 350);
            this.btnEjemplo.Size = new Size(120, 35);
            this.btnEjemplo.BackColor = Color.FromArgb(108, 117, 125);
            this.btnEjemplo.ForeColor = Color.White;
            this.btnEjemplo.FlatStyle = FlatStyle.Flat;
            this.btnEjemplo.FlatAppearance.BorderSize = 0;
            this.btnEjemplo.Font = new Font("Segoe UI", 9F);
            this.btnEjemplo.Click += BtnEjemplo_Click;

            // Botón Aceptar
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Location = new Point(420, 350);
            this.btnAceptar.Size = new Size(75, 35);
            this.btnAceptar.BackColor = Color.FromArgb(40, 167, 69);
            this.btnAceptar.ForeColor = Color.White;
            this.btnAceptar.FlatStyle = FlatStyle.Flat;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnAceptar.Click += BtnAceptar_Click;
            this.btnAceptar.DialogResult = DialogResult.OK;

            // Botón Cancelar
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new Point(505, 350);
            this.btnCancelar.Size = new Size(75, 35);
            this.btnCancelar.BackColor = Color.FromArgb(220, 53, 69);
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Font = new Font("Segoe UI", 9F);
            this.btnCancelar.DialogResult = DialogResult.Cancel;

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[] {
                lblTitulo,
                lblInstrucciones,
                lblMachineID, txtComandoMachineID, txtMachineID,
                lblSerialDisco, txtComandoDisco, txtSerialDisco,
                lblNumeroSerial, txtNumeroSerial,
                btnEjemplo, btnAceptar, btnCancelar
            });

            this.ResumeLayout(false);
        }

        private void BtnEjemplo_Click(object sender, EventArgs e)
        {
            // Cargar valores de ejemplo
            txtMachineID.Text = "86928bca37d04d128391af3261ab9389";
            txtSerialDisco.Text = "UB202501210000009";
            txtNumeroSerial.Text = "Y0000001651";

            MessageBox.Show("Valores de ejemplo cargados correctamente.", "Ejemplos Cargados", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            // Validar campos requeridos
            if (string.IsNullOrWhiteSpace(txtMachineID.Text))
            {
                MessageBox.Show("El Machine ID es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMachineID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSerialDisco.Text))
            {
                MessageBox.Show("El Serial del Disco es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerialDisco.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroSerial.Text))
            {
                MessageBox.Show("El Número Serial es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroSerial.Focus();
                return;
            }

            // Validar formato Machine ID
            string machineId = txtMachineID.Text.Trim();
            if (machineId.Length != 32 || !EsTodoHexadecimal(machineId))
            {
                MessageBox.Show("El Machine ID debe tener exactamente 32 caracteres hexadecimales.", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMachineID.Focus();
                return;
            }

            // Asignar valores
            MachineID = machineId;
            SerialDisco = txtSerialDisco.Text.Trim();
            NumeroSerial = txtNumeroSerial.Text.Trim();

            this.Close();
        }

        private bool EsTodoHexadecimal(string text)
        {
            foreach (char c in text)
            {
                if (!Uri.IsHexDigit(c))
                    return false;
            }
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtMachineID.Focus();
        }
    }
}