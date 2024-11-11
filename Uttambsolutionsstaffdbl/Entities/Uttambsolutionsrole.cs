namespace Uttambsolutionsstaffdbl.Entities
{
    public class Uttambsolutionsrole
    {
        public int Roleid { get; set; }
        public string? Rolename { get; set; }
        public string? Roledescription { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public bool Isdefault { get; set; }
        public List<Uttambsolutionspermission>? Permissions { get; set; }
    }
}
