using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace Gizmox.WebGUI.BlazorPilot.Data
{
    public class AdministrationLogonService
    {
        private readonly AdministrationOptions _options;

        public AdministrationLogonService(IOptions<AdministrationOptions> options)
        {
            _options = options.Value;
        }

        public bool ValidateCredentials(string username, string password)
        {
            return !string.IsNullOrEmpty(username)
                && !string.IsNullOrEmpty(password)
                && username.Equals(_options.LogonUserName, StringComparison.OrdinalIgnoreCase)
                && password == _options.LogonPassword;
        }

        public string CreateToken(string username, string password)
        {
            var ts = DateTime.UtcNow.Add(_options.TokenLifetime).Ticks;
            var payload = $"type=forms&username={Uri.EscapeDataString(username)}&password={Uri.EscapeDataString(password)}&timestamp={ts}";
            return EncryptString(payload);
        }

        public bool TryGetToken(string token, out (string Username, string Password)? credentials)
        {
            credentials = null;
            if (string.IsNullOrWhiteSpace(token)) return false;

            try
            {
                var decrypted = DecryptString(token);
                var nbr = QueryHelpers.ParseQuery(decrypted);
                if (nbr.TryGetValue("timestamp", out var timestampRaw)
                    && long.TryParse(timestampRaw, out var ticks)
                    && new DateTime(ticks, DateTimeKind.Utc) > DateTime.UtcNow
                    && nbr.TryGetValue("type", out var type)
                    && type == "forms"
                    && nbr.TryGetValue("username", out var username)
                    && nbr.TryGetValue("password", out var password))
                {
                    credentials = (Uri.UnescapeDataString(username), Uri.UnescapeDataString(password));
                    return true;
                }
            }
            catch
            {
                // invalid token
            }

            return false;
        }

        public string EncryptString(string clearText)
        {
            using var aes = Aes.Create();
            var salt = Encoding.UTF8.GetBytes(_options.EncryptionSaltKey.PadRight(16).Substring(0, 16));
            var iv = Encoding.UTF8.GetBytes(_options.EncryptionVIKey.PadRight(16).Substring(0, 16));
            var key = new Rfc2898DeriveBytes(_options.EncryptionPasswordHash, salt, 10000);
            aes.Key = key.GetBytes(32);
            aes.IV = iv;

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var clearBytes = Encoding.UTF8.GetBytes(clearText);
            var cipherBytes = encryptor.TransformFinalBlock(clearBytes, 0, clearBytes.Length);
            return WebEncoders.Base64UrlEncode(cipherBytes);
        }

        public string DecryptString(string cipherText)
        {
            using var aes = Aes.Create();
            var salt = Encoding.UTF8.GetBytes(_options.EncryptionSaltKey.PadRight(16).Substring(0, 16));
            var iv = Encoding.UTF8.GetBytes(_options.EncryptionVIKey.PadRight(16).Substring(0, 16));
            var key = new Rfc2898DeriveBytes(_options.EncryptionPasswordHash, salt, 10000);
            aes.Key = key.GetBytes(32);
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            var cipherBytes = WebEncoders.Base64UrlDecode(cipherText);
            var clearBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return Encoding.UTF8.GetString(clearBytes);
        }
    }
}
