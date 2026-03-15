namespace Gizmox.WebGUI.BlazorPilot.Data
{
    public class AdministrationOptions
    {
        public string LogonUserName { get; set; } = "admin";
        public string LogonPassword { get; set; } = "password";
        public TimeSpan TokenLifetime { get; set; } = TimeSpan.FromMinutes(10);
        public string EncryptionSaltKey { get; set; } = "h@$d5Ju8";
        public string EncryptionVIKey { get; set; } = "@h48sk37dER925G6";
        public string EncryptionPasswordHash { get; set; } = "P@ssw0rd";
    }
}