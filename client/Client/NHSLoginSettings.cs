namespace NHS.Login.Client
{
    public class NHSLoginSettings
    {
        public static string Name = "NHSLogin";
        public string ClientId { get; set; }
        public string Subject { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string  Authority{get;set;}

        public string PrivateKeyFile { get; set; }
    }
}