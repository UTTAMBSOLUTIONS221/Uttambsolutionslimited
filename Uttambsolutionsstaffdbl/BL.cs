using Newtonsoft.Json;
using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Helpers;
using Uttambsolutionsstaffdbl.Models;
using Uttambsolutionsstaffdbl.UOW;

namespace Uttambsolutionsstaffdbl
{
    public class BL
    {
        private UnitOfWork db;
        private string _connString;
        static bool mailSent = false;
        Encryptdecrypt sec = new Encryptdecrypt();
        Stringgenerator str = new Stringgenerator();
        public string LogFile { get; set; }
        public BL(string connString)
        {
            this._connString = connString;
            db = new UnitOfWork(connString);
        }

        #region Permission Management
        public Task<IEnumerable<Uttambsolutionspermission>> Getuttambsolutionspermissiondata()
        {
            return Task.Run(() =>
            {
                var Resp = db.PermissionRepository.Getuttambsolutionspermissiondata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registeruttambsolutionspermissiondata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.PermissionRepository.Registeruttambsolutionspermissiondata(obj);
                return Resp;
            });
        }
        public Task<Uttambsolutionspermission> Getuttambsolutionspermissiondatabyid(long Roleid)
        {
            return Task.Run(() =>
            {
                var Resp = db.PermissionRepository.Getuttambsolutionspermissiondatabyid(Roleid);
                return Resp;
            });
        }
        #endregion

        #region Role Management
        public Task<IEnumerable<Uttambsolutionsrole>> Getuttambsolutionsroledata()
        {
            return Task.Run(() =>
            {
                var Resp = db.RoleRepository.Getuttambsolutionsroledata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registeruttambsolutionsroledata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.RoleRepository.Registeruttambsolutionsroledata(obj);
                return Resp;
            });
        }
        public Task<Uttambsolutionsrole> Getuttambsolutionsroledatabyid(long Roleid)
        {
            return Task.Run(() =>
            {
                var Resp = db.RoleRepository.Getuttambsolutionsroledatabyid(Roleid);
                return Resp;
            });
        }
        #endregion

        #region Staff Management
        public Task<IEnumerable<Uttambsolutionsstaffs>> Getuttambsolutionsstaffdata()
        {
            return Task.Run(() =>
            {
                var Resp = db.StaffRepository.Getuttambsolutionsstaffdata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registeruttambsolutionsstaffdata(Uttambsolutionsstaffs obj)
        {
            return Task.Run(() =>
            {
                string Passwordhash = str.RandomString(12);
                if (obj.Staffid == 0)
                {
                    obj.Passwords = sec.Encrypt(obj.Passwords, Passwordhash);
                    obj.Passharsh = Passwordhash;
                }
                var Resp = db.StaffRepository.Registeruttambsolutionsstaffdata(JsonConvert.SerializeObject(obj));
                return Resp;
            });
        }
        public Task<Uttambsolutionsstaffs> Getuttambsolutionsstaffdatabyid(long Staffid)
        {
            return Task.Run(() =>
            {
                var Resp = db.StaffRepository.Getuttambsolutionsstaffdatabyid(Staffid);
                return Resp;
            });
        }
        #endregion

        #region Authentication Management
        public Task<Uttambsolutionsstaffresponce> Validateuttambsolutionsstaffdata(string Username, string Password)
        {
            return Task.Run(() =>
            {
                Uttambsolutionsstaffresponce userModel = new Uttambsolutionsstaffresponce { };
                var resp = db.AuthRepository.Validateuttambsolutionsstaffdata(Username);
                return userModel;
            });
        }
        #endregion
    }
}
