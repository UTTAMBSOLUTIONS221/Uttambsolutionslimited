namespace Uttambsolutionscustomerdbl.Entities
{
    public class Uttambsolutionscustomers
    {
        public int Customerid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Emailadddress { get; set; }
        public string? Phonenumber { get; set; }
        public string? Passwords { get; set; }
        public string? Passharsh { get; set; }
        public int Loginstatus { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public int Createdby { get; set; }
        public int Updatedby { get; set; }
        public int Deletedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Dateupdated { get; set; } = DateTime.Now;
        public DateTime Datedeleted { get; set; } = DateTime.Now;
    }
}
