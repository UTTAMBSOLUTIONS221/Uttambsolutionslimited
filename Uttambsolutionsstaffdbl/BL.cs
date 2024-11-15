using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Helpers;
using Uttambsolutionsstaffdbl.Models;
using Uttambsolutionsstaffdbl.UOW;

namespace Uttambsolutionsstaffdbl
{
    public class BL
    {
        public const string JWT_SECURITY_KEY = "Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kwq5R2Nmf4FWs03Hdx";
        private const int JWT_TOKEN_VALIDITY_MINS = 30;

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
                    obj.Passwordhash = Passwordhash;
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
        public Task<Uttambsolutionsstaffresponce> Validateuttambsolutionsstaffdata(Uttambsolurionsstaffauth obj)
        {
            return Task.Run(() =>
            {
                Uttambsolutionsstaffresponce userModel = new Uttambsolutionsstaffresponce { };
                var resp = db.AuthRepository.Validateuttambsolutionsstaffdata(obj.Username);
                if (resp.RespStatus == 0)
                {
                    Encryptdecrypt sec = new Encryptdecrypt();
                    string descpass = sec.Decrypt(resp.Passwords, resp.Passwordhash);
                    if (obj.Password == descpass)
                    {
                        var Tokenexpirytimestamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
                        var Tokenkey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
                        var Claimidentity = new ClaimsIdentity(new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Name,obj.Username),
                            new Claim(ClaimTypes.Role,"")
                        });
                        var Signingcredentials = new SigningCredentials(
                            new SymmetricSecurityKey(Tokenkey),
                            SecurityAlgorithms.HmacSha256Signature
                            );
                        var Securitytokendescriptor = new SecurityTokenDescriptor
                        {
                            Subject = Claimidentity,
                            Expires = Tokenexpirytimestamp,
                            SigningCredentials = Signingcredentials
                        };
                        var Jwtsecuritytokenhandler = new JwtSecurityTokenHandler();
                        var Securitytoken = Jwtsecuritytokenhandler.CreateToken(Securitytokendescriptor);
                        var Token = Jwtsecuritytokenhandler.WriteToken(Securitytoken);

                        userModel = new Uttambsolutionsstaffresponce
                        {
                            RespStatus = resp.RespStatus,
                            RespMessage = resp.RespMessage,
                            Token = Token,
                            Expiresin = (int)Tokenexpirytimestamp.Subtract(DateTime.Now).TotalSeconds,
                            Usermodel = new Usermodeldataresponce
                            {
                                Loginid = resp.Loginid,
                                Fullname = resp.Fullname,
                                Phonenumber = resp.Phonenumber,
                                Emailaddress = resp.Emailaddress,
                                Roleid = resp.Roleid,
                                Passharsh = resp.Passharsh,
                                Passwords = resp.Passwords,
                            }
                        };
                        return userModel;
                    }
                    else
                    {
                        userModel.RespStatus = 1;
                        userModel.RespMessage = "Incorrect Username or Password";
                    }
                }
                else
                {
                    userModel.RespStatus = 1;
                    userModel.RespMessage = resp.RespMessage;
                }
                return userModel;
            });
        }
        #endregion
    }
}
