using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace middleware_license_manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarEstadoCertificado();
        }

        private void btnEliminarCertificado_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show(
                    "¿Está seguro de que desea eliminar el certificado interno?\n\n" +
                    "ADVERTENCIA: Esto impedirá generar nuevas licencias hasta que configure un nuevo certificado.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    CertificateManager.DeleteInternalCertificate();
                    ActualizarEstadoCertificado();
                    lblEstado.Text = "Certificado eliminado";
                    lblEstado.ForeColor = Color.Orange;

                    MessageBox.Show("El certificado interno ha sido eliminado correctamente.", 
                                  "Certificado eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el certificado: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEstadoCertificado()
        {
            if (CertificateManager.HasInternalCertificate())
            {
                var certInfo = CertificateManager.GetInternalCertificateInfo();
                if (certInfo != null)
                {
                    lblEstadoCertificado.Text = "✓ Certificado configurado y listo para generar licencias";
                    lblEstadoCertificado.ForeColor = Color.FromArgb(40, 167, 69); // Verde

                    lblInfoCertificado.Text = $"CN: {certInfo.CommonName}\n" +
                                            $"Organización: {certInfo.Organization}\n" +
                                            $"Creado: {certInfo.CreatedDate:dd/MM/yyyy HH:mm}";

                    panelCertificadoInfo.Visible = true;
                    btnGenerarCertificados.Text = "Regenerar Certificados";
                }
                else
                {
                    MostrarEstadoSinCertificado();
                }
            }
            else
            {
                MostrarEstadoSinCertificado();
            }
        }

        private void MostrarEstadoSinCertificado()
        {
            lblEstadoCertificado.Text = "⚠ No hay certificado configurado para generar licencias";
            lblEstadoCertificado.ForeColor = Color.FromArgb(220, 53, 69); // Rojo
            panelCertificadoInfo.Visible = false;
            btnGenerarCertificados.Text = "Generar Certificados";
        }

        private void btnGenerarCertificados_Click(object sender, EventArgs e)
        {
            try
            {
                // Preguntar si quiere reemplazar el certificado existente
                if (CertificateManager.HasInternalCertificate())
                {
                    var result = MessageBox.Show(
                        "Ya existe un certificado configurado. ¿Desea generar uno nuevo y reemplazar el actual?\n\n" +
                        "ADVERTENCIA: Esto invalidará todas las licencias generadas con el certificado anterior.",
                        "Confirmar reemplazo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result != DialogResult.Yes)
                        return;
                }

                // Solicitar información del certificado
                var formInfo = new FormInformacionCertificado();
                if (formInfo.ShowDialog() == DialogResult.OK)
                {
                    lblEstado.Text = "Generando certificados...";
                    lblEstado.ForeColor = Color.Orange;
                    Application.DoEvents();

                    // Obtener la información del formulario
                    string nombreComun = formInfo.NombreComun;
                    string organizacion = formInfo.Organizacion;
                    string pais = formInfo.Pais;
                    string clavePrivada = formInfo.ClavePrivada;

                    // Generar el par de claves RSA
                    using (RSA rsa = RSA.Create(2048))
                    {
                        // Crear la solicitud de certificado
                        var request = new CertificateRequest($"CN={nombreComun}, O={organizacion}, C={pais}", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                        // Agregar extensiones básicas
                        request.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));
                        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, false));

                        // Crear el certificado autofirmado
                        var certificado = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1));

                        // Exportar certificado público
                        byte[] certificadoPublico = certificado.Export(X509ContentType.Cert);
                        
                        // Exportar certificado privado con protección por contraseña
                        byte[] certificadoPrivado = certificado.Export(X509ContentType.Pkcs12, clavePrivada);

                        // Guardar copia interna del certificado privado PRIMERO
                        CertificateManager.SaveInternalCertificate(certificadoPrivado, clavePrivada, nombreComun, organizacion, pais);

                        // Guardar los certificados en archivos externos
                        SaveFileDialog savePublic = new SaveFileDialog
                        {
                            Filter = "Archivo de Certificado (*.cer)|*.cer",
                            Title = "Guardar Certificado Público",
                            FileName = $"{nombreComun}_publico.cer"
                        };

                        if (savePublic.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(savePublic.FileName, certificadoPublico);

                            SaveFileDialog savePrivate = new SaveFileDialog
                            {
                                Filter = "Archivo PKCS#12 (*.pfx)|*.pfx",
                                Title = "Guardar Certificado Privado",
                                FileName = $"{nombreComun}_privado.pfx"
                            };

                            if (savePrivate.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllBytes(savePrivate.FileName, certificadoPrivado);

                                lblEstado.Text = "Certificados generados exitosamente";
                                lblEstado.ForeColor = Color.Green;

                                MessageBox.Show($"Certificados generados exitosamente:\n\n" +
                                              $"Certificado Público: {savePublic.FileName}\n" +
                                              $"Certificado Privado: {savePrivate.FileName}\n\n" +
                                              $"✓ El certificado privado está protegido con la clave que proporcionaste.\n" +
                                              $"✓ Una copia se ha guardado internamente para generar licencias.",
                                              "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Actualizar la interfaz
                                ActualizarEstadoCertificado();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al generar certificados";
                lblEstado.ForeColor = Color.Red;
                MessageBox.Show($"Error al generar los certificados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método público para obtener el certificado interno (para uso futuro en generación de licencias)
        /// </summary>
        /// <returns>Certificado X509 listo para usar o null si no está disponible</returns>
        public static X509Certificate2 ObtenerCertificadoParaLicencias()
        {
            return CertificateManager.LoadInternalCertificate();
        }
    }

    // Formulario para capturar la información del certificado
    public partial class FormInformacionCertificado : Form
    {
        private TextBox txtNombreComun;
        private TextBox txtOrganizacion;
        private TextBox txtPais;
        private TextBox txtClavePrivada;
        private Button btnAceptar;
        private Button btnCancelar;

        public string NombreComun { get; private set; }
        public string Organizacion { get; private set; }
        public string Pais { get; private set; }
        public string ClavePrivada { get; private set; }

        public FormInformacionCertificado()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtNombreComun = new TextBox();
            this.txtOrganizacion = new TextBox();
            this.txtPais = new TextBox();
            this.txtClavePrivada = new TextBox();
            this.btnAceptar = new Button();
            this.btnCancelar = new Button();

            Label lblNombreComun = new Label();
            Label lblOrganizacion = new Label();
            Label lblPais = new Label();
            Label lblClavePrivada = new Label();

            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(400, 300);
            this.Text = "Información del Certificado";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Labels y TextBoxes
            lblNombreComun.Text = "Nombre Común (CN):";
            lblNombreComun.Location = new Point(20, 20);
            lblNombreComun.Size = new Size(120, 20);

            txtNombreComun.Location = new Point(150, 20);
            txtNombreComun.Size = new Size(220, 20);
            txtNombreComun.Text = "MiCertificado";

            lblOrganizacion.Text = "Organización (O):";
            lblOrganizacion.Location = new Point(20, 60);
            lblOrganizacion.Size = new Size(120, 20);

            txtOrganizacion.Location = new Point(150, 60);
            txtOrganizacion.Size = new Size(220, 20);
            txtOrganizacion.Text = "Mi Empresa";

            lblPais.Text = "País (C):";
            lblPais.Location = new Point(20, 100);
            lblPais.Size = new Size(120, 20);

            txtPais.Location = new Point(150, 100);
            txtPais.Size = new Size(220, 20);
            txtPais.Text = "MX";
            txtPais.MaxLength = 2;

            lblClavePrivada.Text = "Clave para certificado privado:";
            lblClavePrivada.Location = new Point(20, 140);
            lblClavePrivada.Size = new Size(180, 20);

            txtClavePrivada.Location = new Point(20, 170);
            txtClavePrivada.Size = new Size(350, 20);
            txtClavePrivada.UseSystemPasswordChar = true;

            // Botones
            btnAceptar.Text = "Generar";
            btnAceptar.Location = new Point(220, 220);
            btnAceptar.Size = new Size(75, 30);
            btnAceptar.Click += BtnAceptar_Click;
            btnAceptar.DialogResult = DialogResult.OK;

            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(305, 220);
            btnCancelar.Size = new Size(75, 30);
            btnCancelar.DialogResult = DialogResult.Cancel;

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[] {
                lblNombreComun, txtNombreComun,
                lblOrganizacion, txtOrganizacion,
                lblPais, txtPais,
                lblClavePrivada, txtClavePrivada,
                btnAceptar, btnCancelar
            });

            this.ResumeLayout(false);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreComun.Text))
            {
                MessageBox.Show("El nombre común es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClavePrivada.Text))
            {
                MessageBox.Show("La clave para el certificado privado es requerida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtClavePrivada.Text.Length < 6)
            {
                MessageBox.Show("La clave debe tener al menos 6 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NombreComun = txtNombreComun.Text.Trim();
            Organizacion = string.IsNullOrWhiteSpace(txtOrganizacion.Text) ? "Default Organization" : txtOrganizacion.Text.Trim();
            Pais = string.IsNullOrWhiteSpace(txtPais.Text) ? "US" : txtPais.Text.Trim().ToUpper();
            ClavePrivada = txtClavePrivada.Text;

            this.Close();
        }
    }
}
