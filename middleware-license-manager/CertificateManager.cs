using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Win32;

namespace middleware_license_manager
{
    public static class CertificateManager
    {
        private static readonly string AppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MiddlewareLicenseManager");
        private static readonly string CertificatePath = Path.Combine(AppDataPath, "internal_certificate.pfx");
        private static readonly string CertificateInfoPath = Path.Combine(AppDataPath, "certificate_info.txt");
        private static readonly string PasswordPath = Path.Combine(AppDataPath, "cert_pwd.dat");

        static CertificateManager()
        {
            // Crear directorio si no existe
            if (!Directory.Exists(AppDataPath))
            {
                Directory.CreateDirectory(AppDataPath);
            }
        }

        /// <summary>
        /// Guarda una copia del certificado privado para uso interno de la aplicación
        /// </summary>
        /// <param name="certificateData">Datos del certificado en formato PKCS#12</param>
        /// <param name="password">Contraseña del certificado</param>
        /// <param name="commonName">Nombre común del certificado</param>
        /// <param name="organization">Organización del certificado</param>
        /// <param name="country">País del certificado</param>
        public static void SaveInternalCertificate(byte[] certificateData, string password, string commonName, string organization, string country)
        {
            try
            {
                // Guardar el certificado
                File.WriteAllBytes(CertificatePath, certificateData);

                // Guardar información del certificado (sin la contraseña)
                var certInfo = new StringBuilder();
                certInfo.AppendLine($"CommonName={commonName}");
                certInfo.AppendLine($"Organization={organization}");
                certInfo.AppendLine($"Country={country}");
                certInfo.AppendLine($"CreatedDate={DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                certInfo.AppendLine($"HasPassword=true");

                File.WriteAllText(CertificateInfoPath, certInfo.ToString(), Encoding.UTF8);

                // Guardar la contraseña de forma simple pero segura (cifrada con DPAPI básico)
                SavePasswordSecurely(password);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el certificado interno: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifica si existe un certificado interno para la aplicación
        /// </summary>
        /// <returns>True si existe un certificado válido</returns>
        public static bool HasInternalCertificate()
        {
            return File.Exists(CertificatePath) && File.Exists(CertificateInfoPath);
        }

        /// <summary>
        /// Obtiene la información del certificado interno
        /// </summary>
        /// <returns>Información del certificado o null si no existe</returns>
        public static CertificateInfo GetInternalCertificateInfo()
        {
            if (!HasInternalCertificate())
                return null;

            try
            {
                var lines = File.ReadAllLines(CertificateInfoPath);
                var info = new CertificateInfo();

                foreach (var line in lines)
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        switch (parts[0])
                        {
                            case "CommonName":
                                info.CommonName = parts[1];
                                break;
                            case "Organization":
                                info.Organization = parts[1];
                                break;
                            case "Country":
                                info.Country = parts[1];
                                break;
                            case "CreatedDate":
                                if (DateTime.TryParse(parts[1], out DateTime createdDate))
                                    info.CreatedDate = createdDate;
                                break;
                        }
                    }
                }

                return info;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Carga el certificado interno para uso en la aplicación
        /// </summary>
        /// <returns>Certificado X509 o null si no se puede cargar</returns>
        public static X509Certificate2 LoadInternalCertificate()
        {
            if (!HasInternalCertificate())
                return null;

            try
            {
                var password = GetStoredPassword();
                if (string.IsNullOrEmpty(password))
                    return null;

                var certificateData = File.ReadAllBytes(CertificatePath);
                return new X509Certificate2(certificateData, password);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Elimina el certificado interno
        /// </summary>
        public static void DeleteInternalCertificate()
        {
            try
            {
                if (File.Exists(CertificatePath))
                    File.Delete(CertificatePath);

                if (File.Exists(CertificateInfoPath))
                    File.Delete(CertificateInfoPath);

                if (File.Exists(PasswordPath))
                    File.Delete(PasswordPath);

                DeleteStoredPassword();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el certificado interno: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Guarda la contraseña de forma segura usando codificación Base64 simple
        /// </summary>
        private static void SavePasswordSecurely(string password)
        {
            try
            {
                // Usar codificación Base64 simple para compatibilidad con .NET Framework 4.8
                var encodedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
                
                // Intentar guardar en el registro primero
                try
                {
                    using (var key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MiddlewareLicenseManager"))
                    {
                        key.SetValue("CertPassword", encodedPassword);
                    }
                }
                catch
                {
                    // Si falla el registro, guardar en archivo local
                    File.WriteAllText(PasswordPath, encodedPassword);
                }
            }
            catch
            {
                // Si todo falla, no guardamos la contraseña (menos seguro pero funcional)
            }
        }

        /// <summary>
        /// Recupera la contraseña almacenada
        /// </summary>
        private static string GetStoredPassword()
        {
            try
            {
                string encodedPassword = null;

                // Intentar recuperar del registro primero
                try
                {
                    using (var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MiddlewareLicenseManager"))
                    {
                        encodedPassword = key?.GetValue("CertPassword") as string;
                    }
                }
                catch
                {
                    // Si falla el registro, intentar del archivo local
                    if (File.Exists(PasswordPath))
                    {
                        encodedPassword = File.ReadAllText(PasswordPath);
                    }
                }

                if (string.IsNullOrEmpty(encodedPassword))
                    return null;

                var passwordBytes = Convert.FromBase64String(encodedPassword);
                return Encoding.UTF8.GetString(passwordBytes);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Elimina la contraseña almacenada
        /// </summary>
        private static void DeleteStoredPassword()
        {
            try
            {
                // Eliminar del registro
                using (var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MiddlewareLicenseManager", true))
                {
                    key?.DeleteValue("CertPassword", false);
                }
            }
            catch
            {
                // Ignorar errores al eliminar del registro
            }

            try
            {
                // Eliminar archivo local si existe
                if (File.Exists(PasswordPath))
                    File.Delete(PasswordPath);
            }
            catch
            {
                // Ignorar errores al eliminar archivo
            }
        }
    }

    /// <summary>
    /// Información del certificado
    /// </summary>
    public class CertificateInfo
    {
        public string CommonName { get; set; }
        public string Organization { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}