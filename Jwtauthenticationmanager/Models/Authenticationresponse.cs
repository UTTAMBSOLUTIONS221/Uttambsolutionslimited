namespace Jwtauthenticationmanager.Models
{
    public class Authenticationresponse
    {
        public string? Username { get; set; }
        public string? Jwttoken { get; set; }
        public int Expiresin { get; set; }
    }
}
