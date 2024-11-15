namespace Uttambsolutionsstaffdbl.Entities
{
    public class Uttambsolutionsstaffs
    {
        public int Staffid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Emailaddress { get; set; }
        public string? Phonenumber { get; set; }
        public string? Passwords { get; set; }
        public string? Passwordhash { get; set; }
        public int Loginstatus { get; set; }
        public bool Confirmemail { get; set; }
        public bool Confirmphone { get; set; }
        public bool Changepassword { get; set; }
        public DateTime Lastpasswordchange { get; set; } = DateTime.Now;
        public int Roleid { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public bool Isdefault { get; set; }
        public int Createdby { get; set; }
        public int Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; } = DateTime.Now;
    }
}
